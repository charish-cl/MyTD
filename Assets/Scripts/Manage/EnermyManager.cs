using System;
using System.Collections;
using UnityEngine;

namespace Manage
{
    public class EnermyManager:Singleton<EnermyManager>
    {
        private int wavenum=0;
        /// <summary>
        /// 生成敌人,并初始化
        /// </summary>
        public IEnumerator Action()
        {
     
            var wave=XmlUntity.GetInstance().GetCurrentWave();
            //显示UI
           MainUI.Instance.DisaplayWaveText(  ++wavenum);
            //等待时间
            yield return new WaitForSeconds(int.Parse (wave.Attribute("waittime").Value));
            var temp=wave.Elements("Enermy");
            //生成敌人
            foreach (var item in temp)
            {  for (int i = 0; i < int.Parse(item.Value); i++)
                {
                    var go= EnermySpawn.GetInstance().EnermyBuilder(item.Attribute("EnermyType").Value);
                   
                    yield return new WaitForSeconds(1.2f);
                }   
            }
        }
        /// <summary>
        /// 查看是否所有敌人死亡
        /// </summary>
        /// <returns></returns>
        bool IsAllEnermyDead()
        {
            if(GameObject.FindGameObjectWithTag("敌人").activeInHierarchy) return false;
            return true;
        }

       
        
        
    }
}