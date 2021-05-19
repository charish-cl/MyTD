using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    /// <summary>
    /// 鼠标指针
    /// </summary>
    public Texture2D cursonTexture;
    
    /// <summary>
    /// 法术
    /// </summary>
    private Button skill;

    public Image skillImage;

    public float cd;
    private Timer skillTimer;

    bool isskill;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        skill = this.GetComponent<Button>();
        skillTimer=Timer.Register(cd, () =>  {   });
     
        skill.onClick.AddListener(() =>
        {
            if (!skillTimer.isCompleted) return; 
            
            Cursor.SetCursor(cursonTexture,Vector2.zero,CursorMode.Auto);
            isskill = true;
        });
    }

    private void Update()
    {
        skillImage.fillAmount =1- skillTimer.GetRatioComplete();
        if (isskill)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isskill = false; 
                Cursor.SetCursor(null, default, CursorMode.Auto);
                var go=    GameObjectPool.GetPooledObject("Hero");
                var pos = _camera.ScreenToWorldPoint(Input.mousePosition);
                go.transform.position =new Vector3(pos.x,pos.y,0 );
                skillTimer=Timer.Register(cd, () =>  {   });

            }
        }
    }
}