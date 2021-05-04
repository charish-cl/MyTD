using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class GameObjectPool
{
    /// <summary>
    ///对象池
    /// </summary>
    private static Dictionary<string, List<GameObject>> pool;
    
    public static void CreatPool()
    {
        pool = new Dictionary<string, List<GameObject>>();
    }

    public static GameObject GetPooledObject(string key)
    {
       
        if (!pool.ContainsKey(key))
        {
            List<GameObject> temp = new List<GameObject>();
            GameObject tempobject = Resources.Load("Prefabs/" + key) as GameObject;
            temp.Add(tempobject);
            pool.Add(key, new List<GameObject>());
            return tempobject;
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

        //池子有键值但无可用的物品
        GameObject obj = Resources.Load("Prefabs/" + key) as GameObject;
        pool[key].Add(obj);
        return obj;
    }

    public static List<GameObject> GetPoolListWithTag(string tag)
    {
        List<GameObject> go = null;
        bool test=false;
        foreach (var key in pool.Keys)
        {
            Debug.Log("dwa");
            if (pool[key][0].gameObject.tag == tag)
            {
                if (test == false)
                {
                    go = pool[key];
                    test = true;
                }
                else
                {
                     go=go.Union(pool[key]).ToList();
                }
               
            }
        }

        return go;
    }
}