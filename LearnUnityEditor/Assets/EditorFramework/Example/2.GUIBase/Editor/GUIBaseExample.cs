using EditorFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    [CustomEditorWindow(2)]
    public class GUIBaseExample:EditorWindow
    {
        public class Label:GUIBase
        {
            public Label(string text)
            {
                mText = text;
            }

            private string mText = string.Empty;

            public override void OnGUI(Rect position)
            {
                GUILayout.Label(mText);
            }

            protected override void OnDispose()
            {
                mText = string.Empty;
            }
        }

        private Label mLabel1 = new Label("123");
        private Label mLabel2 = new Label("456");

        private void OnGUI()
        {
            mLabel1.OnGUI(default);
            mLabel2.OnGUI(default);
        }
    }
}