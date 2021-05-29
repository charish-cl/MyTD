
using Character;
using DG.Tweening;
using UnityEngine;

namespace Hero
{
    public class Hero : BaseCharacterElement,IBaseCharacterAction
    {

        public Animator animator;
        public bool isflip;
        
        
        public float attackdistance = 1f;
        public float movespeed = 1;
        
        
        private Vector3 localscale;
        public GameObject targetenermy;
        private Camera _camera;

        public State _herostate;
        private Tweener _tweener;
        private void Start()
        {
            _herostate =new Idle(this) ;
        
            _camera = Camera.main;
            animator = this.transform.Find("model").GetComponent<Animator>();
         
            localscale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            
        }

        private void Update()
        {
            _herostate.OnStateUpdate();
        }

        private void LateUpdate()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            
            // if (Input.GetMouseButtonDown(1))
            // {
            //      _tweener.Kill();
            //     target = _camera.ScreenToWorldPoint(Input.mousePosition);
            //     float distance = Vector2.Distance(this.transform.position, target);
            //     Flip(target);
            //     animator.SetBool("IsRun",true);
            //    _tweener= transform.DOMove(new Vector3(target.x, target.y, 0), distance * movespeed);
            // }
            //
            // if (Vector2.Distance(this.transform.position, target) < 0.2f)
            // {
            //     animator.SetBool("IsRun",false);
            // }
        }
        public void SetState( State  _state)
        {
            _herostate = _state;
           Debug.Log("切换状态   :       "+_state);
        }
        public void Flip(Vector3 target)
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

        public void Attack()
        {
            throw new System.NotImplementedException();
        }

        public void OnDamage(float damage)
        {
            // hp-=(int )damage;
            // if(hp<=0) OnDead();
            // Debug.Log("英雄受到伤害");
        }

        public void OnDead()
        {
          gameObject.SetActive(false);
        }
    }
}