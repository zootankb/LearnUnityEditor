using System;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EditorExtensions
{
    public class GUIContentAndGUIStyleExample:EditorWindow
    {
        [MenuItem("EditorExtensions/02.IMGUI/02.GUIContentAndGUIStyle")]
        static void Open()
        {
            GetWindow<GUIContentAndGUIStyleExample>().Show();
        }

        public enum Mode
        {
            GUIContent,
            GUIStyle,
        }

        private int mToolbarIndex;

        private GUIStyle mBoxStyle = "box";

        private Lazy<GUIStyle> mFontStyle = new Lazy<GUIStyle>(() =>
        {
            var retStyle = new GUIStyle("label");
            retStyle.fontSize = 30;
            retStyle.fontStyle = FontStyle.BoldAndItalic;
            retStyle.normal.textColor = Color.green;
            retStyle.hover.textColor = Color.blue;
            retStyle.focused.textColor = Color.red;
            retStyle.active.textColor = Color.cyan;
            retStyle.normal.background = Texture2D.whiteTexture;
            return retStyle;
        });
        private Lazy<GUIStyle> mButtonStyle = new Lazy<GUIStyle>(() =>
        {
            var retStyle = new GUIStyle(GUI.skin.button);
            retStyle.fontSize = 30;
            retStyle.fontStyle = FontStyle.BoldAndItalic;
            retStyle.normal.textColor = Color.green;
            retStyle.hover.textColor = Color.blue;
            retStyle.focused.textColor = Color.red;
            retStyle.active.textColor = Color.cyan;
            retStyle.normal.background = Texture2D.whiteTexture;
            return retStyle;
        });

        private void OnEnable()
        {

        }

        private void OnGUI()
        {
            mToolbarIndex = GUILayout.Toolbar(mToolbarIndex, Enum.GetNames(typeof(Mode)));

            if(mToolbarIndex == (int)Mode.GUIContent)
            {
                GUILayout.Label("把鼠标放在我身上");
                GUILayout.Label(new GUIContent( "把鼠标放在我身上"));
                GUILayout.Label(new GUIContent( "把鼠标放在我身上", "已经放好了"));
                GUILayout.Label(new GUIContent( "把鼠标放在我身上",Texture2D.whiteTexture));
                GUILayout.Label(new GUIContent( "把鼠标放在我身上",Texture2D.whiteTexture, "已经放好了"));
            }
            else if (mToolbarIndex == (int)Mode.GUIStyle)
            {
                GUILayout.Label("Style of box", mFontStyle.Value);
                GUILayout.Label("Style of box default");
                GUILayout.Label("Style of box", mBoxStyle);
                if(GUILayout.Button("Button Style", mButtonStyle.Value))
                {
                    Debug.Log("ButtonStyle");
                }
            }
        }
    }
}
