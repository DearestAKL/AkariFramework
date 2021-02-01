using System.Collections.Generic;
using UnityEngine;

namespace Akari
{
    public class ObjectPool
    {
        private readonly string m_Name;

        private List<GameObject> PoolObjs = new List<GameObject>();
        private int m_Count;
        private int m_UsingCount;
        private int m_Capacity;

        public ObjectPool(string name)
        {
            m_Name = name;
        }

        /// <summary>
        /// 获取对象池名称。
        /// </summary>
        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        /// <summary>
        /// 获取对象池中对象的数量。
        /// </summary>
        public int Count
        {
            get 
            {
                return m_Count; 
            }
        }

        /// <summary>
        /// 获取对象池中能被释放的对象的数量。
        /// </summary>
        public int CanReleaseCount
        {
            get 
            { 
                return m_UsingCount; 
            }
        }

        /// <summary>
        /// 获取或设置对象池的容量。
        /// </summary>
        public int Capacity
        {
            get { return m_Capacity; }
            set { m_Capacity = value; }
        }

        /// <summary>
        /// 释放对象池中的可释放对象。
        /// </summary>
        public void Release()
        {

        }

        /// <summary>
        /// 释放对象池中的可释放对象。
        /// </summary>
        /// <param name="toReleaseCount">尝试释放对象数量。</param>
        public void Release(int toReleaseCount)
        {

        }

        /// <summary>
        /// 从对象池中获取对象
        /// </summary>
        public GameObject GetObject()
        {
            if(m_Count > 0)
            {
                //m_Count--;
                return PoolObjs[0];
            }

            return null;
        }

        /// <summary>
        /// 归还对象到对象池
        /// </summary>
        public void PushObject(GameObject poolObj)
        {
            //m_Count++;
            PoolObjs.Add(poolObj);
        }
    }
}
