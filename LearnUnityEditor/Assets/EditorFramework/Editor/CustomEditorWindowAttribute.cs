using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
    public class CustomEditorWindowAttribute : Attribute
    {
        public int RenderOrder { get; private set; }

        public CustomEditorWindowAttribute(int order = -1)
        {
            RenderOrder = order;
        }
    }
}