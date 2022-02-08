using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class AssetDatabaseExample : MonoBehaviour
    {
        const string FolderPath = "Assets/EdiorExtensions/5.ProjectExample/02.AssetDatabase";
        const string FolderName = "NewFloder";
        const string NewFolderPath = FolderPath + "/" + FolderName;
        const string NewMaterialPath= NewFolderPath + "/New Materials.mat";

        private const string MENU_PATH = "EditorExtensions/03.Project/01.AssetDatabase";
        [MenuItem(MENU_PATH+"/CreateMaterial")]
        static void CreateMaterial()
        {
            if (!Directory.Exists(NewFolderPath))
            {
                string guid = AssetDatabase.CreateFolder(FolderPath, FolderName);
                if (!string.IsNullOrEmpty(AssetDatabase.GUIDToAssetPath(guid)))
                {
                    Debug.Log("Folder Asset Created !" + guid);
                }
                else
                {
                    Debug.Log(guid);
                }
            }
            var material = new Material(Shader.Find("Specular"));
            AssetDatabase.CreateAsset(material, NewMaterialPath);
            if (AssetDatabase.Contains(material))
            {
                Debug.Log(material.name + " created !");
            }
            else
            {
                Debug.Log("Failed");
            }
        }

        [MenuItem(MENU_PATH + "/GetMaterialGUID")]
        static void GetMaterialGUID()
        {
            Debug.Log(AssetDatabase.AssetPathToGUID(NewMaterialPath));
        }

        [MenuItem(MENU_PATH + "/LoadMaterial")]
        static void Load()
        {
            Debug.Log(AssetDatabase.LoadAssetAtPath<Material>(NewMaterialPath));
        }

        [MenuItem(MENU_PATH + "/RenameMaterial")]
        static void Rename()
        {
            Debug.Log(AssetDatabase.RenameAsset(NewMaterialPath, "NewName"));
        }

        [MenuItem(MENU_PATH + "/MoveMaterial")]
        static void Remove()
        {
            Debug.Log(AssetDatabase.MoveAsset(NewMaterialPath, "Assets/move.mat"));
        }

        [MenuItem(MENU_PATH + "/CopyMaterial")]
        static void Copy()
        {
            Debug.Log(AssetDatabase.CopyAsset(NewMaterialPath, "Assets/Copy.mat"));
        }

        [MenuItem(MENU_PATH + "/DeleteMaterial")]
        static void Delete()
        {
            // 移动到电脑的回收站，可以从回收站还原过来
            AssetDatabase.MoveAssetToTrash(NewMaterialPath);
            AssetDatabase.DeleteAsset(NewMaterialPath);
            AssetDatabase.Refresh();
        }

        [MenuItem(MENU_PATH + "/GetMaterialGUID", validate =true)]
        [MenuItem(MENU_PATH + "/LoadMaterial", validate =true)]
        [MenuItem(MENU_PATH + "/RenameMaterial", validate =true)]
        [MenuItem(MENU_PATH + "/MoveMaterial", validate =true)]
        [MenuItem(MENU_PATH + "/CopyMaterial", validate =true)]
        [MenuItem(MENU_PATH + "/DeleteMaterial", validate =true)]
        static bool Check()
        {
            return File.Exists(NewMaterialPath);
        }
    }
}