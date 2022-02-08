using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
    public abstract class GUIBase:IDisposable
    {
        protected bool mDisposed { get; private set; }

        protected Rect mPosition { get; set; }


        public virtual void OnGUI(Rect position)
        {
            mPosition = position;
        }

        protected abstract void OnDispose();

        public void Dispose()
        {
            if(mDisposed)
            {
                return;
            }
            mDisposed = true;
        }

    }
}