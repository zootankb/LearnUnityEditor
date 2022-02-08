using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class GenericMenuExample :EditorWindow

    {
        [MenuItem("EditorExtensions/08.GenericMenu/Open")]
        static void Open()
        {
            GetWindow<GenericMenuExample>().Show();
        }

        private void OnGUI()
        {
            var e = Event.current;
            if (null != e)
            {
               if( e.type==EventType.MouseDown && e.button == 1)
                {
                    var genericMenu = new GenericMenu();
                    genericMenu.AddItem(new GUIContent("����1"), false, () => { Debug.Log("����1"); });
                    genericMenu.AddItem(new GUIContent("���ܺϼ�/����2"), false, () => { Debug.Log("����2"); });
                    genericMenu.AddItem(new GUIContent("���ܺϼ�/����3"), false, () => { Debug.Log("����3"); });
                    genericMenu.AddSeparator("���ܺϼ�/");
                    genericMenu.AddItem(new GUIContent("���ܺϼ�/����4"), false, () => { Debug.Log("����4"); });
                    genericMenu.ShowAsContext();
                }
            }
        }
    }
}