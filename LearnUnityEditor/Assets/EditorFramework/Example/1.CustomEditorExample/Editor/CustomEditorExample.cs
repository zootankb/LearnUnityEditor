using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindowAttribute(1)]
    public class CustomEditorExample : EditorWindow
    {
        private void OnGUI()
        {
            GUILayout.Label("�����Զ���Ĵ���");
        }
    }
}