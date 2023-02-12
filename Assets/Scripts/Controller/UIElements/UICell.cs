using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICell : MonoBehaviour
{
    public Action<Vector2> Swipe;
    private Vector2 PointerDownPos;
    public void OnPointerDown(BaseEventData data)
    {
        PointerEventData pointerData = data as PointerEventData;
        PointerDownPos = pointerData.position;
    }
    public void OnPointerUp(BaseEventData data)
    {
        PointerEventData pointerData = data as PointerEventData;
        Swipe?.Invoke(pointerData.position - PointerDownPos);
    }
}
