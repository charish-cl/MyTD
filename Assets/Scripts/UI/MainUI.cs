using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Manage;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
  
   private Dictionary<string, Text> all = new Dictionary<string, Text>();
   public static MainUI Instance;
   public GameData Data;
   private Tween _tween;
   private void Start()
   {
       Data = GameData.GetInstance();
       Instance = this;
       var text= GetComponentsInChildren<Text>();
       foreach (var tex in text)
       {
           all.Add(tex.name,tex);
       
       }
       all["第n波"].gameObject.SetActive(false);
        SetTextUI("金币",Data.coin.ToString());
        SetTextUI("血量",Data.base_hp.ToString());
   }

   public  void SetTextUI(string name,string tex)
   {
      if(all.ContainsKey(name))
       all[name].text = tex;
   }

   public void DisaplayWaveText(int n)
   {
       if (all.ContainsKey("第n波"))
       {
           var temp = all["第n波"];
           temp.text= "Wave    " + n.ToString();
            all["第n波"].gameObject.SetActive(true);
           
           SetTextUI("波",n.ToString() + "/20波");
           temp.DOFade(1, 3).onComplete+=(delegate
           {
               temp.DOFade(0, 0.1f);
           });
         
       }
   }
}
