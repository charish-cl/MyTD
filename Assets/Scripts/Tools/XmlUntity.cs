using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class XmlUntity:Singleton<XmlUntity>
{
    /// <summary>
    /// 所有怪物队列
    /// </summary>
    Queue<XElement> enermy_queue;
    public void Read(){ 
    enermy_queue=new Queue<XElement>();
    TextAsset text=Resources.Load("Xml/WaveEnermy") as TextAsset;
    XDocument document=XDocument.Parse(text.text);
    XElement el = document.Element("Elements");
    var allwave=el.Element("Waves").Elements("Wave");
    foreach (var item in allwave) enermy_queue.Enqueue(item);
   }
   public XElement  GetCurrentWave(){
       if(enermy_queue.Count!=0) return enermy_queue.Dequeue();
       else  Debug.Log("队列为空");
       return null;
   }
}
