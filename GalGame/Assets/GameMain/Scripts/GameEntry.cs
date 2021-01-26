using UnityEngine;
using UnityEngine.UI;

namespace Akari {
    /// <summary>
    /// 游戏人口
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        //-------Test---------
        public Image test;


        private static GameObject rootGo;
        private void Start()
        {
            rootGo = this.gameObject;
            InitBuiltinComponents();

            var request = Resource.LoadSprite("0");
            if (request == null) return;
            test.sprite = request.asset as Sprite;
        }
    }

    public partial class GameEntry : MonoBehaviour
    {
        public static ResourceComponent Resource
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
        }
    }
}