using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseElement : MonoBehaviour
{
  /// <summary>
  /// 属性
  /// </summary>
  public int hp;
  public int mp;
  /// <summary>
  /// 速度
  /// </summary>
  public float movespeed;

  /// <summary>
  /// 攻击
  /// </summary>
  public int attack;
  public float attckspeed;
  public float attckdistance;

  /// <summary>
  /// 防御力
  /// </summary>
  public int defence;
  
}
