
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Texttip : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public GameObject text;
  
    public void OnPointerEnter(PointerEventData eventData)
    {
      
            text.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
     
        text.SetActive(false);
    }
}
