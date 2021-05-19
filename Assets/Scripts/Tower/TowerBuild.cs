using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 挂载在塔UI上
/// </summary>
public class TowerBuild: MonoBehaviour
{

   [Header("塔的落脚点")]
   public Transform current_Pos;
   private GameManager game;
 
  
   void Start()
   {
       game=GameManager.Instance;
   }
   public void BuildTower(string name)
   {
  
     GameObject go= Instantiate(Resources.Load("Prefabs/"+name),current_Pos.position,new Quaternion()) as GameObject;
     var cost=go.GetComponent<Tower>().cost;
     // if(game.money<cost) {
     //   Debug.Log("金币不足");
     //   return;
     //  }
     // else{
     //   game.money-=cost;
     //   game.text.text=game.money.ToString();
     // }
     
   }
}
