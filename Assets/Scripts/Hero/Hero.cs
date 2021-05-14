using System;
using System.Collections;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Hero
{
    public class Hero : MonoBehaviour
    {

        public Animator animator;
        public bool isflip;
        
        
        public float attackdistance = 0.5f;
        public float movespeed = 1;
        
        public Vector3 target;
        private Vector3 localscale;
        public GameObject targetenermy;
        private Camera _camera;
        
        private State _herostate;
        private bool state_start;

        private void Start()
        {
            _herostate =new Idle(this) ;
            
            _camera = Camera.main;
            animator = this.transform.Find("model").GetComponent<Animator>();
            target = this.transform.position;
            localscale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            
        }

        private void Update()
        {
         
            if (!state_start)
            {
                _herostate.OnStateEnter();
                state_start = true;
            }

            if (state_start)
            {
                _herostate.OnStateUpdate();
            }

        }

        private void LateUpdate()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            
            if (Input.GetMouseButtonDown(1))
            {
                target = _camera.ScreenToWorldPoint(Input.mousePosition);
                float distance = Vector2.Distance(this.transform.position, target);
                Flip(target);
                animator.SetBool("IsRun",true);
                transform.DOMove(new Vector3(target.x, target.y, 0), distance * movespeed);
                
            }

            if (Vector2.Distance(this.transform.position, target) < 0.2f)
            {
                animator.SetBool("IsRun",false);
            }
        }
        public void SetState(State _state)
        {
            _herostate.OnStateExit();
            _herostate = _state;
            state_start = false;

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
    }
}