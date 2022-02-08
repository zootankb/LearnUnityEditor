using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

namespace EditorExtensions
{
    /// <summary>
    /// 此脚本的东西只能在Editor下面运行
    /// </summary>
    [InitializeOnLoad] // 编译后调用一次，场景运行的时候也加载一次
    public class EditorEventAttributeExample
    {
        static EditorEventAttributeExample()
        {
            Debug.Log("InitializeOnLoad EditorEventAttributeExample");
        }

        [InitializeOnLoadMethod] // 编译后调用一次，场景运行的时候也加载一次
        static void InitializeOnLoadMethod()
        {
            Debug.Log("InitializeOnLoadMethod");
        }

        [RuntimeInitializeOnLoadMethod] // 运行游戏时运行一次
        static void RuntimeInitializeOnLoadMethod()
        {
            Debug.Log("RuntimeInitializeOnLoadMethod");
        }

        [DidReloadScripts()] // 编译后运行一次
        static void OnScriptReload()
        {
            Debug.Log("脚本加载完毕");
        }

        [PostProcessScene] // 运行时调用一次
        static void OnPostProcessScene()
        {
            Debug.Log("OnPostProcessScene");
        }

        [PostProcessBuild] // Build完成后调用一次
        static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
        {
            Debug.Log($"OnPostProcessBuild=>{target}, {pathToBuiltProject}");
        }

        [OnOpenAsset(1)]
        public static bool OpenAsset1(int instanceID,int line)
        {
            string name = EditorUtility.InstanceIDToObject(instanceID).name;
            Debug.Log("Open Asset step:1 (" + name + ") ");
            return false;
        }

        [OnOpenAsset(2)] // 打开资源时调用，由unity本身打开返回true，由外部工具打开返回false
        public static bool OpenAsset2(int instanceID, int line)
        {
            string name = EditorUtility.InstanceIDToObject(instanceID).name;
            Debug.Log("Open Asset step:2 (" + name + ") ");
            return false;
        }
    }
}