using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public abstract class XMLGUIContainerBase : XMLGUIBase
    {
        private XMLGUI mXmlgui = new XMLGUI();
        public XMLGUI XMLGUI
        {
            get
            {
                return mXmlgui;
            }
        }

        public override void ParseXML(XmlElement element, XMLGUI rootXMLGUI)
        {
            base.ParseXML(element, rootXMLGUI);

            mXmlgui.ChildElements2GUIBases(element, rootXMLGUI);
        }

        protected override void OnDispose()
        {

        }
    }
}