using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EditorExtensions
{
    public class GUILayoutAPI
    {
        #region Basic

        private string mTextFieldValue = string.Empty;
        private string mTextAreaValue = string.Empty;
        private string mPasswordFieldValue = string.Empty;
        private Vector2 mScrollPosition = Vector2.zero;
        private float mSliderValue = 0;
        private int mToolbarIndex = 0;
        private bool mToggleValue = false;
        private int mSelectedGridIndex = 0;


        public void Draw()
        {
            GUILayout.Label("Label: Hello IMGUI");
            mScrollPosition = GUILayout.BeginScrollView(mScrollPosition);
            {
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("TextField");
                    mTextFieldValue = GUILayout.TextField(mTextFieldValue);
                }
                GUILayout.EndHorizontal();
                GUILayout.Space(100);
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("TextArea");
                    mTextAreaValue = GUILayout.TextArea(mTextAreaValue);
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("PasswordField");
                    mPasswordFieldValue = GUILayout.PasswordField(mPasswordFieldValue, '*');
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Button");
                    if (GUILayout.Button("Button", GUILayout.ExpandWidth(true)))
                    {
                        Debug.Log("Button Clicked");
                    }
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("RepeatButton");
                    if (GUILayout.RepeatButton("RepeatButton", GUILayout.ExpandWidth(true)))
                    {
                        Debug.Log("RepeatButton Clicked");
                    }
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Box");
                    GUILayout.Box("AutoLayout Box");
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("HorizontalSlider");
                    mSliderValue = GUILayout.HorizontalSlider(mSliderValue, 0, 100);
                }
                GUILayout.EndHorizontal();

                GUILayout.Label("VerticalSlider");
                mSliderValue = GUILayout.VerticalSlider(mSliderValue, 0, 100);

                GUILayout.BeginArea(new Rect(0, 0, 100, 100));
                {
                    GUI.Label(new Rect(0, 0, 20, 20), "Text");
                }
                GUILayout.EndArea();

                GUILayout.Window(1, new Rect(0, 0, 100, 100), (id) =>
                {

                }, "2");

                mToolbarIndex = GUILayout.Toolbar(mToolbarIndex, new[] { "1", "2", "3", "4" });
                mToggleValue = GUILayout.Toggle(mToggleValue, "Toggle");

                mSelectedGridIndex = GUILayout.SelectionGrid(mSelectedGridIndex, new[] { "1", "2", "3", "4" }, 3);
            }
            GUILayout.EndScrollView();
        }

        #endregion Basic
    }
}
