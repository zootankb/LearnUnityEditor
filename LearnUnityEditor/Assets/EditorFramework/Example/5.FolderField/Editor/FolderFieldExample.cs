using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace EditorFramework
{
    [CustomEditorWindow(5)]
    public class FolderFieldExample : EditorWindow
    {
        private FolderField folderField;


        private void OnEnable()
        {
            folderField = new FolderField();
        }

        private void OnGUI()
        {
            GUILayout.Label("Folder Field");
            var rect = EditorGUILayout.GetControlRect(GUILayout.Height(20));
            folderField.OnGUI(rect);
        }
    }
}