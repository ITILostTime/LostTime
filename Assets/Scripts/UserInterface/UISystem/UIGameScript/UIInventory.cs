using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventory : MonoBehaviour, IPointerDownHandler
{

    private GameObject _canvas;
    private bool _UIInventoryPanelActivated;
    private bool _UIInventoryPanelAnimationOn;

    public bool UIInventoryPanelAnimationOn { get { return _UIInventoryPanelAnimationOn; } set { _UIInventoryPanelAnimationOn = value; } }
    public bool UIInventoryPanelActivated { get { return _UIInventoryPanelActivated; } set { _UIInventoryPanelActivated = value; } }

    private void Start()
    {
        _canvas = GameObject.Find("MenuCanvas");
    }

    private void Update()
    {
        if (GameObject.Find("UIInventoryPanel") == true && _UIInventoryPanelActivated == true && _UIInventoryPanelAnimationOn == true)
        {
            _UIInventoryPanelAnimationOn = _canvas.GetComponent<AnimationUserInterfaceController>().VrtAnimToUserInterface("UIInventoryPanel", 0, 0, -1);
        }
        else if (GameObject.Find("UIInventoryPanel") == true && _UIInventoryPanelActivated == false && _UIInventoryPanelAnimationOn == true)
        {
            _UIInventoryPanelAnimationOn = _canvas.GetComponent<AnimationUserInterfaceController>().VrtAnimToDestroy("UIInventoryPanel",
                _canvas.GetComponent<RectTransform>().rect.height, 1);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        CheckOpenPanel();

        if (GameObject.Find("UIInventoryPanel") == false)
        {
            _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("UIInventoryPanel", _canvas, true,
            _canvas.GetComponent<RectTransform>().rect.width / 3, (_canvas.GetComponent<RectTransform>().rect.height / 10) * 8,
            0, _canvas.GetComponent<RectTransform>().rect.height,
            _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteBackGround_03", _canvas.GetComponent<ImageMonitoring>()._BackGroundSprite));

            _UIInventoryPanelActivated = true;
            _UIInventoryPanelAnimationOn = true;
        }
        else
        {
            _UIInventoryPanelActivated = false;
            _UIInventoryPanelAnimationOn = true;
        }
    }

    private void CheckOpenPanel()
    {
        if (GameObject.Find("UIQuestBookPanel") == true)
        {
            GameObject.Find("UIQuestBookButton").GetComponent<UIQuestBook>().UIQuestBookAnimationOn = true;
            GameObject.Find("UIQuestBookButton").GetComponent<UIQuestBook>().UIQuestBookPanelActivated = false;
        }
        if (GameObject.Find("UIConfigurePanel") == true)
        {
            GameObject.Find("UIConfigureButton").GetComponent<UIConfigure>().UIConfigureAnimationOn = true;
            GameObject.Find("UIConfigureButton").GetComponent<UIConfigure>().UIConfigureActivated = false;
        }
        if (GameObject.Find("UIMapPanel") == true)
        {
            GameObject.Find("UIMapButton").GetComponent<UIMap>().UIMapPanelAnimationOn = true;
            GameObject.Find("UIMapButton").GetComponent<UIMap>().UIMapPanelActivated = false;
        }
    }
}
