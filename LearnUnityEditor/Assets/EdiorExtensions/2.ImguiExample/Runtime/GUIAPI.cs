using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EditorExtensions
{
    public class GUIAPI
    {

        private Rect mLabelRect = new Rect(20, 60, 200, 20);
        private Rect mTextFieldRect = new Rect(20, 90, 200, 20);
        private Rect mTextAreaRect = new Rect(20, 120, 200, 100);
        private Rect mPasswordFieldRect = new Rect(20, 240, 200, 20);
        private Rect mButtonRect = new Rect(20, 270, 200, 20);
        private Rect mRepeatButtonRect = new Rect(20, 300, 200, 20);
        private Rect mToggleRect = new Rect(20, 330, 200, 20);
        private Rect mToolbarRect = new Rect(20, 360, 400, 20);
        private Rect mBoxRect = new Rect(20, 400, 200, 100);
        private Rect mHorizontalSliderRect = new Rect(20, 500, 100, 20);
        private Rect mVerticalSliderRect = new Rect(20, 530, 20, 100);
        private Rect mGroupRect = new Rect(20, 630, 100, 20);
        private Rect mWindowRect = new Rect(20, 660, 100, 100);

        private string mTextFieldValue = string.Empty;
        private string mTextAreaValue = string.Empty;
        private string mPasswordFiledValue = string.Empty;
        private bool mToggleValie = false;
        private int mToolbarValue = 0;
        private float mSliderValue = 0;

        private Vector2 mScrollPos = Vector2.zero;

        public void Draw()
        {
            mScrollPos=GUI.BeginScrollView(new Rect(20, 0, 400, 500), mScrollPos, new Rect(0, 0, 400, 500));

            GUI.Label(mLabelRect, "Hello GUIAPI");
            mTextFieldValue = GUI.TextField(mTextFieldRect, mTextFieldValue);
            mTextAreaValue = GUI.TextArea(mTextAreaRect, mTextAreaValue);
            mPasswordFiledValue = GUI.PasswordField(mPasswordFieldRect, mPasswordFiledValue, '*');

            if(GUI.Button(mButtonRect,"Button Click"))
            {
                Debug.Log("Button Click");
            }
            if (GUI.RepeatButton(mRepeatButtonRect, "RepeatButton Click"))
            {
                Debug.Log("RepeatButton Click");
            }

            mToggleValie = GUI.Toggle(mToggleRect, mToggleValie, "Toggle");

            mToolbarValue = GUI.Toolbar(mToolbarRect, mToolbarValue, new string[] { "1", "2", "3" });

            GUI.Box(mBoxRect, "Box");

            GUI.EndScrollView();

            mSliderValue = GUI.HorizontalSlider(mHorizontalSliderRect, mSliderValue, 0, 1);
            mSliderValue = GUI.VerticalSlider(mVerticalSliderRect, mSliderValue, 0, 1);

            GUI.BeginGroup(mGroupRect, "Group");
            // TODO
            GUI.EndGroup();

            GUI.Window(10, mWindowRect, (mBoxRect) =>
            {

            }, "窗口");
        }
    }
}
