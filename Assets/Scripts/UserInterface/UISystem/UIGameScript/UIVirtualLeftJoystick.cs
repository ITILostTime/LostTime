using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIVirtualLeftJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    private GameObject _canvas;
    private GameObject _leftJoystick;
    private GameObject _leftJoystickStick;
    private bool _isLeftJoystickUsed;
    private Vector3 _leftJoystickInputVector;

    public bool IsleftJoystickUsed { get { return _isLeftJoystickUsed; } set { _isLeftJoystickUsed = value; } }

    private void Start()
    {
        _canvas = GameObject.Find("MenuCanvas");
        CreateJoystick();
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 RightJoystickPosition;
        GetJoystickEnabled();

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_leftJoystick.GetComponent<RectTransform>(), eventData.position,
            eventData.pressEventCamera, out RightJoystickPosition))
        {
            RightJoystickPosition.x = (RightJoystickPosition.x / _leftJoystick.GetComponent<RectTransform>().sizeDelta.x);
            RightJoystickPosition.y = (RightJoystickPosition.y / _leftJoystick.GetComponent<RectTransform>().sizeDelta.y);

            _leftJoystickInputVector = new Vector3(RightJoystickPosition.x * 2 + 1, 0, RightJoystickPosition.y * 2 - 1);
            _leftJoystickInputVector = (_leftJoystickInputVector.magnitude > 1.0f) ? _leftJoystickInputVector.normalized : _leftJoystickInputVector;

            _leftJoystickStick.GetComponent<RectTransform>().anchoredPosition = new Vector3(_leftJoystickInputVector.x * (_leftJoystick.GetComponent<RectTransform>().sizeDelta.x / 4),
                _leftJoystickInputVector.z * (_leftJoystick.GetComponent<RectTransform>().sizeDelta.y / 4));

            Debug.Log(_leftJoystickInputVector);
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        _leftJoystick.GetComponent<RectTransform>().position = new Vector2(eventData.position.x, eventData.position.y);
        _isLeftJoystickUsed = true;
        OnDrag(eventData);
        GetJoystickEnabled();
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        _isLeftJoystickUsed = false;
        _leftJoystickInputVector = new Vector3(0, 0, 0);
        ResetJoystickPosition();
        GetJoystickDisabled();
    }

    private void CreateJoystick()
    {
        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("LeftJoystick", GameObject.Find("LeftJoystickPanel"), true,
            _canvas.GetComponent<RectTransform>().rect.height / 6, _canvas.GetComponent<RectTransform>().rect.height / 6, 0, 0, Color.white);
        _leftJoystick = GameObject.Find("LeftJoystick");

        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("LeftJoystickStick", GameObject.Find("LeftJoystick"), true,
            _canvas.GetComponent<RectTransform>().rect.height / 8, _canvas.GetComponent<RectTransform>().rect.height / 8, 0, 0, Color.black);
        _leftJoystickStick = GameObject.Find("LeftJoystickStick");

        GetJoystickDisabled();
    }

    private void ResetJoystickPosition()
    {
        _leftJoystickStick.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
    }

    public float GetLeftHorizontalPosition()
    {
        if (_leftJoystickInputVector.x != 0)
        {
            return _leftJoystickInputVector.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }

    public float GetLeftVercitalPosition()
    {
        if (_leftJoystickInputVector.z != 0)
        {
            return _leftJoystickInputVector.z;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }


    private void GetJoystickEnabled()
    {
        _leftJoystick.GetComponent<Image>().enabled = true;
        _leftJoystickStick.GetComponent<Image>().enabled = true;
    }

    private void GetJoystickDisabled()
    {
        _leftJoystick.GetComponent<Image>().enabled = false;
        _leftJoystickStick.GetComponent<Image>().enabled = false;
    }
}
