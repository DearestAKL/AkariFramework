using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 基础数据，包含资源prefab id，移动速度，重力，指令起始招式id等
/// </summary>
public class ActorAttributes
{
    public int prefabId;

    public ActorAttributes(int prefabId)
    {
        this.prefabId = prefabId;
    }
}
