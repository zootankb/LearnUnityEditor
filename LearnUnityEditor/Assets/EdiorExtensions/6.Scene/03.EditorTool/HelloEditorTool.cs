using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.EditorTools;

namespace EditorExtensions
{
    /// <summary>
    /// ��������Ͻǵ�Pivot��Local��ťǰ�����ð�ťʱ��һ�������б����������ʾ���б����������
    /// ��С�ְ�ť�ǵ�ѡԭ��
    /// </summary>
    [EditorTool("Hello EditorTool")]
    public class HelloEditorTool : EditorTool
    {
        public override void OnToolGUI(EditorWindow window)
        {
            window.ShowNotification(new GUIContent("Hello EditorTool"));

            Handles.BeginGUI();
            {
                if(GUILayout.Button("Hello EditorTool"))
                {
                    Debug.Log("Hello EditorTool");
                }
            }
            Handles.EndGUI();

        }


    }
}