using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;
using UnityEditor.IMGUI.Controls;
using System.Linq;

namespace EditorFramework
{
    public class SearchablePopup : PopupWindowContent
    {
        public static void Show(Rect positoin,string[] options,int current,Action<int,string> onValueChange,int width = 400)
        {
            SearchablePopup win = new SearchablePopup(options, current, onValueChange, width);
            PopupWindow.Show(positoin, win);
        }


        private readonly string[] mNames;
        private readonly int mWidth;
        private SearchField mSearchField;
        private SelectTree mTree;

        public SearchablePopup(string[] names, int currentIndex, Action<int, string> onSelectionMade, int width = 400)
        {
            mNames = names;
            mWidth = width;
            mSearchField = new SearchField("", null, 0);
            mTree = new SelectTree(new TreeViewState(), this, currentIndex, names, onSelectionMade);
            mSearchField.OnValueChanged += (str) =>
            {
                mTree.searchString = str;
            };
        }
        public override Vector2 GetWindowSize()
        {
            return new Vector2(mWidth, Mathf.Min(600, (mNames.Length + 1) * EditorStyles.toolbar.fixedHeight + 10));
        }

        public override void OnGUI(Rect rect)
        {
            var rs = rect.HorizontalSplit(EditorStyles.toolbar.fixedHeight + 5);
            DrawSearch(rs[0].Zoom(RectExtension.AnchorType.LowerCenter, -5));
            mTree.OnGUI(rs[1].Zoom(RectExtension.AnchorType.UpperCenter, -5));
        }

        private void DrawSearch(Rect rect)
        {
            mSearchField.OnGUI(rect.Zoom(RectExtension.AnchorType.MiddleCenter, -2));
        }

        private class SelectTree : TreeView
        {
            private static readonly GUIStyle Selection = "SelectionRect";

            private readonly SearchablePopup mPop;
            private readonly int mCurrent;
            private readonly string[] mNames;
            private readonly Action<int, string> mOnSelectionMade;

            public struct Index
            {
                public int Id;
                public string Value;
            }

            private List<Index> mShow;

            public SelectTree(TreeViewState state,SearchablePopup pop,int current,string[]names,Action<int, string> onSelectionMade)
                :base(state)
            {
                mPop = pop;
                mCurrent = current;
                mNames = names;
                mShow = new List<Index>();
                for (int i = 0; i < names.Length; i++)
                {
                    mShow.Add(new Index()
                    {
                        Id = names.ToList().IndexOf(names[i]),
                        Value = names[i]
                    });
                }
                mOnSelectionMade = onSelectionMade;
                showAlternatingRowBackgrounds = true;
                Reload();
            }

            protected override TreeViewItem BuildRoot()
            {
                var root = new TreeViewItem() { id = 0, depth = -1, displayName = "Root" };
                return root;
            }

            protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
            {
                var list = new List<TreeViewItem>();
                for (int i = 0; i < mShow.Count; i++)
                {
                    list.Add(new TreeViewItem() { id = mShow[i].Id, depth = 1, displayName = mShow[i].Value });
                }
                return list;
            }

            protected override void SingleClickedItem(int id)
            {
                base.SingleClickedItem(id);
                mOnSelectionMade(id, mNames[id]);
                mPop.editorWindow.Close();
                GUIUtility.ExitGUI();
            }

            private void DrawBox(Rect rect,Color tint)
            {
                Color c = GUI.color;
                GUI.color = tint;
                GUI.Box(rect, "", Selection);
                GUI.color = c;
            }

            protected override void SearchChanged(string newSearch)
            {
                mShow.Clear();
                for (int i = 0; i < mNames.Length; i++)
                {
                    if (mNames[i].ToLower().Contains(searchString.ToLower()))
                    {
                        mShow.Add(new Index()
                        {
                            Id = mNames.ToList().IndexOf(mNames[i]),
                            Value = mNames[i]
                        });
                    }
                }
                Reload();
            }

            protected override void RowGUI(RowGUIArgs args)
            {
                base.RowGUI(args);
                if (args.item.id == mCurrent)
                {
                    DrawBox(args.rowRect, Color.white);
                }
            }

            protected override bool CanMultiSelect(TreeViewItem item)
            {
                return false;
            }

            protected override bool CanBeParent(TreeViewItem item)
            {
                return false;
            }
        }

    }
}