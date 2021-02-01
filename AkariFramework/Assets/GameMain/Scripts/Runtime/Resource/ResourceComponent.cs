using libx;
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
            var manifest = BuildScript.GetManifest();
            var assets = manifest.assets;
            var dirs = manifest.dirs;

            string name;
            string path;
            for (int i = 0; i < assets.Length; i++)
            {
                var thisAsset = assets[i];
                int length = thisAsset.name.LastIndexOf('.');
                name = thisAsset.name.Substring(0, length);
                path = $"{dirs[thisAsset.dir]}/{thisAsset.name}";

                AllAssetPathShortName[name] = path;
            }
        }

        public AssetRequest LoadSprite(string assetName)
        {
            AllAssetPathShortName.TryGetValue(assetName, out string fullPath);
            if (fullPath == null) return null;

            var request = Assets.LoadAsset(fullPath, typeof(Sprite));

            return request;
        }
    }
}
