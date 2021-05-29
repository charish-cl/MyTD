
using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using Manage;
using UI;
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
    /// <summary>
    /// 游戏状态
    /// </summary>
    public GameState gameState;
    
    [Header("敌人生成器")]
    public EnermySpawn spawn;

    public Hero.Hero Hero;
    private void Awake()
    {
        GameObjectPool.CreatPool();
        // UIPanelManager.Instance.PushPanel(UIPanelType.GamePanel);
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
      if(GUILayout.Button("设置字",GUILayout.Width(200),GUILayout.Height(50)))
      {
         MainUI.Instance.SetTextUI("金币","40");
      }  
      if(GUILayout.Button("设置字",GUILayout.Width(400),GUILayout.Height(100)))
      {
         MainUI.Instance.DisaplayWaveText(2);
      }  
      if(GUILayout.Button("打印状态",GUILayout.Width(400),GUILayout.Height(100)))
      {
          Debug.Log( Hero._herostate);
      }
  }

  
  
 
}
