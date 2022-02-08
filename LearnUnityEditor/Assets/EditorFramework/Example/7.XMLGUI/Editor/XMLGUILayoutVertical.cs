using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILayoutVertical : XMLGUIContainerBase
    {
        public bool Box { get; set; }
        public override void ParseXML(XmlElement element, XMLGUI rootXMLGUI)
        {
            base.ParseXML(element, rootXMLGUI);

            Box = GetAttribute<bool>(element, "box");
        }
        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            if (Box)
            {
                GUILayout.BeginVertical("box");
            }
            else
            {
                GUILayout.BeginVertical();
            }
            
            {
                XMLGUI.Draw();
            }
            GUILayout.EndVertical();

        }
        protected override void OnDispose()
        {

        }
    }
}