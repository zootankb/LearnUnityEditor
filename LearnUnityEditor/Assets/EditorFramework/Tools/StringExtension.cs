using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace EditorFramework
{
    public static class StringExtension
    {
        public static string ToAssetsPath(this string self)
        {
            var assetFullPath = Path.GetFullPath(Application.dataPath);
            return "Assets" + Path.GetFullPath(self).Substring(assetFullPath.Length).Replace("\\", "/");
        }

        public static bool IsDirectory(this string self)
        {
            FileInfo fileinfo = new FileInfo(self);
            if((fileinfo.Attributes & FileAttributes.Directory) != 0)
            {
                return true;
            }
            return false;
        }
    }
}