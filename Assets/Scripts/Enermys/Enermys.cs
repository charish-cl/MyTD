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
    Recover,
    Dead
}
[RequireComponent(typeof(PathFind))]
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
   private GameObject targetHero;

  
   /// <summary>
   /// 敌人死亡事件
   /// </summary>
   public event EventHandler EnermyDeadEvent;
   private Animator animator;
   void Start()
   {
       animator = this.transform.Find("model").GetComponent<Animator>();
       
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
           animator.Play("Run");
           break;
           case EnermyState.Dead:
           StartCoroutine(OnDead());
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
       if(CurrentHp<=0) enermystate=EnermyState.Dead;
       else enermystate=EnermyState.Recover;
       
   }
   public IEnumerator OnDead()
   { 
   
      IsDead = true;
      yield return new WaitForSeconds(0.1f);//稍微延迟一会再读取动画时间
      animator.Play("Die");
      var sawAnimState =animator.GetCurrentAnimatorStateInfo(0);//读取当前动画事件的时间
      yield return new WaitForSeconds(sawAnimState.length);//动画执行完成后
      this.gameObject.SetActive(false);

      enermystate = EnermyState.Run;
   }
   private IEnumerator Recover(){
       enermystate=EnermyState.Run;
       yield return new WaitForSeconds(0.1f);
       spriteRenderer.material.SetFloat("_FlashAmount", 0);
   }
 
 
}
