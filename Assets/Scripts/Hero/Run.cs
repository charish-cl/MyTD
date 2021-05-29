using DG.Tweening;
using UnityEngine;

namespace Hero
{
    public class Run:State
    { 
        public Hero _Hero;
        public Tweener tween;
        public Run(Hero hero)
        {
            _Hero = hero;
            _Hero.animator.SetBool("IsRun",true);
            _Hero.Flip(hero.targetenermy.transform.position);
           tween=  _Hero.transform.DOMove(_Hero.targetenermy.transform.position, 4);
        }

        public void OnStateUpdate()
        {
            RunTowardEnermy();
        }

         private  void RunTowardEnermy()
         {
             var dis = Vector2.Distance(_Hero.transform.position,
                 _Hero.targetenermy.gameObject.GetComponent<Transform>().position);
            if (dis <_Hero.attackdistance ||_Hero.targetenermy.gameObject.GetComponent<Enermys>().IsDead
           ||dis>_Hero.attackdistance+1.5f   )
            {
                  tween.Kill();
                _Hero.animator.SetBool("IsRun",false);
                _Hero.SetState(new Idle(_Hero));
                return;
            }
          
        }
  
    }
}