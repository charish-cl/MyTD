using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 单例模式
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> where T:new()
{
    private static T instance;
    public static T GetInstance()
    {
        if(instance==null) 
        instance=new T();
        return instance;
    }
}