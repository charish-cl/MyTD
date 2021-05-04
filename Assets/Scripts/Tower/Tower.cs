using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public enum TowerState
    {
        Idle,
        Attack,
        Wait
    }

    public TowerState state = TowerState.Idle;
    [Header("花费")] public int cost;
    [Header("攻击物品种类")] public GameObject weapon;

    [Header("攻击间隔")] public float WaitTime = 2;
    [Header("当前范围内的敌人")] public List<GameObject> targetpool;


    void ChangeState(TowerState state)
    {
        this.state = state;
    }
    
    void Awake()
    {
        targetpool = new List<GameObject>();
    }

    void FixedUpdate()
    {
        switch (state)
        {
            case TowerState.Idle:
                break;
            case TowerState.Attack:
                StartCoroutine("Attack");
                break;
            case TowerState.Wait:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //发现敌人改变状态
        if (other.tag == "敌人")
        {
            targetpool.Add(other.gameObject);
            if (state.Equals(TowerState.Idle))
            {
                ChangeState(TowerState.Attack);
                //  Debug.Log("发现敌人"); 
            }
        }
    }

    IEnumerator Attack()
    {
        ChangeState(TowerState.Wait);

        if (weapon.Equals(null)) Debug.Log("武器未挂载");

        GameObject arrow =GameObjectPool.GetPooledObject(weapon.name);
        arrow.GetComponent<Transform>().position=this.transform.position;
        arrow.GetComponent<Arrow>().pointB = targetpool[0].transform;
        
        yield return new WaitForSecondsRealtime(WaitTime);


        //可能会在敌人要走出的时候在攻击间隔时间
        if (targetpool.Count != 0)
            ChangeState(TowerState.Attack);
        else
            ChangeState(TowerState.Idle);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (targetpool.Contains(other.gameObject))
            targetpool.Remove(other.gameObject);
    }
}