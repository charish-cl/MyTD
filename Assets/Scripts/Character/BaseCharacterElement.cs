using UnityEngine;

namespace Character
{
    public abstract class BaseCharacterElement:MonoBehaviour
    {
        public  void Init(int hp, float movespeed, int attack, float attackspeed, float attackdistance, int defence)
        {
            this.hp = hp;
            this.movespeed = movespeed;
            this.attack = attack;
            this.attackspeed = attackspeed;
            this.attackdistance = attackdistance;
            this.defence = defence;
        }

        /// <summary>
        /// 血量
        /// </summary>
        public int hp { get; set; }
        
        
        /// <summary>
        /// 移速
        /// </summary>
        public float movespeed { get; set; }

        /// <summary>
        /// 攻击
        /// </summary>
        public int attack { get; set; }
        public float attackspeed { get; set; }
        public float attackdistance{ get; set; } 

        /// <summary>
        /// 防御力
        /// </summary>
        public int defence{ get; set; }

        /// <summary>
        /// 是否死亡
        /// </summary>
        public bool IsDead;
    }
}