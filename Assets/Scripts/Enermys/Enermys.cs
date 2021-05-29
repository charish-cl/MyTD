using System;
using Character;
using UnityEngine;
/// <summary>
/// 敌人状态
/// </summary>
public interface EnermyState
{
   void  Handle();
}

class PathFinding:EnermyState
{
    
    public Enermys enermys;

   public PathFinding(Enermys enermys)
    {
        this.enermys = enermys;
       enermys.animator.SetBool("IsAttack",false);
    }
    public void Handle()
    {
        enermys.ArrivePoint();
    }

}

class EnermyAttack:EnermyState
{
    public Enermys enermys;

    public EnermyAttack(Enermys enermys)
    {
        this.enermys = enermys;
        enermys.animator.SetBool("IsAttack",true);
    }
    public void Handle()
    {
        enermys.Attack();
    }
 
}

public class Enermys :BaseCharacterElement,IBaseCharacterAction
{
 
    Transform[] waypoint;
    GameObject Waypoint;
    private int currenIndex = 1;
    
    
   public EnermyState enermystate;
   public float CurrentHp;
   [Header("赏金")]
   public int coin;
   
   public GameObject target;
   public SpriteRenderer spriteRenderer;

   private float time;
   private GameTimer _timer;
   /// <summary>
   /// 敌人死亡事件
   /// </summary>
   public event EventHandler EnermyDeadEvent;
   public Animator animator;
   void Start()
   {
       Init(
           5,1,1,1,1,1
       );
       animator = this.transform.Find("model").GetComponent<Animator>();
         enermystate = new PathFinding(this);
       GetWaypoint();
       CurrentHp = this.hp;
       _timer = new GameTimer(0.2f);
   }

   private void OnEnable()
   {
       
       time = 0;
       CurrentHp = this.hp;
       IsDead = false;
       currenIndex = 1;
       
   }

   void Update()
   {
       enermystate.Handle();
   }
   /// <summary>
   /// 敌人收到伤害
   /// </summary>
   /// <param name="ondamage">伤害</param>
   public void OnDamage(float damage){
       spriteRenderer.material.SetFloat("_FlashAmount", 1);

       Timer.Register(0.2f, () => { spriteRenderer.material.SetFloat("_FlashAmount", 0); });
       CurrentHp-=damage;
       if (CurrentHp <= 0) OnDead();
    
   }

   public void Attack()
   {
       //攻击行为
       //敌人死亡或者超出攻击范围，停止攻击切换状态
       if (Vector2.Distance(transform.position, target.transform.position) >
         attackdistance||target.gameObject.GetComponent<Hero.Hero>().IsDead)
       {

           target = null;
          SetState(new PathFinding(this));
          return;
       }

       time += Time.deltaTime;
       var animatorInfo =animator.GetCurrentAnimatorStateInfo (0);
       if ((time>=animatorInfo.length))//normalizedTime: 范围0 -- 1,  0是动作开始，1是动作结束
       {
           time -= animatorInfo.length;
           // Debug.Log("攻击");
           target.GetComponent<Hero.Hero>().OnDamage(1);//播放完成后敌人收到伤害
           //  Debug.Log(  _Hero.targetenermy.GetComponent<Enermys>().CurrentHp);
       }

   }


   public void OnDead()
   {
       IsDead = true;
      //稍微延迟一会再读取动画时间
      // animator.Play("Die");
      // //动画执行完成后
      // Timer.Register(0.8f, (delegate
      // {
         enermystate = new PathFinding(this);
          this.gameObject.SetActive(false);
      // }));


   }

   public void ArrivePoint()
   {
       transform.position = Vector2.MoveTowards(transform.position, waypoint[currenIndex].position, movespeed * Time.deltaTime);
       if (Vector2.Distance(transform.position, waypoint[currenIndex].position) < 0.05f)
       {
           currenIndex++;
           if (currenIndex == waypoint.Length)
           {
             gameObject.SetActive(false);
           }
       }

       if (target != null)
       {
            SetState(new EnermyAttack(this));
       }
   }

   public void SetState(EnermyState state)
   {
       enermystate = state;
   }
   public void GetWaypoint()
   {
       Waypoint = GameObject.Find("waypoint");
       if (Waypoint.Equals(null)) Debug.Log("场景中未创建waypoint对象");
       waypoint = Waypoint.GetComponentsInChildren<Transform>();
   }


}
