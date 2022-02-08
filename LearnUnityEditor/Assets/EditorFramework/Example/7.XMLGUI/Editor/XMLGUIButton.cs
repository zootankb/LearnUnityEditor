using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Xml;

namespace EditorFramework
{
    public class XMLGUIButton : XMLGUIBase
    {

        public string Text;

        public event Action OnClick;
        public override void ParseXML(XmlElement element, XMLGUI rootXMLGUI)
        {
            base.ParseXML(element, rootXMLGUI);
            Text = element.InnerText;
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            if (GUI.Button(position,Text))
            {
                OnClick?.Invoke();
            }
        }


        protected override void OnDispose()
        {

        }
    }
}
