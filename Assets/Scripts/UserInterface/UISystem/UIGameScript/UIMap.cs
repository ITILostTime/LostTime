using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIMap : MonoBehaviour, IPointerDownHandler
{
    private GameObject _canvas;
    private bool _UIMapPanelActivated;
    private bool _UIMapPanelAnimationOn;

    public bool UIMapPanelAnimationOn { get { return _UIMapPanelAnimationOn; } set { _UIMapPanelAnimationOn = value; } }
    public bool UIMapPanelActivated { get { return _UIMapPanelActivated; } set { _UIMapPanelActivated = value; } }


    private void Start()
    {
        _canvas = GameObject.Find("MenuCanvas");
    }

    private void Update()
    {
        if (GameObject.Find("UIMapPanel") == true && _UIMapPanelActivated == true && _UIMapPanelAnimationOn == true)
        {
            _UIMapPanelAnimationOn = _canvas.GetComponent<AnimationUserInterfaceController>().VrtAnimToUserInterface("UIMapPanel", 0, 0, -1);
        }
        else if (GameObject.Find("UIMapPanel") == true && _UIMapPanelActivated == false && _UIMapPanelAnimationOn == true)
        {
            _UIMapPanelAnimationOn = _canvas.GetComponent<AnimationUserInterfaceController>().VrtAnimToDestroy("UIMapPanel",
                _canvas.GetComponent<RectTransform>().rect.height, 1);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        CheckOpenPanel();

        if (GameObject.Find("UIMapPanel") == false)
        {
            _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("UIMapPanel", _canvas, true,
            _canvas.GetComponent<RectTransform>().rect.width / 3, (_canvas.GetComponent<RectTransform>().rect.height / 10) * 8,
            0, _canvas.GetComponent<RectTransform>().rect.height, 
            _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteOther_03", _canvas.GetComponent<ImageMonitoring>()._other));

            _UIMapPanelActivated = true;
            _UIMapPanelAnimationOn = true;
        }
        else
        {
            _UIMapPanelActivated = false;
            _UIMapPanelAnimationOn = true;
        }
    }

    private void CheckOpenPanel()
    {
        if (GameObject.Find("UIQuestBookPanel") == true)
        {
            GameObject.Find("UIQuestBookButton").GetComponent<UIQuestBook>().UIQuestBookAnimationOn = true;
            GameObject.Find("UIQuestBookButton").GetComponent<UIQuestBook>().UIQuestBookPanelActivated = false;
        }
        if (GameObject.Find("UIInventoryPanel") == true)
        {
            GameObject.Find("InventoryButton").GetComponent<UIInventory>().UIInventoryPanelAnimationOn = true;
            GameObject.Find("InventoryButton").GetComponent<UIInventory>().UIInventoryPanelActivated = false;
        }
        if (GameObject.Find("UIConfigurePanel") == true)
        {
            GameObject.Find("UIConfigureButton").GetComponent<UIConfigure>().UIConfigureAnimationOn = true;
            GameObject.Find("UIConfigureButton").GetComponent<UIConfigure>().UIConfigureActivated = false;
        }
    }
}
