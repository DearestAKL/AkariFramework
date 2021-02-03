using libx;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Akari
{
    public class ResourceComponent
    {
        Dictionary<string, string> AllAssetPathShortName = new Dictionary<string, string>();

        public void Initialize()
        {
            InitResPath();
        }

        /// <summary>
        /// 初始化资源路径
        /// </summary>
        private void InitResPath()
        {
            var assets = Assets.GetAllAssetPaths();

            string name;
            string path;
            for (int i = 0; i < assets.Length; i++)
            {
                path = assets[i];
                int startIndex = path.LastIndexOf('/') + 1;
                int length = path.LastIndexOf('.') - startIndex;
                name = path.Substring(startIndex, length);

                AllAssetPathShortName[name] = path;
            }
        }

        public AssetRequest LoadSprite(string assetName)
        {
            var request = LoadAsset(assetName, typeof(Sprite));

            return request;
        }

        public AssetRequest LoadAsset(string assetName,Type type)
        {
            AllAssetPathShortName.TryGetValue(assetName, out string fullPath);
            if (fullPath == null) return null;

            var request = Assets.LoadAsset(fullPath, type);

            return request;
        }


    }
}
