using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorFramework
{
    [CustomEditorWindow(4)]
    public class DragAndDropToolExample : EditorWindow
    {

        private void OnGUI()
        {
            var rect = new Rect(10, 10, 300, 300);
            GUI.Box(rect, "��קһЩ��������");

            var info = DragAndDropTool.Drag(Event.current, rect);
            if(info.EnterArea && info.Complete && !info.Dragging)
            {
                foreach (var path in info.Paths)
                {
                    Debug.Log(path);
                }
                foreach (var objectReference in info.ObjectReferences)
                {
                    Debug.Log(objectReference);
                }
            }
        }
    }
}