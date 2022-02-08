using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;

namespace EditorFramework
{
    [CustomEditorWindow(3)]
    public class TypeExExample : EditorWindow
    {
        public class DescriptionBase
        {
            public virtual string Description { get; set; }
        }

        [MyDesc("TypeB")]
        public class MyDescriptionB: DescriptionBase
        {
            public override string Description { get; set; } = "这是一个描述B";
        }

        public class MyDescAttribute : Attribute
        {
            public string Type;

            public MyDescAttribute(string type = "")
            {
                Type = type;
            }
        }

        private IEnumerable<Type> mDescritionTypes;
        private IEnumerable<Type> mDescritionTypesWithAttribute;
        private void OnEnable()
        {
            mDescritionTypes = typeof(DescriptionBase).GetSubTypesInAssemblies();
            mDescritionTypesWithAttribute= typeof(DescriptionBase).GetSubTypesWithClassAttributeInAssemblies<MyDescAttribute>();
        }

        private void OnGUI()
        {
            GUILayout.Label("Types");
            foreach (var descritionType in mDescritionTypes)
            {
                GUILayout.BeginHorizontal("Box");
                {
                    GUILayout.Label(descritionType.Name);
                }
                GUILayout.EndHorizontal();
                
            }
            GUILayout.Label("With Attribute");
            foreach (var descritionType in mDescritionTypesWithAttribute)
            {
                GUILayout.BeginHorizontal("Box");
                {
                    GUILayout.Label(descritionType.Name);
                    GUILayout.Label(descritionType.GetCustomAttribute<MyDescAttribute>().Type);
                }
                GUILayout.EndHorizontal();
            }
        }
    }
}