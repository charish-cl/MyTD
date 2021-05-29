using System.Collections.Generic;
using UnityEngine;

public  class GameObjectPool
{
    /// <summary>
    ///对象池
    /// </summary>
    private static Dictionary<string, List<GameObject>> pool;

    public static List<GameObject> _enermypool { get; set;}
    public static void CreatPool()
    {
        pool = new Dictionary<string, List<GameObject>>();
        _enermypool = new List<GameObject>();
    }
    
    public static GameObject GetPooledObject(string key)
    {
       
        if (!pool.ContainsKey(key))
        {
            List<GameObject> temp = new List<GameObject>();
            pool.Add(key, new List<GameObject>());
        }
        else
        {
            for (int i = 0; i < pool[key].Count; i++)
            {
                if (!pool[key][i].activeInHierarchy)
                {
                    pool[key][i].SetActive(true);
                 
                    return pool[key][i];
                }
            }
        }
        return CreatObject(key);
    }

    private  static GameObject  CreatObject(string key)
    {
        //池子有键值但无可用的物品
        GameObject obj =GameObject.Instantiate(Resources.Load("Prefabs/" + key) as GameObject,new Vector3(),new Quaternion()) ;
        if (obj.tag == "敌人")
        {
        
            _enermypool.Add(obj);
        }
        pool[key].Add(obj);
        return obj;
    }
       
}