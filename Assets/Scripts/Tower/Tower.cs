﻿using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using DG.Tweening;
using UnityEngine;
public class Idle:TowerState
{
    public Tower _Tower;

    public Idle(Tower tower)
    {
        _Tower = tower;
    }

    public void Handle()
    {
        if (_Tower.FindEnermy())
        {
            _Tower.SetState(new Attack(_Tower));
        }
    
    }
}
public class Attack:TowerState
{
    public Tower _Tower;
    private float _time;
    public Attack(Tower tower)
    {
        _time = 0;
        _Tower = tower;
    }

    public void Handle()
    {
        _time += Time.deltaTime;
        if (_time >= 1 / _Tower.attackspeed)
        {
            _time -= 1 / _Tower.attackspeed;
            if(!_Tower.IsStopAttack())  _Tower.Attack();
            else
            {
                _Tower.SetState(new Idle(this._Tower));
            }
        }
    }
}
public class Tower : BaseTower
{
    private void Start()
    {
        Init(1, 1, 0.5f, 3, "Arrow", null, new Idle(this));
    }

    private void Update()
    {
        state.Handle();
    }

    public  void Attack()
    {
        GameObject arrow =GameObjectPool.GetPooledObject(weapon);
        arrow.transform.position=this.transform.position;
        arrow.GetComponent<Arrow>().pointB = target.transform;
        var engle = this.transform.position - target.transform.position;
        arrow.transform.rotation =new Quaternion(engle.x,engle.y,engle.z,0) ;
    }


   
}