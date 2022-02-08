using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace EditorExtensions
{
    public class EditorPrefsExample
    {
        private const string Key = "12312312";

        [MenuItem("EditorExtensions/04.Data/EditorPrefs/SaveTime")]
        public static void SaveTime()
        {
            EditorPrefs.SetString(Key, DateTime.Now.ToString());
        }

        [MenuItem("EditorExtensions/04.Data/EditorPrefs/ReadTime")]
        public static void ReadTime()
        {
            Debug.Log(EditorPrefs.GetString(Key));
        }
    }
}