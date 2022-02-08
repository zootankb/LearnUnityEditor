using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorExtensions
{
    [CustomEditor(typeof(CustomEditorExample))]
    public class CustomEditorExampleInspector : Editor
    {
        CustomEditorExample mTarget
        {
            get
            {
                return target as CustomEditorExample;
            }
        }
        public override void OnInspectorGUI()
        {
            var hpRect = GUILayoutUtility.GetRect(18, 18, "TextField");
            EditorGUI.ProgressBar(hpRect, mTarget.HP,"HP");

            var rangeRect = GUILayoutUtility.GetRect(18, 18, "TextField");
            EditorGUI.ProgressBar(rangeRect, mTarget.Range, "Range");

            EditorGUILayout.BeginHorizontal("box");
            {
                EditorGUILayout.LabelField("½ÇÉ«Ãû",GUILayout.Width(200));
                mTarget.RoleName = EditorGUILayout.TextArea(mTarget.RoleName);
            }
            EditorGUILayout.EndHorizontal();

            var otherObjPrperty = serializedObject.FindProperty("OtherObj");
            EditorGUILayout.ObjectField(otherObjPrperty);
            serializedObject.ApplyModifiedProperties();
        }
    }
}