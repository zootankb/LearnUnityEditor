using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

namespace EditorExtensions
{
    public class AssetModificationProcessorExample : UnityEditor.AssetModificationProcessor
    {
        /// <summary>
        /// ����ʱȷ����Ż�ִ��
        /// </summary>
        /// <param name="assetName"></param>
        private static void OnWillCreateAsset(string assetName)
        {
            Debug.Log($"OnWillCrateAsset{assetName}");
        }

        private static AssetDeleteResult OnWillDeleteAsset(string assetPath,RemoveAssetOptions options)
        {
            Debug.Log($"OnWillDeleteAsset{assetPath}=>{options}");
            if (EditorUtility.DisplayDialog("ɾ��Ŀ¼", "ȷ��Ҫɾ����", "ȷ��", "ȡ��"))
            {
                return AssetDeleteResult.DidNotDelete;
            }
            else
            {
                return AssetDeleteResult.FailedDelete;
            }
            
        }


        private static AssetMoveResult OnWillMoveAsset(string assetPath, string destinationPath)
        {
            Debug.Log($"OnWillMoveAsset{assetPath}=>{destinationPath}");
            if (EditorUtility.DisplayDialog("�ƶ�Ŀ¼", $"ȷ��Ҫ�ƶ���{assetPath}=>{destinationPath}", "ȷ��", "ȡ��"))
            {
                return AssetMoveResult.DidNotMove;
            }
            else
            {
                return AssetMoveResult.FailedMove;
            }
        }

        private static string[] OnWillSaveAssets(string[] paths)
        {
            Debug.Log($"OnWillSaveAssets{paths}");
            return paths;
        }

        private static bool CanOpenForEdit(string[]assetOrMetaFilePaths,List<string>outNotEditable,StatusQueryOptions statusQueryOptions)
        {
            Debug.Log("CanOpenForEdit");
            return true;
        }

        private static void FileModeChanged(string[] paths, FileMode mode)
        {
            Debug.Log($"FileModeChanged ({mode})");
            foreach (var path in paths)
            {
                Debug.Log(path);
            }
        }

        private static bool  MakeEditable(string[] paths, string prompt,List<string> s)
        {
            Debug.Log($"MakeEditable");
            foreach (var path in paths)
            {
                Debug.Log(path);
            }
            return true;

        }
    }
}