using UnityEngine;

public  class BasePanel : MonoBehaviour
{
    /// <summary>
    /// 入栈时调用
    /// </summary>
    public virtual void OnEnter(){}
    /// <summary>
    /// 暂停
    /// </summary>
    public virtual void OnPause(){}
    /// <summary>
    /// 重新激活
    /// </summary>
    public virtual void OnResume(){}
    /// <summary>
    /// 出栈时调用
    /// </summary>
    public virtual void OnExit(){}

  
}
