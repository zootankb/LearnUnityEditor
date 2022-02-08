using EditorExtensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGUIRuntimeExample : MonoBehaviour
{

    GUIAPI mGUIAPI = new GUIAPI();

    private void OnGUI()
    {
        mGUIAPI.Draw();
    }
}
