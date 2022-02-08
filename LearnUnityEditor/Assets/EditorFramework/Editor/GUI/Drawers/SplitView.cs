using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;
using static EditorFramework.RectExtension;

namespace EditorFramework
{
    public class SplitView : GUIBase
    {
        public SplitType SplitType = SplitType.Vertical;
        public event Action<Rect> FirstArea, Second;
        public Action OnBeginResize, OnEndResize;

        public float SplitSize = 200;
        public float MinSize = 100;
        private bool mResizing;
        public bool Dragging
        {
            get
            {
                return mResizing;
            }
            set
            {
                if(mResizing != value)
                {
                    mResizing = value;
                    if (value)
                    {
                        if (OnBeginResize != null)
                        {
                            OnBeginResize();
                        }
                    }
                    else
                    {
                        if (OnEndResize != null)
                        {
                            OnEndResize();
                        }
                    }
                }
            }
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            var rects = position.Split(SplitType, SplitSize, 4);
            var mid = position.SplitRect(SplitType, SplitSize, 4);
            
            // ×ó±ßÇøÓò
            if(FirstArea!=null)
            {
                FirstArea(rects[0]);
            }
            // ÓÒ±ßÇøÓò
            if (Second != null)
            {
                Second(rects[1]);
            }
            EditorGUI.DrawRect(mid.Zoom(RectExtension.AnchorType.MiddleCenter,-2), Color.gray);
            var e = Event.current;
            if (mid.Contains(e.mousePosition))
            {
                if (SplitType == SplitType.Vertical)
                {
                    EditorGUIUtility.AddCursorRect(mid, MouseCursor.ResizeHorizontal);
                }
                else
                {
                    EditorGUIUtility.AddCursorRect(mid, MouseCursor.ResizeVertical);
                }
            }

            switch (e.type)
            {
                case EventType.MouseDown:
                    if (mid.Contains(e.mousePosition))
                    {
                        Dragging = true;
                    }
                    break;
                case EventType.MouseDrag:
                    if (Dragging)
                    {
                        if (SplitType == SplitType.Vertical)
                        {
                            SplitSize += e.delta.x;
                            SplitSize = Mathf.Clamp(SplitSize, MinSize, position.width - MinSize);
                        }
                        else
                        {
                            SplitSize += e.delta.y;
                            SplitSize = Mathf.Clamp(SplitSize, MinSize, position.height - MinSize);
                        }
                        e.Use();
                    }
                    break;
                case EventType.MouseUp:
                    if (Dragging)
                    {
                        Dragging = false;
                    }
                    break;
            }
        }

        protected override void OnDispose()
        {
            FirstArea = null;
            Second = null;
            OnBeginResize = null;
            OnEndResize = null;
        }
    }
}