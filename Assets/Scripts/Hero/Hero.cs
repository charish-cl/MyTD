using System;
using System.Collections;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Hero
{
    public class Hero : MonoBehaviour
    {
        public enum HeroState
        {
            Run,
            Idle,
            Attack
        }

        private Animator animator;
        private bool isflip;
        private bool isattacktime;
        private float movespeed = 1;
        public HeroState _state;
        private Vector3 target;
        private Vector3 localscale;
        public GameObject targetenermy;
        public float attackdistance = 1;
        private Timer _timer;
        private bool isattcktime;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            _state = HeroState.Idle;
            animator = this.transform.Find("model").GetComponent<Animator>();
            target = this.transform.position;
            localscale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                target = _camera.ScreenToWorldPoint(Input.mousePosition);
                float distance = Vector2.Distance(this.transform.position, target);
                Flip(target);
                transform.DOMove(new Vector3(target.x, target.y, 0), distance * movespeed);
                animator.Play("Run");
                _state = HeroState.Run;
            }

            switch (_state)
            {
                case HeroState.Idle:
                    FindEnermy();
                    break;
                case HeroState.Run:
                    if (Vector2.Distance(this.transform.position, target) < 0.2f)
                    {
                        animator.Play("Idle");
                        _state = HeroState.Idle;
                    }

                    break;
                case HeroState.Attack:
                    Attack();
                    break;
            }
        }


        private void FindEnermy()
        {
            foreach (var enermy in GameObject.FindGameObjectsWithTag("敌人"))
            {
                if (!enermy.activeInHierarchy) break;
                if (Vector2.Distance(transform.position, enermy.gameObject.GetComponent<Transform>().position) <
                    attackdistance)
                {
                    targetenermy = enermy;
                    _state = HeroState.Attack;
                    return;
                }
            }
        }

        private void Attack()
        {
            //攻击行为
            if (!isattacktime)
            {
                //敌人死亡或者超出攻击范围，停止攻击切换状态
                if (Vector2.Distance(transform.position, targetenermy.gameObject.GetComponent<Transform>().position) >
                    attackdistance
                    || targetenermy.gameObject.GetComponent<Enermys>().IsDead)
                {
                    Debug.Log("停止");
                    animator.Play("Idle");
                    _state = HeroState.Idle;
                    return;
                }

                //调整攻击方向
                Flip(targetenermy.transform.position);
                animator.Play("Attack");
                isattacktime = true;
                _timer = Timer.Register(1f, () =>
                {
                    Debug.Log("攻击");
                    targetenermy.GetComponent<Enermys>().OnDamaged(1);
                    isattacktime = false;
                });
            }
        }


        private void Flip(Vector3 target)
        {
            if ((this.transform.position.x - target.x) < 0)
            {
                isflip = false;
            }
            else
            {
                isflip = true;
            }

            transform.localScale = new Vector3((isflip ? 1 : -1) * localscale.x, localscale.y, localscale.z);
        }
    }
}