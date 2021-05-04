using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// 使用了抛物线的弓箭
/// </summary>
public class Arrow : MonoBehaviour
{
    public float time = 2; //代表从A点出发到B经过的时长
    [HideInInspector] 
    public Transform pointB; //点B

    public float g = -2; //重力加速度

    //初速度向量
    private Vector3 speed;
    
    ////重力向量
    private Vector3 Gravity; 
    
    public int damage = 1;
    
    void Start()
    {
        //通过一个式子计算初速度
        // speed = new Vector3((pointB.position.x - transform.position.x)/time,
        //     (pointB.position.y-transform.position.y)/time-0.5f*g*time, (pointB.position.z - transform.position.z) / time);
        // Gravity = Vector3.zero;
        //重力初始速度为0
    }

    private float dTime = 0;
    

    void FixedUpdate()
    {
        // Gravity.y = g * (dTime += Time.fixedDeltaTime);//v=at

        //  //模拟位移
        // transform.Translate(speed*Time.fixedDeltaTime);
        // transform.Translate(Gravity * Time.fixedDeltaTime);   
        this.transform.position =
                Vector2.MoveTowards(this.transform.position, pointB.position, Time.deltaTime * 5.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("敌人"))
        {
            this.GetComponent<Collider2D>().enabled = false;
            other.gameObject.GetComponent<Enermys>().OnDamaged(damage);
            this.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        this.GetComponent<Collider2D>().enabled = true;
    }
}