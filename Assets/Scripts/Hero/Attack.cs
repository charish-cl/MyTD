using UnityEngine;

namespace Hero
{
    public class Attack:State
    {
        public Hero _Hero;
        public Attack(Hero hero)
        {
            _Hero = hero;
            Debug.Log("攻击");
        }
        public void OnStateEnter()
        {
            _Hero.animator.SetBool("IsAttack",true);
        }

        public void OnStateUpdate()
        {
            AttackEnermy();
        }

        public void OnStateExit()
        {
            
        }
        private void AttackEnermy()
        {
                //攻击行为
                //敌人死亡或者超出攻击范围，停止攻击切换状态
                if (Vector2.Distance(_Hero.transform.position, _Hero.targetenermy.gameObject.GetComponent<Transform>().position) >
                   _Hero.attackdistance||_Hero.targetenermy.gameObject.GetComponent<Enermys>().IsDead)
                {
                  
                   _Hero.animator.SetBool("IsAttack",false);
                   _Hero.SetState(new Idle(this._Hero));
                    return;
                }
                //调整攻击方向
                _Hero.Flip(_Hero.targetenermy.transform.position);
            
                var animatorInfo =_Hero.animator.GetCurrentAnimatorStateInfo (0);
            
                if ((animatorInfo.normalizedTime%1>0.99f))//normalizedTime: 范围0 -- 1,  0是动作开始，1是动作结束
                {
                    Debug.Log("攻击");
                    _Hero.targetenermy.GetComponent<Enermys>().OnDamaged(4);//播放完成后敌人收到伤害
                }

               
               
            }
        }

    }
