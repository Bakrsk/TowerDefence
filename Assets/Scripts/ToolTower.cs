using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTower : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _buttonShow;
    public void OnPointerEnter(PointerEventData eventData)
    {
        _buttonShow.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _buttonShow.SetActive(false);
    }
}
