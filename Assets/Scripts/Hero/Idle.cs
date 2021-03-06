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
        
          var enermy=  GameObjectPool._enermypool.Where(e =>
                !e.GetComponent<Enermys>().IsDead).OrderBy(
                e => Vector2.Distance(_Hero.transform.position, e.transform.position)
            ).First();
           var min = Vector2.Distance(_Hero.transform.position, enermy.transform.position);
            if(enermy is null) return;
            if (min<_Hero.attackdistance+1&&min>_Hero.attackdistance)
            {
                _Hero.targetenermy = enermy;
                _Hero.SetState(new Run(_Hero));
                return;
            }
            else if (min<_Hero.attackdistance)
            {
                _Hero.targetenermy = enermy;
                _Hero.SetState(new Attack(_Hero));
                return;
            }
        }
    }
}