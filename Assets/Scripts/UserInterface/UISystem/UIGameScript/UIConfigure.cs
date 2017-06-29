using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIConfigure : MonoBehaviour, IPointerDownHandler
{

    private GameObject _canvas;
    private bool _UIConfigureActivated;
    private bool _UIConfigureAnimationOn;

    public bool UIConfigureAnimationOn { get { return _UIConfigureAnimationOn; } set { _UIConfigureAnimationOn = value; } }
    public bool UIConfigureActivated { get { return _UIConfigureActivated; } set { _UIConfigureActivated = value; } }

    private void Start()
    {
        _canvas = GameObject.Find("MenuCanvas");
    }

    private void Update()
    {
        if (GameObject.Find("UIConfigurePanel") == true && _UIConfigureActivated == true && _UIConfigureAnimationOn == true)
        {
            _UIConfigureAnimationOn = _canvas.GetComponent<AnimationUserInterfaceController>().VrtAnimToUserInterface("UIConfigurePanel", 0, 0, -1);
        }
        else if (GameObject.Find("UIConfigurePanel") == true && _UIConfigureActivated == false && _UIConfigureAnimationOn == true)
        {
            _UIConfigureAnimationOn = _canvas.GetComponent<AnimationUserInterfaceController>().VrtAnimToDestroy("UIConfigurePanel",
                _canvas.GetComponent<RectTransform>().rect.height, 1);
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
        if (GameObject.Find("UIMapPanel") == true)
        {
            GameObject.Find("UIMapButton").GetComponent<UIMap>().UIMapPanelAnimationOn = true;
            GameObject.Find("UIMapButton").GetComponent<UIMap>().UIMapPanelActivated = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        CheckOpenPanel();

        if (GameObject.Find("UIConfigurePanel") == false)
        {
            _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("UIConfigurePanel", _canvas, true,
            _canvas.GetComponent<RectTransform>().rect.width / 3, (_canvas.GetComponent<RectTransform>().rect.height / 10) * 8,
            0, _canvas.GetComponent<RectTransform>().rect.height,
            _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteBackGround_03", _canvas.GetComponent<ImageMonitoring>()._BackGroundSprite));

            _UIConfigureActivated = true;
            _UIConfigureAnimationOn = true;
        }
        else
        {
            _UIConfigureActivated = false;
            _UIConfigureAnimationOn = true;
        }
    }
}
