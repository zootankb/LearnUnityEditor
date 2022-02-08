using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorExtensions
{
    public class EditorUtilityExample : EditorWindow
    {
        [MenuItem("EditorExtensions/11.EditorUtility/Open")]
        static void Open()
        {
            GetWindow<EditorUtilityExample>().Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("DisplayProgressBar"))
            {
                EditorUtility.DisplayProgressBar("DisplayProgressBar", "info", 0.1f);
            }
            if (GUILayout.Button("ClearProgressBar"))
            {
                EditorUtility.ClearProgressBar();
            }
            if (GUILayout.Button("DisplayDialog"))
            {
                Debug.Log(EditorUtility.DisplayDialog("DisplayDialog", "message", "ok", "cancel"));
            }

            if (GUILayout.Button("Beep"))
            {
                EditorApplication.Beep();
            }
            if (GUILayout.Button("EnterPlaymode"))
            {
                EditorApplication.EnterPlaymode();
            }
            if (GUILayout.Button("ExitPlaymode"))
            {
                EditorApplication.ExitPlaymode();
            }
            if (GUILayout.Button("Step"))
            {
                EditorApplication.Step();
            }
        }
    }
}