using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorExtensions
{
    public class AssetPostprocessorExample :AssetPostprocessor
    {
        private void OnPreprocessTexture()
        {
            Debug.Log("OnPreprocessTexture:" + this.assetPath);
            TextureImporter importer = this.assetImporter as TextureImporter;
            importer.textureType = TextureImporterType.Sprite;
            importer.maxTextureSize = 512;
            importer.mipmapEnabled = false;
        }

        private void OnPostprocessTexture(Texture texture)
        {
            Debug.Log("OnPostprocessTexture:" + texture.name);
        }
    }
}