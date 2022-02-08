using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorExtensions
{
    /// <summary>
    /// ָ����˭����Ⱦ��CustomPropertyDrawer
    /// </summary>
    [CustomPropertyDrawer(typeof(MyAttribute))]
    public class MyAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.Label(new Rect(position.position, new Vector2(position.width, 20)), "������ʹ�ö�MyAttribute��"+property.intValue);
            EditorGUI.PropertyField(new Rect(position.x, position.y + 40, position.width, position.height - 40), property, label);

        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label) + 40;
        }
    }
}