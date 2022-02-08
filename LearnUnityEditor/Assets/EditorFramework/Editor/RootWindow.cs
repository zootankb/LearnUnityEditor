using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorFramework
{
    public class RootWindow : EditorWindow
    {
        [MenuItem("EditorFramework/Open")]
        static void Open()
        {
            GetWindow<RootWindow>().Show();
        }

        IEnumerable<Type> mEditorWindowTypes;
        Vector2 mScrollviewPos = Vector2.zero;

        private void OnEnable()
        {
            mEditorWindowTypes = typeof(EditorWindow).GetSubTypesWithClassAttributeInAssemblies<CustomEditorWindowAttribute>()
                .OrderBy(type=>type.GetCustomAttribute<CustomEditorWindowAttribute>().RenderOrder);
        }

        private void OnGUI()
        {
            mScrollviewPos = GUILayout.BeginScrollView(mScrollviewPos);
            {
                foreach (var editorWindowType in mEditorWindowTypes)
                {
                    GUILayout.BeginHorizontal("Box");
                    {
                        GUILayout.Label(editorWindowType.Name);
                        if (GUILayout.Button("Open", GUILayout.Width(80)))
                        {
                            GetWindow(editorWindowType).Show();
                        }
                    }
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndScrollView();
        }
    }
}