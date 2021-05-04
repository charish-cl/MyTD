using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFind : MonoBehaviour
{
    Transform[] waypoint;
    GameObject Waypoint;
    private int currenIndex = 1;
    [Header("移速")] 
    public float moveSpeed = 1.0f;

    void Start()
    {
        GetWaypoint();
    }

    void Update()
    {
        ArrivePoint();
    }

    public void ArrivePoint()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, waypoint[currenIndex].position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoint[currenIndex].position) < 0.05f)
        {
            //   Debug.Log("到达");
            currenIndex++;
            if (currenIndex == waypoint.Length)
            {
                Destroy(this);
            }
        }
    }

    public void GetWaypoint()
    {
        Waypoint = GameObject.Find("waypoint");
        if (Waypoint.Equals(null)) Debug.Log("场景中未创建waypoint对象");
        waypoint = Waypoint.GetComponentsInChildren<Transform>();
    }
}