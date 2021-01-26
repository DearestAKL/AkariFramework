using libx;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Akari
{
    public class ResourceComponent
    {
        Dictionary<string, string> AllAssetPathShortName = new Dictionary<string, string>();

        List<AssetRequest> _requests = new List<AssetRequest>();

        public void Initialize()
        {
            var assets = Assets.GetAllAssetPaths();
            string path = "";
            int startIndex = 0;
            int length = 0;
            for (int i = 0; i < assets.Length; i++)
            {
                path = assets[i];
                startIndex = path.LastIndexOf('/') + 1;
                length = path.LastIndexOf('.') - startIndex;
                AllAssetPathShortName[path.Substring(startIndex, length)] = path;
            }
        }

        public AssetRequest LoadSprite(string path)
        {
            AllAssetPathShortName.TryGetValue(path, out string fullPath);
            if (fullPath == null) return null;

            var request = Assets.LoadAsset(fullPath, typeof(Sprite));
            _requests.Add(request);
            return request;
        }
    }
}