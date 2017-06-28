using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIAdminCommand : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private bool _isAdminCommandOn;
    private float _PointerDownTime;
    private float _PointerUpTime;

    public bool IsAdminCommandOn
    {
        get
        {
            return _isAdminCommandOn;
        }

        set
        {
            _isAdminCommandOn = value;
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        _PointerDownTime = Time.time;
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(_PointerUpTime + ", " +  _PointerDownTime);
        if((Time.time - _PointerDownTime) > 10)
        {
            _isAdminCommandOn = true;
        }
        _PointerUpTime = Time.time;
    }
}
