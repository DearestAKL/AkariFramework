using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Akari
{
    public class ObjectPoolComponent
    {
        //对象池容器
        public Dictionary<string, ObjectPool> poolDic = new Dictionary<string, ObjectPool>();


        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {

        }

        /// <summary>
        /// 创建对象池
        /// </summary>
        /// <param name="name">对象池名字</param>
        public void CreatObjectPool(string name,out ObjectPool newObjectPool)
        {
            if (poolDic.ContainsKey(name))
            {
                //已存在
                newObjectPool = poolDic[name];
                return;
            }

            newObjectPool = new ObjectPool(name);
            poolDic[name] = newObjectPool;
        }

        /// <summary>
        /// 获取对象池 没有则创建新的对象池
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ObjectPool GetObjectPool(string name)
        {
            if (poolDic.ContainsKey(name))
            {
                return poolDic[name];
            }

            //没有 创建新的
            CreatObjectPool(name, out ObjectPool newObjectPool);

            return newObjectPool;
        }

        /// <summary>
        /// 从对象池中获取对象
        /// </summary>
        public GameObject GetObject(string name)
        {
            var objectPool = GetObjectPool(name);
            return objectPool?.GetObject();
        }

        /// <summary>
        /// 归还对象到对象池
        /// </summary>
        public void PushObject(string name,GameObject poolObj)
        {
            var objectPool = GetObjectPool(name);
            objectPool?.PushObject(poolObj);
        }
    }
}
