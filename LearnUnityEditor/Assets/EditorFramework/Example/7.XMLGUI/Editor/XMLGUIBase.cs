using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml;

namespace EditorFramework
{
    public abstract class XMLGUIBase : GUIBase
    {
        protected T GetAttribute<T>(XmlElement xmlElement, string attributeName)
        {
            var attributeValue = xmlElement.GetAttribute(attributeName);

            if (!string.IsNullOrEmpty(attributeValue))
            {
                T result = default;
                if (attributeValue.TryConvert<T>(out result))
                {
                    return result;
                }
            }
            return default;
        }

        public virtual void ParseXML(XmlElement element, XMLGUI rootXMLGUI)
        {
            Id = GetAttribute<string>(element, "id");
            mPosition = GetAttribute<Rect>(element, "position");
        }
        public string Id { get; set; }


        public void SetPosition(Rect position)
        {
            mPosition = position;
        }
        public void Draw()
        {
            OnGUI(mPosition);
        }
    }
}