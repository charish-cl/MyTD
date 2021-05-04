using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITool : MonoBehaviour
{
    [Header("父物体屏幕位置")]
    public Transform parent;
     
    void Start()
    {
        this.transform.position= Camera.main.WorldToScreenPoint(parent.position);
    }

  
}
