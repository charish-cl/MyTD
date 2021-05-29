using System.Collections.Generic;
using UnityEngine;
using LitJson;

namespace UI
{
 public class UIPanelManager
{
    private static UIPanelManager _instance;
    private Transform canvasTransform;
    private Transform CanvasTransform
    {
        get
        {
            if (canvasTransform == null)
            {
                canvasTransform = GameObject.Find("Canvas").transform;
            }
            return canvasTransform;
        }
    }
    public static UIPanelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIPanelManager();
            }


            return _instance;
        }
    }

    
    private Dictionary<string, string> panelPathDict;
    
    private Dictionary<UIPanelType, BasePanel> panelDict;
    
    private Stack<BasePanel> panelStack;

    private UIPanelManager()
    {
        ParseUIPanelTypeJson();
    }

    public void PushPanel(UIPanelType panelType)
    {
        
        if (panelStack == null)
        {
            panelStack = new Stack<BasePanel>();
        }

        //停止上一个界面
        if (panelStack.Count > 0)
        {
            BasePanel topPanel = panelStack.Peek();
            topPanel.OnPause();
        }

        BasePanel panel = GetPanel(panelType);
        panelStack.Push(panel);
        panel.OnEnter();
    }

    public void PopPanel()
    {
        if (panelStack == null)
        {
            panelStack = new Stack<BasePanel>();
        }
        if (panelStack.Count <= 0)
        {
            return;
        }

        //退出栈顶面板
        BasePanel topPanel = panelStack.Pop();
        topPanel.OnExit();

        //恢复上一个面板
        if (panelStack.Count > 0)
        {
            BasePanel panel = panelStack.Peek();
            panel.OnResume();
        }

    }

    private BasePanel GetPanel(UIPanelType panelType)
    {

        if (panelDict == null)
        {
            panelDict = new Dictionary<UIPanelType, BasePanel>();
        }

        BasePanel panel = panelDict.GetValue(panelType);

        //如果没有实例化面板，寻找路径进行实例化，并且存储到已经实例化好的字典面板中
        if (panel == null)
        {
            string path=panelPathDict.GetValue(panelType.ToString());
            GameObject panelGo = GameObject.Instantiate(Resources.Load<GameObject>(path), CanvasTransform, false);
            panel = panelGo.GetComponent<BasePanel>();
            panelDict.Add(panelType, panel);
        }
        return panel;
    }
  
    
    //解析json文件
    private void ParseUIPanelTypeJson()
    {
        panelPathDict = new Dictionary<string, string>();
        TextAsset textUIPanelType = Resources.Load<TextAsset>("Json/UIPanelTypeJson");
        UIPanelInfoList panelInfoList = JsonMapper.ToObject<UIPanelInfoList>(textUIPanelType.text);

        foreach (UIPanelInfo panelInfo in panelInfoList.panelInfoList)
        {
            panelPathDict.Add(panelInfo.panelType, panelInfo.path);
         
        }
    }
}

}
