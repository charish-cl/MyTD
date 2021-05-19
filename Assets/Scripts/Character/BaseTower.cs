using System.Linq;
using Hero;
using UnityEngine;
namespace Character
{
    public interface TowerState
    {
        void Handle();
    }


    public abstract class BaseTower:MonoBehaviour
    {
        [Header("花费")] public int cost;
        public int attack;
        public float attackspeed;
        public float attackdistance;
        public string weapon;
        public GameObject target;

        protected void Init(int cost, int attack, float attackspeed, float attackdistance, string weapon, GameObject target, TowerState state)
        {
            this.cost = cost;
            this.attack = attack;
            this.attackspeed = attackspeed;
            this.attackdistance = attackdistance;
            this.weapon = weapon;
            this.target = target;
            this.state = state;
        }

        public TowerState state;
        public  bool FindEnermy()
        {
            if(GameObjectPool._enermypool.Count==0) return false;
            foreach (var enermy in GameObjectPool._enermypool.Where(e=>
                !e.GetComponent<Enermys>().IsDead))
            {
                if (Vector2.Distance( transform.position,enermy.transform.position)<attackdistance)
                {
                    target= enermy;
                    return true;
                }
            }

            return false;
        }

        public bool IsStopAttack()
        {
            if (Vector2.Distance(transform.position, target.transform.position) >
              attackdistance||target.GetComponent<Enermys>().IsDead)
            {
                return true;
            }

            return false;
        }
        public void SetState(TowerState state)
        {
            this.state = state;
            Debug.Log(state);
        }
    }
}