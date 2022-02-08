using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.EditorTools;

namespace EditorExtensions
{
    /// <summary>
    /// 点击在左上角的Pivot和Local按钮前的设置按钮时有一个弹框列表，这个就是显示在列表里面的内容
    /// 和小手按钮是单选原则
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