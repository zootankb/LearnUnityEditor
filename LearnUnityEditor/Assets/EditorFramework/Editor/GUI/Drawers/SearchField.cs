using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace EditorFramework
{
    public class SearchField : GUIBase
    {
        private int mContentIndex;
        private string mSearchContent;
        private string[] mSearchableContent;
        private MethodInfo mDrawAPI;

        public event Action<int> OnModeChanged;
        public event Action<string> OnValueChanged;
        public event Action<string> OnEndEdit;


        public SearchField(string searchContent,string[] searchableContent, int contentIndex)
        {
            mContentIndex = contentIndex;
            mSearchableContent = searchableContent;
            mSearchContent = searchContent;

            mDrawAPI = typeof(EditorGUI).GetMethod("ToolbarSearchField", BindingFlags.NonPublic | BindingFlags.Static, null,
                new Type[] { typeof(int), typeof(Rect), typeof(string[]), typeof(int).MakeByRefType(),typeof(string) },null);
        }

        private int mControllId;
        public override void OnGUI(Rect position)
        {
            if (mDrawAPI != null)
            {
                mControllId = GUIUtility.GetControlID("EditorSearchField".GetHashCode(), FocusType.Keyboard, position);

                int mode = mContentIndex;
                object[] args = new object[] { mControllId, position, mSearchableContent, mode, mSearchContent };
                string newSearchableContent = mDrawAPI.Invoke(null, args) as string;
                if ((int)args[3] != mContentIndex)
                {
                    mContentIndex = (int)args[3];
                    OnModeChanged?.Invoke(mContentIndex);
                }
                if(newSearchableContent != mSearchContent)
                {
                    mSearchContent = newSearchableContent;
                    OnValueChanged?.Invoke(mSearchContent);
                }

                Event e = Event.current;
                if(e.keyCode == KeyCode.Return || e.keyCode == KeyCode.Escape || e.character == '\n')
                {
                    if(GUIUtility.keyboardControl == mControllId)
                    {
                        GUIUtility.keyboardControl = -1;
                        if(e.type != EventType.Repaint && e.type != EventType.Layout)
                        {
                            e.Use();
                        }
                        OnEndEdit?.Invoke(mSearchContent);
                    }
                }
            }
        }


        protected override void OnDispose()
        {

        }
    }
}