using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Akari
{
    public class UIComponent
    {
        private Transform m_RootTransCache;

        private Dictionary<GroupType, UIGroup> m_GroupCache = new Dictionary<GroupType, UIGroup>();
        List<UIGroup> m_UIGroups = new List<UIGroup>();


        public void Initialize()
        {
            m_RootTransCache = new GameObject("UIRoot").transform;

            InitCanvas();
        }

        /// <summary>
        /// 轮询。
        /// </summary>
        public void OnUpdate()
        {
            if (m_UIGroups.Count > 0)
            {
                for (int i = 0; i < m_UIGroups.Count; i++)
                {
                    m_UIGroups[i].OnUpdate();
                }
            }
        }

        #region 初始化

        /// <summary>
        /// 初始化生成Canvas
        /// </summary>
        private void InitCanvas()
        {
            m_UIGroups.Add(new UIGroup(GroupType.Base, 0, m_RootTransCache));
            m_UIGroups.Add(new UIGroup(GroupType.Mid, 100, m_RootTransCache));
            m_UIGroups.Add(new UIGroup(GroupType.Top, 200, m_RootTransCache));
            m_UIGroups.Add(new UIGroup(GroupType.System, 300, m_RootTransCache));

            //生成
            for (int i = 0; i < m_UIGroups.Count; i++)
            {
                m_GroupCache[m_UIGroups[i].Type] = m_UIGroups[i];
            }
        }

        #endregion

        #region 界面组

        /// <summary>
        /// 获取界面组
        /// </summary>
        /// <param name="canvasType"></param>
        /// <returns></returns>
        public UIGroup GetUIGroup(GroupType canvasType)
        {
            return m_GroupCache[canvasType];
        }

        #endregion

        #region 界面

        /// <summary>
        /// 获取界面
        /// </summary>
        /// <param name="panelName"></param>
        /// <param name="canvasType"></param>
        /// <returns></returns>
        public UIPanel GetUIPanel(string panelName, GroupType canvasType)
        {
            var group = GetUIGroup(canvasType);
            var uiPanel = group.GetUIPanel(panelName);
            return uiPanel;
        }

        /// <summary>
        /// 打开界面
        /// </summary>
        /// <param name="panelName"></param>
        /// <param name="canvasType"></param>
        /// <param name="userData"></param>
        public void OpenUIPanel(string panelName, GroupType canvasType, object userData = null)
        {
            var group = m_GroupCache[canvasType];
            group.OpenUIPanel(panelName, userData);
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="panelName"></param>
        /// <param name="canvasType"></param>
        /// <param name="isRecycle"></param>
        public void CloseUIPanel(string panelName, GroupType canvasType)
        {
            var group = GetUIGroup(canvasType);
            group.CloseUIPanel(panelName);
        }

        /// <summary>
        /// 回收界面
        /// </summary>
        /// <param name="panelName"></param>
        /// <param name="canvasType"></param>
        public void RecycleUIPanel(string panelName, GroupType canvasType)
        {
            var group = GetUIGroup(canvasType);
            group.RecycleUIPanel(panelName);
        }
        #endregion
    }
}
