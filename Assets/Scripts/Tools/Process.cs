
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// 进度条
/// </summary>
public class Process: MonoBehaviour
{
    private AsyncOperation aync;
    public Image load; // 进度条的图片
    private int culload = 0; // 已加载的进度
    public Text loadtext; // 百分制显示进度
    public string scene;//将要加载的场景

    void Start()
    {
        StartCoroutine("LoadScence",2);
    }

    // 定义一个迭代器，每一帧返回一次当前的载入进度，同时关闭自动的场景跳转
    // 因为LoadScenceAsync每帧加载一部分游戏资源，每次返回一个有跨越幅度的progress进度值
    // 当游戏资源加载完毕后，LoadScenceAsync会自动跳转场景，所以并不会显示进度条达到了100%
    // 关闭自动场景跳转后，LoadSceneAsync只能加载90%的场景资源，剩下的10%场景资源要在开启自动场景跳转后才加载
    IEnumerator LoadScence()
    {
        aync = SceneManager.LoadSceneAsync(scene);//要跳转的场景
        aync.allowSceneActivation = false;
        yield return aync;
    }

    void Update()
    {
        // 判断是否有场景正在加载
        if (aync == null)
        {
            return;
        }
        int progrssvalue = 0;
        // 当场景加载进度在90%以下时，将数值以整数百分制呈现，当资源加载到90%时就将百分制进度设置为100，
        if (aync.progress < 0.9f)
        {
            progrssvalue = (int)aync.progress * 100;
        }
        else
        {
            progrssvalue = 100;
        }
        // 每帧对进度条的图片和Text百分制数据进行更改，为了实现数字的累加而不是跨越
        if (culload < progrssvalue)
        {
            culload++;
            load.fillAmount = culload / 100f;
            loadtext.text = culload.ToString() + "%";
        }
        // 一旦进度到达100时，开启自动场景跳转，LoadSceneAsync会加载完剩下的10%的场景资源
        if (culload == 100)
        {
            aync.allowSceneActivation = true;
        }
    }
}

