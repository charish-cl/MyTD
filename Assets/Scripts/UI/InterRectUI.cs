using System;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using Manage;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InterRectUI : MonoBehaviour
    {
        /// <summary>
        /// 塔的建造
        /// </summary>
        public GameObject towerbuild;

        /// <summary>
        /// 塔升级UI
        /// </summary>
        public GameObject towerupgrad;

        /// <summary>
        /// 角色圆环
        /// </summary>
        public GameObject characteraround;

        /// <summary>
        /// 角色信息
        /// </summary>
        public GameObject charcterInfo;

        /// <summary>
        /// 点击对象
        /// </summary>
        public GameObject clickobject;

        

        

        private Camera UICamera;
        private Stack<GameObject> uiStack;
        private bool isskill;

     

    
        private void Start()
        {
            UICamera = Camera.main;

        }
        private void Update()
        {
         
            if (Input.GetMouseButtonDown(0))
            {
                
                Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(myRay.origin.x, myRay.origin.y), Vector2.down);
  
                    if (hit.collider!=null)
                    {
                        var clickposition = UICamera.WorldToScreenPoint(hit.collider.gameObject.transform.position);
                        switch (hit.collider.tag)
                        {
                            case "建造点":
                                towerbuild.transform.position = clickposition;
                                towerbuild.SetActive(true);
                                break;
                            case "英雄":
                                characteraround.transform.position = clickposition;
                                charcterInfo.SetActive(true);
                                charcterInfo.transform.DOMoveY(40, 0.4f);
                                characteraround.SetActive(true);
                                break;
                        }
                    }
                    else
                    {
                        CloseUI();
                    }
            }
        }

        private void CloseUI()
        {
            towerbuild.SetActive(false);
            characteraround.SetActive(false);
            charcterInfo.transform.DOMoveY(-40, 0.4f);
            charcterInfo.SetActive(false);
        }
    }
}