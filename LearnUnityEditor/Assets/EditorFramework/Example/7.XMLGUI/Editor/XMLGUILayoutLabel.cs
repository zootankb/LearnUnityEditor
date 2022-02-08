using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILayoutLabel : XMLGUIBase
    {
        public string Text { get; set; }

        public override void ParseXML(XmlElement element, XMLGUI rootXMLGUI)
        {
            base.ParseXML(element, rootXMLGUI);
            Text = element.InnerText;
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            GUILayout.Label(Text);
        }

        protected override void OnDispose()
        {

        }
    }
}