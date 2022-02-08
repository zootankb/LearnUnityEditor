using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(10)]
    public class MenuTreeExample : EditorWindow
    {
        private MenuTree mMenuTree;

        private void OnEnable()
        {
            mMenuTree = new MenuTree();
            mMenuTree.OnCurrentChange += OnCurrentChange;
            mMenuTree.ReadTree(new List<string>()
            {
                "1",
                "1/1/1",
                "1/1/2",
                "1/1/3",
                "1/2/1",
                "1/2/2",
                "1/3/1",
                "2",
                "2/1/1",
                "2/1/2",
                "2/1/3",
                "2/2/1",
                "2/2/2",
                "2/3/1",
            });
        }

        private void OnCurrentChange(string obj)
        {
            Debug.Log("Select: "+obj);
        }

        private void OnGUI()
        {
            mMenuTree.OnGUI(EditorGUILayout.GetControlRect(GUILayout.Height(400), GUILayout.Width(200)));
        }

    }
}