using libx;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Akari
{
    public class GameEntry : MonoBehaviour
    {
        [SerializeField]
        private Camera m_UICamera;
        [SerializeField][Header("目标帧率")]
        private int targetFrameRate = 120;

        public void Awake()
        {
            InitConfig();
            InitBuiltinComponents();

            var request = Resource.LoadSprite("0");
            if (request == null) return;
            //test.sprite = request.asset as Sprite;

            var go = Resource.LoadAsset("Test",typeof(GameObject)).asset as GameObject;


            ObjectPool.CreatObjectPool("Test", go, 10);
            //ObjectPool.PushObject("test", go);

            var GETGO = ObjectPool.GetObject("Test");
            GETGO.transform.SetParent(this.transform);

            UI.OpenUIPanel("UITest", GroupType.Base);
        }

        public void Update()
        {
            UI.OnUpdate();
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        private void InitConfig()
        {
            UICamera = m_UICamera;
            Application.targetFrameRate = targetFrameRate;
        }

        /// <summary>
        /// 这里注册组件
        /// </summary>
        private void InitBuiltinComponents()
        {
            Resource = new ResourceComponent();
            Resource.Initialize();

            Event = new EventComponent();
            Event.Initialize();

            ObjectPool = new ObjectPoolComponent();
            ObjectPool.Initialize();

            UI = new UIComponent();
            UI.Initialize();
        }

        public static Camera UICamera
        {
            get;
            private set;
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

        public static UIComponent UI
        {
            get;
            private set;
        }
    }
}