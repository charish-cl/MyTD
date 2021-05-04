
using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using Manage;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Fighting,
    Begin,
    Victory,
    Fail
}
public class GameManager : MonoSingletion<GameManager>
{
    [Header("游戏状态")]
    public GameState gameState;
    
    [Header("敌人生成器")]
    public EnermySpawn spawn;

    [Header("目前敌人数量")]
    public int enermycount;

    [Header("总金币")]
    public int money;

    [Header("金币显示")]
    public  Text text;


    private void Awake()
    {
        GameObjectPool.CreatPool();
    }
    void  Start(){ 
        XmlUntity.GetInstance().Read();
        gameState=GameState.Begin;
    }
    void Update(){


      switch (gameState)
      {
          case GameState.Fighting:
          break;
          case GameState.Begin:
          StartCoroutine(EnermyManager.GetInstance().Action());
          gameState = GameState.Fighting;
          break;
          case GameState.Victory:
          break;
          case GameState.Fail:
          break;
          
      }
    //点击事件
      
			// if(Input.GetMouseButtonDown(0))
      // {
      // Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			// RaycastHit2D hit = Physics2D.Raycast (new Vector2(myRay.origin.x, myRay.origin.y), Vector2.down);
      //   if(!hit.Equals(null))
      //   {
      //     if (hit.collider.tag.Equals("建造点"))   Build(hit.transform);  
         
      //   }
      // }
      // if (Input.GetMouseButtonDown(0))
      // {
      //     Collider2D[] col = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
      //     foreach (var collider2D1 in col)
      //     {
      //         Debug.Log(collider2D1.gameObject.tag);
      //     }
      // }
      
  }
  void OnGUI()
  {
      if(GUILayout.Button("开始",GUILayout.Width(200),GUILayout.Height(50))){
        gameState=GameState.Begin;
      }
      if(GUILayout.Button("下一波",GUILayout.Width(200),GUILayout.Height(50)))
      {
        StartCoroutine(EnermyManager.GetInstance().Action());
      }
  }
  void RefreshUI()
  {
      text.text=money.ToString();    
  }
  
  
 
}
