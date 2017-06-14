using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIVirtualRightJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private GameObject _canvas;
    private GameObject _rightJoystick;
    private GameObject _rightJoystickStick;
    private bool _isRightJoystickUsed;
    private Vector3 _rightJoystickInputVector;

    public bool IsRightJoystickUsed { get { return _isRightJoystickUsed; } set { _isRightJoystickUsed = value; } }

    private void Start()
    {
        _canvas = GameObject.Find("MenuCanvas");
        CreateJoystick();
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 RightJoystickPosition;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_rightJoystick.GetComponent<RectTransform>(), eventData.position,
            eventData.pressEventCamera, out RightJoystickPosition))
        {
            RightJoystickPosition.x = (RightJoystickPosition.x / _rightJoystick.GetComponent<RectTransform>().sizeDelta.x);
            RightJoystickPosition.y = (RightJoystickPosition.y / _rightJoystick.GetComponent<RectTransform>().sizeDelta.y);

            _rightJoystickInputVector = new Vector3(RightJoystickPosition.x * 2 + 1, 0, RightJoystickPosition.y * 2 - 1);
            _rightJoystickInputVector = (_rightJoystickInputVector.magnitude > 1.0f) ? _rightJoystickInputVector.normalized : _rightJoystickInputVector;

            _rightJoystickStick.GetComponent<RectTransform>().anchoredPosition = new Vector3(_rightJoystickInputVector.x * (_rightJoystick.GetComponent<RectTransform>().sizeDelta.x / 4),
                _rightJoystickInputVector.z * (_rightJoystick.GetComponent<RectTransform>().sizeDelta.y / 4));

            Debug.Log(_rightJoystickInputVector);
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        _rightJoystick.GetComponent<RectTransform>().position = new Vector2(eventData.position.x, eventData.position.y);
        _isRightJoystickUsed = true;
        OnDrag(eventData);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        _isRightJoystickUsed = false;
        _rightJoystickInputVector = new Vector3(0, 0, 0);
        ResetJoystickPosition();
    }

    private void CreateJoystick()
    {
        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("RightJoystick", GameObject.Find("RightJoystickPanel"), true,
            _canvas.GetComponent<RectTransform>().rect.height / 6, _canvas.GetComponent<RectTransform>().rect.height / 6, 0, 0, Color.white);
        _rightJoystick = GameObject.Find("RightJoystick");

        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("RightJoystickStick", GameObject.Find("RightJoystick"), true,
            _canvas.GetComponent<RectTransform>().rect.height / 8, _canvas.GetComponent<RectTransform>().rect.height / 8, 0, 0, Color.black);
        _rightJoystickStick = GameObject.Find("RightJoystickStick");
    }

    private void ResetJoystickPosition()
    {
        _rightJoystickStick.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
    }

    public float GetRightHorizontalPosition()
    {
        if (_rightJoystickInputVector.x != 0)
        {
            return _rightJoystickInputVector.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }

    public float GetRightVercitalPosition()
    {
        if (_rightJoystickInputVector.z != 0)
        {
            return _rightJoystickInputVector.z;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
}
