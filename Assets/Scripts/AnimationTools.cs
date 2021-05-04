using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AnimationTools : MonoBehaviour
{
   [Header("初始放大尺寸")]
   public float size;
   private Vector3 rawScale;
   [Header("动画时间")]
   public float seconds=0.5f;
   /// <summary>
   /// Start is called on the frame when a script is enabled just before
   /// any of the Update methods is called the first time.
   /// </summary>
   void Start()
   {
       rawScale=this.transform.localScale;
   }
   void OnEnable()
   {

         this.transform.DOScale(size*this.transform.localScale,seconds).SetAutoKill();
        
   }

   void OnDisable()
   {
       this.transform.localScale=rawScale;
   }
}
