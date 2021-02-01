using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Akari
{
    public class GameEntry : MonoBehaviour
    {
        public Image test;

        private void Awake()
        {
            InitBuiltinComponents();

            var request = Resource.LoadSprite("0");
            if (request == null) return;
            test.sprite = request.asset as Sprite;
        }

        public static ResourceComponent Resource
        {
            get;
            private set;
        }

        public static EventComponent Event
        {
            get;
            private set;
        }

        public static ObjectPoolComponent ObjectPool
        {
            get;
            private set;
        }

        /// <summary>
        /// 这里注册组件
        /// </summary>
        private static void InitBuiltinComponents()
        {
            Resource = new ResourceComponent();
            Resource.Initialize();

            Event = new EventComponent();
            Event.Initialize();

            ObjectPool = new ObjectPoolComponent();
            ObjectPool.Initialize();
        }
    }
}