using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 敌人状态
/// </summary>
public enum EnermyState
{
    Run,
    Damage,
    Recover
}
public class Enermys : MonoBehaviour
{
 
    
   public EnermyState enermystate=EnermyState.Run;
//    private Renderer renderer; 
//    public Transform redhp;
   [SerializeField]
   private float CurrentHp;

   [Header("血量")]
   public float Hp=5;

   [Header("赏金")]
   public int coin;

   [Header("攻击力")]
   public int eneymy_Atk;
   
   public bool IsDead;
   public SpriteRenderer spriteRenderer;
  
    /// <summary>
    /// 敌人受伤害事件
    /// </summary>
   public event EventHandler EnermyDamageEvent;
   /// <summary>
   /// 敌人死亡事件
   /// </summary>
   public event EventHandler EnermyDeadEvent;
   
   void Start()
   {
       spriteRenderer=this.GetComponent<SpriteRenderer>();
   }

   private void OnEnable()
   {
       CurrentHp=Hp;
       IsDead = false;
   }

   void Update()
   {
        switch (enermystate)
       {
           case EnermyState.Damage:  
           break;
           case EnermyState.Recover:
           StartCoroutine(Recover());
           break;
           case EnermyState.Run:
           break;
           
       }
   }
   /// <summary>
   /// 敌人收到伤害
   /// </summary>
   /// <param name="ondamage">伤害</param>
   public void OnDamaged(int damage){
       spriteRenderer.material.SetFloat("_FlashAmount", 1);
       CurrentHp-=damage;
       if(CurrentHp<=0)  OnDead();
       enermystate=EnermyState.Recover;
   }
   public void OnDead()
   { 
       IsDead = true;
      this.gameObject.SetActive(false);
      //在gamemanager绑定onEnermyDead事件
      EnermyDeadEvent(this,null);
   }
   private IEnumerator Recover(){
       enermystate=EnermyState.Run;
       yield return new WaitForSeconds(0.1f);
       spriteRenderer.material.SetFloat("_FlashAmount", 0);
   }

 
}
