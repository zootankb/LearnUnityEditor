using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml;

namespace EditorFramework
{
    public class XMLGUILabel : XMLGUIBase
    {
        public string Text;
        public override void ParseXML(XmlElement element, XMLGUI rootXMLGUI)
        {
            base.ParseXML(element, rootXMLGUI);
            Text = element.InnerText;
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            GUI.Label(position,Text);
        }

        protected override void OnDispose()
        {

        }
    }
}