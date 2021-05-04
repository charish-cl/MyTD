using UnityEngine;
using  UI;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button a;
    public Button b;
    public Button c;
    
    void Start () {
        UIPanelManager panelManager = UIPanelManager.Instance;
        // panelManager.PushPanel(UIPanelType.panel);
        a.onClick.AddListener(OpenPanel1);
        b.onClick.AddListener(OpenPanel2);
        c.onClick.AddListener(OpenPanel3);
    }

    void OpenPanel1()
    {
        UIPanelManager.Instance.PushPanel(UIPanelType.panel);
    }
    void OpenPanel2()
    {
        UIPanelManager.Instance.PushPanel(UIPanelType.pane2);
    }
    void OpenPanel3()
    {
        UIPanelManager.Instance.PushPanel(UIPanelType.pane3);
    }
}
