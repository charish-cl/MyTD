using UnityEngine;
using Skill;
public class Skill2 : BaseSkill
{
    public override void ReleaseSkill()
    {
        var go = GameObjectPool.GetPooledObject("Hero");
        var mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        go.transform.position=new Vector3(mouse.x,mouse.y,0);
    }
}
