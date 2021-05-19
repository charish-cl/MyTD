
using Character;
using DG.Tweening;
using UnityEngine;

namespace Hero
{
    public class Hero : BaseCharacterElement,IBaseCharacterAction
    {

        public Animator animator;
        public bool isflip;
        
        
        public float attackdistance = 0.5f;
        public float movespeed = 1;
        
        public Vector3 target;
        private Vector3 localscale;
        public GameObject targetenermy;
        private Camera _camera;
        public Vector3 Idlepos;
        private State _herostate;
        private Tweener _tweener;
        private void Start()
        {
            _herostate =new Idle(this) ;
            Idlepos = transform.position;
            _camera = Camera.main;
            animator = this.transform.Find("model").GetComponent<Animator>();
            target = this.transform.position;
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
            
            if (Input.GetMouseButtonDown(1))
            {
                 _tweener.Kill();
                target = _camera.ScreenToWorldPoint(Input.mousePosition);
                float distance = Vector2.Distance(this.transform.position, target);
                Flip(target);
                animator.SetBool("IsRun",true);
               _tweener= transform.DOMove(new Vector3(target.x, target.y, 0), distance * movespeed);
            }

            if (Vector2.Distance(this.transform.position, target) < 0.2f)
            {
                animator.SetBool("IsRun",false);
            }
        }
        public void SetState( State  _state)
        {
            _herostate = _state;
           // Debug.Log(_state);
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
           
        }

        public void OnDead()
        {
          
        }
    }
}