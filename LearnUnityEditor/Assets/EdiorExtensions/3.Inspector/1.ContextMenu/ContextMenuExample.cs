using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenuExample : MonoBehaviour
{

    [ContextMenu("Hello ContextMenu")]
    void HelloContextMenu()
    {
        Debug.Log("Hello ContextMenu Clicked");
    }

    [SerializeField]
    [ContextMenuItem("Print Value", "HelloContextMenuItem")]
    private string mContextMenuItemValue;

    private void HelloContextMenuItem()
    {
        Debug.Log(mContextMenuItemValue);
    }

#if UNITY_EDITOR
    private const string mFindSriptPath = "CONTEXT/MonoBehaviour/FindScript";

    [UnityEditor.MenuItem(mFindSriptPath)]
    static void FindScript(UnityEditor.MenuCommand command)
    {
        UnityEditor.Selection.activeObject = UnityEditor.MonoScript.FromMonoBehaviour(command.context as MonoBehaviour);
    }

    private const string mCameraScritPath = "CONTEXT/Camera/LogSelf";

    [UnityEditor.MenuItem(mCameraScritPath)]
    static void LogSelf(UnityEditor.MenuCommand command)
    {
        Debug.Log(command.context);
    }
#endif
}
