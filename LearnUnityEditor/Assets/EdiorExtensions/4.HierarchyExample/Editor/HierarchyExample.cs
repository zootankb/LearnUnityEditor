using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace EditorExtensions
{
    [InitializeOnLoad]
    public static class HierarchyExample
    {
        private static bool mCustomHierarchyEnable = false;

        private const string PATH = "EditorExtensions/02.IMGUI/03.Enable Custom Hierarchy";
        static HierarchyExample()
        {
            Menu.SetChecked(PATH, mCustomHierarchyEnable);
        }

        [MenuItem(PATH)]
        static void EnableCustomHierarchy()
        {
            if (mCustomHierarchyEnable)
            {
                mCustomHierarchyEnable = false;
                UnregisterHierarchy();
            }
            else
            {
                mCustomHierarchyEnable = true;
                RegisterHierarchy();
            }
            Menu.SetChecked(PATH, mCustomHierarchyEnable);
            EditorApplication.RepaintHierarchyWindow();
        }

        private static void RegisterHierarchy()
        {
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
            EditorApplication.hierarchyChanged += OnHierarchyChanged;
        }

        private static void OnHierarchyChanged()
        {
            //Debug.Log("Changed");
        }

        private static void OnHierarchyGUI(int instanceid,Rect selectionrect)
        {
            var obj = EditorUtility.InstanceIDToObject(instanceid) as GameObject;

            if (obj != null)
            {
                var tarLabelRect = selectionrect;
                tarLabelRect.x += tarLabelRect.width / 2;
                GUI.Label(tarLabelRect, obj?.tag);

                var layerLabelRect = tarLabelRect;
                layerLabelRect.x += 100;
                GUI.Label(layerLabelRect, LayerMask.LayerToName(obj.layer));
            }

        }

        static void UnregisterHierarchy()
        {
            EditorApplication.hierarchyWindowItemOnGUI -= OnHierarchyGUI;
            EditorApplication.hierarchyChanged -= OnHierarchyChanged;
        }
    }
}