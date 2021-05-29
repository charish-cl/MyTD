using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TowerUI : MonoBehaviour
    {
        public List<GameObject> texttips;
        public Action Callback;
        public Vector3 pos;
        private void Start()
        {
            var buttons=    GetComponentsInChildren<Button>();
           
            buttons[0].onClick.AddListener(
                (delegate
                {
                    var go = Resources.Load("Prefabs/弓箭");
                    GameObject.Instantiate(go, pos, new Quaternion());
                    gameObject.SetActive(false);
                })
            );
        }

        private void OnEnable()
        {
            foreach (var texttip in texttips)
            {
                texttip.gameObject.SetActive(false);
            }
        }
    }
}
