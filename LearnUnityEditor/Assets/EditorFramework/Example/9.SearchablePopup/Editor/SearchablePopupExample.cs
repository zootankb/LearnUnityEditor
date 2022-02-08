using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(9)]
    public class SearchablePopupExample : EditorWindow
    {

        private DayOfWeek mValue;

        private void OnGUI()
        {
            mValue = (DayOfWeek)EditorGUILayout.EnumPopup("DayOfWeek", mValue);
            var rect = GUILayoutUtility.GetRect(200, 200);
            if(GUI.Button(rect, "Change\nthe\nDayOfWeek"))
            {
                SearchablePopup.Show(rect, Enum.GetNames(typeof(DayOfWeek)), (int)mValue, OnValueChanged);
            }
        }

        private void OnValueChanged(int arg1, string arg2)
        {
            mValue = (DayOfWeek)arg1;
            Repaint();
        }
    }
}