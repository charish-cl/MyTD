

using Skill;
using UnityEngine;

public class Skill1 :BaseSkill
{
    public override void ReleaseSkill()
    {
     var huo=   GameObjectPool.GetPooledObject("火");
     var mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
     huo.transform.position=new Vector3(mouse.x,mouse.y,0);
     Timer.Register(0.5f, (delegate { huo.gameObject.SetActive(false); }));
    }
}
