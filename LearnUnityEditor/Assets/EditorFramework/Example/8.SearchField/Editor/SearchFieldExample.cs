using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(8)]
    public class SearchFieldExample : EditorWindow
    {
        private SearchField mSearchField;
        private string mSearchContent = string.Empty;
        private string[] mSearchableContents = new string[] { "mode1", "mode2", "mode3" };

        private void OnEnable()
        {
            mSearchField = new SearchField(mSearchContent, mSearchableContents, 0);
            mSearchField.OnValueChanged += SearchFieldOnValueChanged;
            mSearchField.OnModeChanged += SearchFieldOnModeChanged;
            mSearchField.OnEndEdit += SearchFieldOnEndEdit;
        }

        private void SearchFieldOnEndEdit(string obj)
        {
            Debug.Log(obj);
        }

        private void SearchFieldOnModeChanged(int obj)
        {
            Debug.Log(obj);
        }

        private void SearchFieldOnValueChanged(string obj)
        {
            Debug.Log(obj);
        }

        private void OnGUI()
        {
            GUILayout.Label("SearchField");
            mSearchField.OnGUI(EditorGUILayout.GetControlRect(GUILayout.Height(20)));
        }
    }
}