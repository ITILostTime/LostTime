using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIAdminCommand : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool _isAdminCommandOn;
    private float _PointerDownTime;
    private float _PointerUpTime;

    private void FixedUpdate()
    {
        if(_isAdminCommandOn == true && (Time.time - _PointerUpTime) > 5)
        {
            _isAdminCommandOn = false;
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
