using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;

namespace EditorExtensions
{
    public class ReorderableListExample : EditorWindow
    {
        [MenuItem("EditorExtensions/06.ReorderableList/Open")]
        static void Open()
        {
            GetWindow<ReorderableListExample>().Show();
        }

        private ReorderableList mList;
        private List<Vector2> mData = new List<Vector2>();

        private void OnEnable()
        {
            mList = new ReorderableList(mData, typeof(Vector2));
            mList.elementHeight = 30;
            mList.drawHeaderCallback += DrawHeader;
            mList.drawNoneElementCallback += DrawNoneElement;
            mList.drawElementCallback += DrawElement;
            mList.drawElementBackgroundCallback += DrawElementBG;
        }

        private void DrawElementBG(Rect rect, int index, bool isActive, bool isFocused)
        {
            GUI.DrawTexture(rect, Texture2D.whiteTexture);

        }

        private void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            mData[index] = EditorGUI.Vector2Field(rect, "", mData[index]);
        }

        private void DrawNoneElement(Rect rect)
        {

        }

        private void DrawHeader(Rect rect)
        {
            GUI.Box(rect, "header");
        }

        private void OnGUI()
        {
            mList.DoLayoutList();
        }
    }
}