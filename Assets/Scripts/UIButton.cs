using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class UIButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    // Events for the button's actions. These are set in the inspector.
    public UnityEvent OnButtonClicked = new UnityEvent();
    public UnityEvent OnButtonDown = new UnityEvent();
    public UnityEvent OnButtonReleased = new UnityEvent();
    public UnityEvent<bool> OnButtonHover = new UnityEvent<bool>();

    public bool Activated { get; set; } = true;

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Activated)
            OnButtonReleased.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Activated)
        {
            OnButtonClicked.Invoke();
            OnButtonDown.Invoke();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Activated)
            OnButtonHover.Invoke(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Activated)
            OnButtonHover.Invoke(false);
    }
}

