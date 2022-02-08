using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorFramework
{
    public class FolderField : GUIBase
    {
        public FolderField(string path = "Assets", string folder = "Assets", string title = "Select Folder", string defaultName = "")
        {
            mPath = path;
            Title = title;
            Folder = folder;
            DefaultName = defaultName;
        }

        protected string mPath;
        public string Path => mPath;
        public string Title;
        public string Folder;
        public string DefaultName;

        public void SetPath(string path)
        {
            mPath = path;
        }

        public override void OnGUI(Rect position)
        {
            var rects = position.VerticalSplit(position.width - 30);
            var leftRect = rects[0];
            var rightRect = rects[1];

            var preValid = GUI.enabled;
            GUI.enabled = false;
            EditorGUI.TextField(leftRect, mPath);
            GUI.enabled = preValid;

            if (GUI.Button(rightRect, GUIContents.Folder))
            {
                var path = EditorUtility.OpenFolderPanel(Title, Folder, DefaultName);

                if (!string.IsNullOrEmpty(path) && path.IsDirectory())
                {
                    mPath = path.ToAssetsPath();
                }
            }

            var dragInfo = DragAndDropTool.Drag(Event.current, leftRect);
            if (dragInfo.EnterArea && dragInfo.Complete && !dragInfo.Dragging && dragInfo.Paths[0].IsDirectory())
            {
                mPath = dragInfo.Paths[0];
            }
        }


        protected override void OnDispose()
        {

        }
    }
}