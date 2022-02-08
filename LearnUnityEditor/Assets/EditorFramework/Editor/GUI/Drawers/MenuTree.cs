using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.IMGUI.Controls;
using System.Linq;

namespace EditorFramework
{
    public class MenuTree : GUIBase
    {

        private class InnerTree : TreeView
        {
            public event Action<string> OnCurrentChange;
            private IList<string> _paths;

            private class Item : TreeViewItem
            {
                public string Path;
            }

            private List<Item> _items;

            public void ReadTree(List<string> paths, bool sort = true)
            {
                if (sort) paths.Sort();
                _paths = paths;
                Reload();
            }

            public InnerTree(TreeViewState state) : base(state)
            {
                rowHeight = 30;
            }

            protected override TreeViewItem BuildRoot()
            {
                var root = new TreeViewItem() { id = 0, depth = -1, displayName = "Root" };
                return root;
            }

            private string ToString(string[] strs,int count)
            {
                string tmp = string.Empty;
                for (int i = 0; i < strs.Length; i++)
                {
                    tmp += "/" + strs[i];
                }
                return tmp.Substring(1);
            }

            protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
            {
                if (_paths == null) return new List<TreeViewItem>();
                _items = new List<Item>();
                for (int i = 0; i < _paths.Count; i++)
                {
                    string path = _paths[i];
                    var items = path.Split('/').ToList();
                    string last = items.Last();
                    bool ok = true;
                    if (!string.IsNullOrEmpty(searchString))
                    {
                        if (!last.ToLower().Contains(searchString.ToLower()))
                        {
                            ok = false;
                        }
                    }
                    if (ok)
                    {
                        var list2 = new List<Item>();
                        int index = 0;
                        for (int j = 0; j < items.Count; j++)
                        {
                            int depth = j;
                            string name = items[j];
                            string __path = ToString(items.ToArray(), j + 1);
                            var exist = _items.Find((it) =>
                            {
                                return it.displayName == name && it.depth == depth && it.Path == __path;
                            });
                            if (exist == null)
                            {
                                index++;
                                exist = new Item()
                                {
                                    id = index + _items.Count - 1,
                                    depth = depth,
                                    displayName = name
                                };
                            }
                            list2.Add(exist);
                        }
                        for (int j = 0; j < list2.Count; j++)
                        {
                            Item item = list2[j];
                            Item next = null;
                            if (j + 1 < list2.Count)
                            {
                                next = list2[j + 1];
                            }
                            if (!_items.Contains(item))
                            {
                                _items.Add(item);
                            }
                            if(!IsExpanded(item.id) || next == null)
                            {
                                item.children = next == null ? null : CreateChildListForCollapsedParent();
                                break;
                            }
                            else
                            {
                                item.AddChild(next);
                            }
                        }
                    }
                }
                return _items.ConvertAll(it =>
                {
                    return new TreeViewItem()
                    {
                        id = it.id,
                        depth = it.depth,
                        displayName = it.displayName,
                        children = it.children,
                        icon = it.icon,
                        parent = it.parent
                    };
                });
            }

            protected override bool CanMultiSelect(TreeViewItem item)
            {
                return false;
            }

            protected override void SelectionChanged(IList<int> selectedIds)
            {
                string name = _items[selectedIds.First()].Path;
                OnCurrentChange?.Invoke(name);
                base.SelectionChanged(selectedIds);
            }

            protected override void SearchChanged(string newSearch)
            {
                Reload();
            }

            public void Clear()
            {
                _paths = null;
                Reload();
            }

            protected override void RowGUI(RowGUIArgs args)
            {
                Rect rowRect = args.rowRect;
                rowRect.y += rowRect.height;
                rowRect.height = 1;
                EditorGUI.DrawRect(rowRect, new Color(0.5f, 0.5f, 0.5f, 1));

                var item = args.item;

                Rect labelRect = args.rowRect.Zoom(RectExtension.AnchorType.MiddleCenter, -10);
                if (hasSearch)
                {
                    labelRect.x += depthIndentWidth;
                    labelRect.width -= labelRect.x;
                }
                else
                {
                    labelRect.x += item.depth*depthIndentWidth + depthIndentWidth;
                    labelRect.width -= labelRect.x;
                }
                GUI.Label(labelRect, item.displayName, GUIStyles.BoldLabel);
            }

            public void Select(string path)
            {
                var fit = _items.Find((item) => { return item.Path == path; });
                if(fit != null)
                {
                    SetSelection(new List<int>()
                    {
                        fit.id
                    }, TreeViewSelectionOptions.FireSelectionChanged);
                }
            }
        }

        private InnerTree _Tree;
        public event Action<string> OnCurrentChange;

        public MenuTree()
        {
            _Tree = new InnerTree(new TreeViewState());
            _Tree.OnCurrentChange += TreeOnCurrentChange;
        }

        private void TreeOnCurrentChange(string obj)
        {
            OnCurrentChange?.Invoke(obj);
        }

        public void ReadTree(List<string> paths,bool sort = true)
        {
            _Tree.ReadTree(paths, sort);
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            _Tree.OnGUI(position);
        }

        public void Clear()
        {
            _Tree.Clear();
        }

        public void Select(string path)
        {
            _Tree.Select(path);
        }

        protected override void OnDispose()
        {
            Clear();
        }
    }
}