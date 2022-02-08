using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class EditorGUIAPI 
    {
        private Rect mLabelRect = new Rect(10, 60, 200, 20);
        private Rect mTextFieldRect = new Rect(10, 90, 200, 20);
        private Rect mTextAreaRect = new Rect(10, 120, 200, 100);
        private Rect mPasswordFieldRect = new Rect(10, 270, 200, 20);
        private Rect mDropdownButtonRect = new Rect(10, 300, 200, 20);
        private Rect mLinkButtonRect = new Rect(10, 330, 200, 20);
        private Rect mToggleRect = new Rect(10, 360, 200, 20);
        private Rect mToggleLeftRect = new Rect(10, 390, 200, 20);
        private Rect mHelpBoxNoneRect = new Rect(10, 420, 200, 20);
        private Rect mHelpBoxInfoRect = new Rect(10, 450, 200, 20);
        private Rect mHelpBoxWarningRect = new Rect(10, 480, 200, 20);
        private Rect mHelpBoxErrorRect = new Rect(10, 510, 200, 20);
        private Rect mColorFieldRect = new Rect(10, 540, 200, 25);
        private Rect mBoundsFieldRect = new Rect(10, 570, 200, 20);
        private Rect mBoundsIntFieldRect = new Rect(10, 630, 200, 20);
        private Rect mCurveFieldRect = new Rect(10, 690, 200, 20);
        private Rect mDoubleFieldRect = new Rect(10, 720, 200, 20);
        private Rect mDelayedDoubleFieldRect = new Rect(10, 750, 200, 20);
        private Rect mEnumFlagsFieldRect = new Rect(10, 780, 200, 20);
        private Rect mEnumPopFieldRect = new Rect(10, 810, 200, 20);
        private Rect mGraddientFieldRect = new Rect(210, 120, 200, 20);

        private bool mDisabledGroupValue = false;
        private string mTextFiledValue = string.Empty;
        private string mTextAreaValue = string.Empty;
        private string mPasswordFieldValue = string.Empty;
        private bool mToggleValue = false;
        private Color mColorFieldValue = Color.black;
        private Bounds mBoundsFieldValue;
        private BoundsInt mBoundsIntFieldValue;
        private AnimationCurve mAnimationCurveValue = new AnimationCurve();
        private double mDoubleFieldValue; 
        private enum EnumFlagsFieldValue
        {
            A = 1,
            B,
            C,
        }
        private EnumFlagsFieldValue mEnumFlagsFieldValue;
        private bool mFouldOutValue = true;
        private Gradient mGradientValue = new Gradient();

        public void Draw()
        {
            mDisabledGroupValue = EditorGUILayout.Toggle("Open Group", mDisabledGroupValue);

            mFouldOutValue = EditorGUI.Foldout(new Rect(210, 80, 300, 20), mFouldOutValue, "уш╣Ч", true);
            if (mFouldOutValue)
            {
                EditorGUI.BeginDisabledGroup(mDisabledGroupValue == true);
                {
                    EditorGUI.LabelField(mLabelRect, "LabelField");
                    mTextFiledValue = EditorGUI.TextField(mTextFieldRect, mTextFiledValue);
                    mTextAreaValue = EditorGUI.TextArea(mTextAreaRect, mTextAreaValue);
                    mPasswordFieldValue = EditorGUI.PasswordField(mPasswordFieldRect, mPasswordFieldValue);

                    if (EditorGUI.DropdownButton(mDropdownButtonRect, new GUIContent("123"), FocusType.Keyboard))
                    {
                        Debug.Log("DropdownButton Clicked");
                    }

                    if (EditorGUI.LinkButton(mLinkButtonRect, new GUIContent("LinkButton")))
                    {
                        Debug.Log("LinkButton Clicked");
                    }
                    mToggleValue = EditorGUI.Toggle(mToggleRect, mToggleValue);
                    mToggleValue = EditorGUI.ToggleLeft(mToggleLeftRect, "ToggleLeft", mToggleValue);

                    EditorGUI.HelpBox(mHelpBoxNoneRect, "HelpBox", MessageType.None);
                    EditorGUI.HelpBox(mHelpBoxInfoRect, "HelpBox", MessageType.Info);
                    EditorGUI.HelpBox(mHelpBoxWarningRect, "HelpBox", MessageType.Warning);
                    EditorGUI.HelpBox(mHelpBoxErrorRect, "HelpBox", MessageType.Error);

                    mColorFieldValue = EditorGUI.ColorField(mColorFieldRect, mColorFieldValue);
                    mBoundsFieldValue = EditorGUI.BoundsField(mBoundsFieldRect, mBoundsFieldValue);
                    mBoundsIntFieldValue = EditorGUI.BoundsIntField(mBoundsIntFieldRect, mBoundsIntFieldValue);
                    mAnimationCurveValue = EditorGUI.CurveField(mCurveFieldRect, mAnimationCurveValue);
                    mDoubleFieldValue = EditorGUI.DoubleField(mDoubleFieldRect, mDoubleFieldValue);
                    mDoubleFieldValue = EditorGUI.DelayedDoubleField(mDelayedDoubleFieldRect, mDoubleFieldValue);

                    mEnumFlagsFieldValue = (EnumFlagsFieldValue)EditorGUI.EnumFlagsField(mEnumFlagsFieldRect, mEnumFlagsFieldValue);
                    mEnumFlagsFieldValue = (EnumFlagsFieldValue)EditorGUI.EnumPopup(mEnumPopFieldRect, mEnumFlagsFieldValue);

                    mGradientValue = EditorGUI.GradientField(mGraddientFieldRect, mGradientValue);

                }
                EditorGUI.EndDisabledGroup();
            }
        }
    }
}