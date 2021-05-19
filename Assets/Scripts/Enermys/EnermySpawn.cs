using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

/// <summary>
/// 敌人生成器，还未使用对象池
/// </summary>
public class EnermySpawn : Singleton<EnermySpawn>
{
    /// <summary>
    /// 敌人字典，待定
    /// </summary>
    public Dictionary<string, GameObject> enermys_dic;

    /// <summary>
    /// 出生点
    /// </summary>
    private Transform bornpoint;

    public  EnermySpawn()
    {
        bornpoint = GameObject.Find("出生点").GetComponent<Transform>();
        enermys_dic = new Dictionary<string, GameObject>();
    }

    public GameObject EnermyBuilder(string key)
    {
        var go = GameObjectPool.GetPooledObject(key);
        go.transform.position = bornpoint.transform.position;
       
        return go;
    }
}