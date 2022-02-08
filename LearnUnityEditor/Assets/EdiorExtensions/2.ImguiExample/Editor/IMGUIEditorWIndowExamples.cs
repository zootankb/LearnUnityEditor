using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace EditorExtensions
{
    public class IMGUIEditorWIndowExamples : EditorWindow
    {
        [MenuItem("EditorExtensions/02.IMGUI/01.GUILayoutExample")]
        static void OpenGUILayoutExample()
        {
            GetWindow<IMGUIEditorWIndowExamples>().Show();
        }

        public enum APIMode
        {
            GUILayout,
            GUI,
            EditorGUI,
            EditorGUILayout,
        }

        private enum PageId
        {
            Basic,
            Enabled,
            Rotate,
            Scale,
            Color,
        }

        private APIMode mCurrentGUIAPIModel = APIMode.GUILayout;

        private PageId mCuerrentPageId = PageId.Basic;

        private GUILayoutAPI mGUILayoutAPI = new GUILayoutAPI();
        private GUIAPI mGUIAPI = new GUIAPI();
        private EditorGUIAPI mEditorGUIApi = new EditorGUIAPI();
        private EditorGUILayoutAPI mEditorGUILayoutAPI = new EditorGUILayoutAPI();

        private void OnGUI()
        {
            mCurrentGUIAPIModel = (APIMode)GUILayout.Toolbar((int)mCurrentGUIAPIModel, Enum.GetNames(typeof(APIMode)));
            mCuerrentPageId = (PageId)GUILayout.Toolbar((int)mCuerrentPageId, Enum.GetNames(typeof(PageId)));
            if (mCuerrentPageId == PageId.Basic)
            {
                Basic();
            }
            if (mCuerrentPageId == PageId.Enabled)
            {
                Enabled();
            }
            if (mCuerrentPageId == PageId.Rotate)
            {
                Rotate();
            }
            if (mCuerrentPageId == PageId.Scale)
            {
                Scale();
            }
            else if (mCuerrentPageId == PageId.Color)
            {
                Color();
            }
        }

        # region Basic

        private void Basic()
        {
            if(mCurrentGUIAPIModel == APIMode.GUILayout)
            {
                mGUILayoutAPI.Draw();
            }
            else if(mCurrentGUIAPIModel == APIMode.GUI)
            {
                mGUIAPI.Draw();
            }
            else if (mCurrentGUIAPIModel == APIMode.EditorGUI)
            {
                mEditorGUIApi.Draw();
            }
            else if (mCurrentGUIAPIModel == APIMode.EditorGUILayout)
            {
                mEditorGUILayoutAPI.Draw();
            }
        }

        #endregion


        #region Color

        private bool mOpenColorEffect = false;
        private void Color()
        {
            mOpenColorEffect = GUILayout.Toggle(mOpenColorEffect, "打开颜色特效");
            if (mOpenColorEffect)
            {
                GUI.color = UnityEngine.Color.yellow;
            }
            Basic();
        }

        #endregion

        #region Scale

        private bool mOpenScaleEffect = false;
        private void Scale()
        {
            mOpenScaleEffect = GUILayout.Toggle(mOpenScaleEffect, "开启缩放效果");
            if (mOpenScaleEffect)
            {
                GUIUtility.ScaleAroundPivot(Vector2.one * 0.5f, Vector2.one * 200);
            }
            Basic();
        }

        #endregion

        #region Rotate

        private bool mOpenRotateEffect = false;

        private void Rotate()
        {
            mOpenRotateEffect = GUILayout.Toggle(mOpenRotateEffect, "打开旋转效果");
            if (mOpenRotateEffect)
            {
                GUIUtility.RotateAroundPivot(45, Vector2.one * 200);
            }
            Basic();
        }

        #endregion

        #region Enabled

        private bool mEnableInteeractive = true;

        private void Enabled()
        {
            mEnableInteeractive = GUILayout.Toggle(mEnableInteeractive, "是否可交互");
            if (GUI.enabled != mEnableInteeractive)
            {
                GUI.enabled = mEnableInteeractive;
            }
            Basic();
        }

        #endregion

        
    }
}