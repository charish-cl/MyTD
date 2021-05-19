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
        public void OnStateUpdate()
        {
          FindEnermy();
        }

        private void FindEnermy()
        {
            if(GameObjectPool._enermypool.Count==0) return;
            foreach (var enermy in GameObjectPool._enermypool.Where(e=>
                !e.GetComponent<Enermys>().IsDead))
            {
               
                if (Vector2.Distance(_Hero.transform.position,enermy.transform.position)<_Hero.attackdistance+1)
                {
                    _Hero.targetenermy = enermy;
                   _Hero.SetState(new Run(_Hero));
                    return;
                }
            }
        }
    }
}