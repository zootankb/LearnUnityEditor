using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml;

namespace EditorFramework
{
    [CustomEditorWindow(7)]
    public class XMLGUIExample : EditorWindow
    {
        private const string XMLFilePath = "Assets/EditorFramework/Example/7.XMLGUI/Editor/GUIExample.xml";

        private string mXMLContent;

        public XMLGUI mXmlgui;

        private void OnEnable()
        {
            var xmlFileAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(XMLFilePath);
            mXMLContent = xmlFileAsset.text;

            mXmlgui = new XMLGUI();
            mXmlgui.ReadXML(mXMLContent);

            //mXmlgui.GetGUIBaseById<XMLGUIButton>("loginButton").OnClick += () =>
            //{
            //    Debug.Log("Button Clicked");

            //    mXmlgui.GetGUIBaseById<XMLGUILabel>("label1").Text = "1";
            //    mXmlgui.GetGUIBaseById<XMLGUILabel>("label2").Text = "2";
            //    mXmlgui.GetGUIBaseById<XMLGUILabel>("label3").Text = "3";
            //    mXmlgui.GetGUIBaseById<XMLGUITextField>("username").Text = "凉鞋";
            //    mXmlgui.GetGUIBaseById<XMLGUITextArea>("description").Text = "此课程的作者";
            //};

            mXmlgui.GetGUIBaseById<XMLGUILayoutButton>("loginButton").OnClick += () =>
            {
                Debug.Log("Button Clicked");

                mXmlgui.GetGUIBaseById<XMLGUILayoutLabel>("label1").Text = "1";
                mXmlgui.GetGUIBaseById<XMLGUILayoutLabel>("label2").Text = "2";
                mXmlgui.GetGUIBaseById<XMLGUILayoutLabel>("label3").Text = "3";
            };

        }

        private void OnGUI()
        {
            mXmlgui.Draw();
        }
    }
}