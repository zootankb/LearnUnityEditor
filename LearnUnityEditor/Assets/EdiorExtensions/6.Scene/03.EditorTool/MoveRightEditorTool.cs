using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace EditorExtensions
{
    /// <summary>
    /// ��Scene�������滭ѡ������ķ����ͷ�����Ի����ּ�ͷ������ֻ�������ҵļ�ͷ
    /// </summary>
    [EditorTool("Move Right")]
    public class MoveRightEditorTool:EditorTool
    {
        public override void OnToolGUI(EditorWindow window)
        {
            window.ShowNotification(new GUIContent("Move Right"));
            EditorGUI.BeginChangeCheck();
            Vector3 position = Tools.handlePosition;

            using(new Handles.DrawingScope(Color.green))
            {
                position = Handles.Slider(position, Vector3.right);
            }
            if (EditorGUI.EndChangeCheck())
            {
                Vector3 delta = position - Tools.handlePosition;
                Undo.RecordObjects(Selection.transforms, "Move Platforms");
                foreach (var transfrom in Selection.transforms)
                {
                    transfrom.position += delta;
                }
            }
        }
    }
}