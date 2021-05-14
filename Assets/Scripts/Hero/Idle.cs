using System.Linq;
using UnityEngine;

namespace Hero
{
    public class Idle:State
    {
       
        public Hero _Hero;
        public Idle(Hero hero)
        {
            _Hero = hero;
        }
        public void OnStateEnter()
        {
         
        }

        public void OnStateUpdate()
        {
          FindEnermy();
        }

        public void OnStateExit()
        {
          
        }
        private void FindEnermy()
        {
            if(GameObjectPool._enermypool.Count==0) return;
            foreach (var enermy in GameObjectPool._enermypool.Where(e=>e.activeInHierarchy))
            {
               
                if (Vector2.Distance(_Hero.transform.position,enermy.transform.position)<_Hero.attackdistance)
                {
                    _Hero.targetenermy = enermy;
                    _Hero.SetState(new Attack(_Hero));
                    return;
                }
            }
        }
    }
}