using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorExtensions
{
    /// <summary>
    /// ŒÔÃÂ‘§¿¿
    /// </summary>
    [CustomPreview(typeof(GameObject))]
    public class ObjectPreviewExample:ObjectPreview
    {
        public override bool HasPreviewGUI()
        {
            return true;
        }
        public override void OnPreviewGUI(Rect r, GUIStyle background)
        {
            GUI.Label(r, target.name + "‘§¿¿¡À");
        }
    }
}