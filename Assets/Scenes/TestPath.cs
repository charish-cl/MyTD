using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TestPath : MonoBehaviour
{
 //   public Transform startTrans;
    public Transform endTrans;
    public float height;
   public int resolution;
    private void Start()
    {

        var startPoint = this.transform.position;
        var endPoint=endTrans.position;
        var bezierControlPoint = (startPoint + endPoint) * 0.5f+(Vector3.up*height);

        var path = new Vector3[resolution];//resolution为int类型，表示要取得路径点数量，值越大，取得的路径点越多，曲线最后越平滑
       
        for (int i = 0; i < resolution; i++)
        {
            var t = (i+1) / (float)resolution;;//归化到0~1范围
            path[i] = GetBezierPoint(t,startPoint,bezierControlPoint,endPoint);//使用贝塞尔曲线的公式取得t时的路径点
        }
        // this.GetComponent<LineRenderer>().positionCount = path.Length;
        // this.GetComponent<LineRenderer>().SetPositions(path);
        transform.DOPath(path, 3.8f).SetEase(Ease.InCirc);
    }

    private void Update()
    {
        transform.LookAt(endTrans.position);
    }

    /// <param name="t">0到1的值，0获取曲线的起点，1获得曲线的终点</param>
    /// <param name="start">曲线的起始位置</param>
    /// <param name="center">决定曲线形状的控制点</param>
    /// <param name="end">曲线的终点</param>
    public static Vector3 GetBezierPoint(float t, Vector3 start, Vector3 center, Vector3 end)
    {
        return (1 - t) * (1 - t) * start + 2 * t * (1 - t) * center + t * t * end;
    }
}
