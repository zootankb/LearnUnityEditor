using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

namespace EditorExtensions
{
    /// <summary>
    /// �˽ű��Ķ���ֻ����Editor��������
    /// </summary>
    [InitializeOnLoad] // ��������һ�Σ��������е�ʱ��Ҳ����һ��
    public class EditorEventAttributeExample
    {
        static EditorEventAttributeExample()
        {
            Debug.Log("InitializeOnLoad EditorEventAttributeExample");
        }

        [InitializeOnLoadMethod] // ��������һ�Σ��������е�ʱ��Ҳ����һ��
        static void InitializeOnLoadMethod()
        {
            Debug.Log("InitializeOnLoadMethod");
        }

        [RuntimeInitializeOnLoadMethod] // ������Ϸʱ����һ��
        static void RuntimeInitializeOnLoadMethod()
        {
            Debug.Log("RuntimeInitializeOnLoadMethod");
        }

        [DidReloadScripts()] // ���������һ��
        static void OnScriptReload()
        {
            Debug.Log("�ű��������");
        }

        [PostProcessScene] // ����ʱ����һ��
        static void OnPostProcessScene()
        {
            Debug.Log("OnPostProcessScene");
        }

        [PostProcessBuild] // Build��ɺ����һ��
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

        [OnOpenAsset(2)] // ����Դʱ���ã���unity����򿪷���true�����ⲿ���ߴ򿪷���false
        public static bool OpenAsset2(int instanceID, int line)
        {
            string name = EditorUtility.InstanceIDToObject(instanceID).name;
            Debug.Log("Open Asset step:2 (" + name + ") ");
            return false;
        }
    }
}