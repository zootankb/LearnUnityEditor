using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILayoutButton : XMLGUIBase
    {
        public string Label { get; set; }

        public override void ParseXML(XmlElement element, XMLGUI rootXMLGUI)
        {
            base.ParseXML(element, rootXMLGUI);
            Label = element.InnerText;
        }
        public event Action OnClick;

        public override void OnGUI(Rect position)
        {
            if (GUILayout.Button(Label))
            {
                if (OnClick != null)
                {
                    OnClick();
                }
            }
        }

        protected override void OnDispose()
        {
        }
    }
}