using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIQuestBook : MonoBehaviour, IPointerDownHandler
{

    private GameObject _canvas;
    private bool _UIQuestBookPanelActivated;
    private bool _UIQuestBookAnimationOn;

    public bool UIQuestBookAnimationOn { get { return _UIQuestBookAnimationOn; } set { _UIQuestBookAnimationOn = value; } }
    public bool UIQuestBookPanelActivated { get { return _UIQuestBookPanelActivated; } set { _UIQuestBookPanelActivated = value; } }

    private void Start()
    {
        _canvas = GameObject.Find("MenuCanvas");
    }

    private void Update()
    {
        if (GameObject.Find("UIQuestBookPanel") == true && _UIQuestBookPanelActivated == true && _UIQuestBookAnimationOn == true)
        {
            _UIQuestBookAnimationOn = _canvas.GetComponent<AnimationUserInterfaceController>().VrtAnimToUserInterface("UIQuestBookPanel", 0, 0, -1);
        }
        else if (GameObject.Find("UIQuestBookPanel") == true && _UIQuestBookPanelActivated == false && _UIQuestBookAnimationOn == true)
        {
            _UIQuestBookAnimationOn = _canvas.GetComponent<AnimationUserInterfaceController>().VrtAnimToDestroy("UIQuestBookPanel",
                _canvas.GetComponent<RectTransform>().rect.height, 1);
        }
    }

    private void CheckOpenPanel()
    {
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
        if (GameObject.Find("UIMapPanel") == true)
        {
            GameObject.Find("UIMapButton").GetComponent<UIMap>().UIMapPanelAnimationOn = true;
            GameObject.Find("UIMapButton").GetComponent<UIMap>().UIMapPanelActivated = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        CheckOpenPanel();

        if (GameObject.Find("UIQuestBookPanel") == false)
        {
            _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("UIQuestBookPanel", _canvas, true,
            _canvas.GetComponent<RectTransform>().rect.width / 3, (_canvas.GetComponent<RectTransform>().rect.height / 10) * 8,
            0, _canvas.GetComponent<RectTransform>().rect.height,
            _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteBackGround_03", _canvas.GetComponent<ImageMonitoring>()._BackGroundSprite));

            _UIQuestBookPanelActivated = true;
            _UIQuestBookAnimationOn = true;
        }
        else
        {
            _UIQuestBookPanelActivated = false;
            _UIQuestBookAnimationOn = true;
        }
    }
}
