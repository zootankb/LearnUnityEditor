using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    [InitializeOnLoad]
    public class ProjectExample
    {

        const string PATH = "EditorExtensions/02.IMGUI/04.Enable Custom Project";

        private static bool mCustomProjectEnable = false;

        static ProjectExample()
        {
            Menu.SetChecked(PATH, mCustomProjectEnable);
        }

        [MenuItem(PATH)]
        static void Enable()
        {
            if (mCustomProjectEnable)
            {
                mCustomProjectEnable = false;
                UnRegisterProject();
            }
            else
            {
                mCustomProjectEnable = true;
                RegisterProject();
                ProjectWindowUtil.CreateFolder();
            }
            Menu.SetChecked(PATH, mCustomProjectEnable);
            EditorApplication.RepaintProjectWindow();
        }

        static void RegisterProject()
        {
            EditorApplication.projectWindowItemOnGUI += OnProjectGUI;
            EditorApplication.projectChanged += OnProjectChanged;
        }

        private static void OnProjectChanged()
        {
            Debug.Log("project changed");
        }

        private static void OnProjectGUI(string guid, Rect selectionRect)
        {
            try
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var files = Directory.GetFiles(assetPath);
                    var countLabelRect = selectionRect;
                    countLabelRect.x += 100;
                    GUI.Label(countLabelRect, files.Length.ToString());
            }
            catch(Exception e)
            {

            }
        }

        static void UnRegisterProject()
        {
            EditorApplication.projectWindowItemOnGUI -= OnProjectGUI;
            EditorApplication.projectChanged -= OnProjectChanged;
        }
    }
}