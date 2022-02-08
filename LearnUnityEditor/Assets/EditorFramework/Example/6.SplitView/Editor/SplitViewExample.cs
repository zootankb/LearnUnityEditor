using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorFramework
{
    [CustomEditorWindow(6)]
    public class SplitViewExample:EditorWindow
    {
        private SplitView mSplitView;

        private void OnEnable()
        {
            mSplitView = new SplitView();
            //mSplitView.SplitType = RectExtension.SplitType.Horizontal;
            mSplitView.FirstArea += MSplitView_FirstArea;
            mSplitView.Second += MSplitView_Second;
        }

        private void MSplitView_FirstArea(Rect obj)
        {
            obj.DrawOutline(Color.green);
            GUI.Box(obj, "First");
        }

        private void MSplitView_Second(Rect obj)
        {
            obj.DrawOutline(Color.green);
            GUI.Box(obj, "Second");
        }

        private void OnGUI()
        {
            mSplitView.OnGUI(this.LocalPosition().Zoom( RectExtension.AnchorType.MiddleCenter, -10));
        }
    }
}