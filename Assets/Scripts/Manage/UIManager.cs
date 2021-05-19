using UnityEngine;
using UnityEngine.UI;

namespace Manage
{
    public class UIManager
    {
        [Header("金币显示")] public  Text Moneytext;
        [Header("波数显示")] public  Text Wavetext;
        [Header("基地生命值")] public Text HomeText;
        void RefreshUI()
        {
           Moneytext.text=GameData.GetInstance().money.ToString();    
        }

    }
}