using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltipText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipText.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipText.SetActive(false);
    }
}
