using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml;
using System;

namespace EditorFramework
{
    /// <summary>
    /// XMLµÄ¹ÜÀí
    /// </summary>
    public class XMLGUI
    {
        private List<XMLGUIBase> mGUIBases = new List<XMLGUIBase>();
        private Dictionary<string, XMLGUIBase> mGUIBaseForId = new Dictionary<string, XMLGUIBase>();

        public void Draw()
        {
            foreach (var xmlguiBase in mGUIBases)
            {
                xmlguiBase.Draw();
            }
        }

        public T GetGUIBaseById<T>(string id)where T : XMLGUIBase
        {
            XMLGUIBase t = default;
            if (mGUIBaseForId.TryGetValue(id,out t))
            {
                return t as T;
            }
            else
            {
                return default;
            }
        }

        Dictionary<string, Func<XMLGUIBase>> mFactoryForGUIBaseNames = new Dictionary<string, Func<XMLGUIBase>>()
        {
            {"Label", ()=>new XMLGUILabel() },
            {"TextField", ()=>new XMLGUITextField() },
            {"TextArea", ()=>new XMLGUITextArea() },
            {"Button", ()=>new XMLGUIButton() },
            {"LayoutLabel", ()=>new XMLGUILayoutLabel() },
            {"LayoutButton", ()=>new XMLGUILayoutButton() },
            {"LayoutHorizontal", ()=>new XMLGUILayoutHorizontal() },
            {"LayoutVertical", ()=>new XMLGUILayoutVertical() },
        };
        public void ReadXML(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var rootNode = doc.SelectSingleNode("GUI");

            ChildElements2GUIBases(rootNode as XmlElement, this);
        }

        public void ChildElements2GUIBases(XmlElement rootElement, XMLGUI rootXMLGUI)
        {
            XMLGUIBase guibase = default;
            Func<XMLGUIBase> xmlGUIBaseFactory = default;
            foreach (XmlElement rootNodeChildNode in rootElement.ChildNodes)
            {
                if (mFactoryForGUIBaseNames.TryGetValue(rootNodeChildNode.Name, out xmlGUIBaseFactory))
                {
                    guibase = xmlGUIBaseFactory();
                    guibase.ParseXML(rootNodeChildNode, rootXMLGUI);
                    AddGUIBase(guibase, rootXMLGUI);
                }
            }
        }

        private void AddGUIBase(XMLGUIBase xmlguibase, XMLGUI rootXMLGUI)
        {
            mGUIBases.Add(xmlguibase);
            if (!string.IsNullOrEmpty(xmlguibase.Id))
            {
                mGUIBaseForId.Add(xmlguibase.Id, xmlguibase);
                if (rootXMLGUI == this)
                {

                }
                else
                {
                    rootXMLGUI.mGUIBaseForId.Add(xmlguibase.Id, xmlguibase);
                }
            }
        }
    }
}
