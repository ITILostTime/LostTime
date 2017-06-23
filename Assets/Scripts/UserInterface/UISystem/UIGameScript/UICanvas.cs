using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour {

    private GameObject _canvas;

    private bool isPanelActivated;
    private bool isPanelAnimationOn;
    private GameObject _menuPanel;

    private void Awake()        //genere un obj a démarrage du jeu (il faut que le script soit sur un objet actif mais le script n'a pas besoin d'être actif lui pour lancer awake
    {
        GameObject.Find("Event").AddComponent<StandaloneInputModule>();
    }

    private void Start()
    {
        GameObject CanvasMenu = new GameObject("MenuCanvas");
        Canvas MenuCanvas = CanvasMenu.AddComponent<Canvas>();
        CanvasMenu.AddComponent<CanvasScaler>();
        CanvasMenu.AddComponent<GraphicRaycaster>();
        MenuCanvas.renderMode = RenderMode.ScreenSpaceOverlay;

        CanvasMenu.AddComponent<AnimationUserInterfaceController>();
        CanvasMenu.AddComponent<CreateUserInterfaceObject>();
        CanvasMenu.AddComponent<TextMonitoring>();
        CanvasMenu.AddComponent<ImageMonitoring>();
        CanvasMenu.AddComponent<SceneController>();

        CanvasMenu.AddComponent<SaveController>();

        _canvas = GameObject.Find("MenuCanvas");

        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("PanelButton", _canvas, true, _canvas.GetComponent<RectTransform>().rect.height / 6,
            _canvas.GetComponent<RectTransform>().rect.height / 6, _canvas.GetComponent<RectTransform>().rect.width / -2 + _canvas.GetComponent<RectTransform>().rect.height / 12,
            _canvas.GetComponent<RectTransform>().rect.height / 2 - _canvas.GetComponent<RectTransform>().rect.height / 12,
            _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteIcon_04", _canvas.GetComponent<ImageMonitoring>()._icon));
        GameObject.Find("PanelButton").AddComponent<Button>();
        GameObject.Find("PanelButton").GetComponent<Button>().onClick.AddListener(() => CreatePanel());
        GameObject.Find("PanelButton").GetComponent<Button>().onClick.AddListener(() => CheckOpenPanel());

        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("InventoryButton", _canvas, true, _canvas.GetComponent<RectTransform>().rect.height / 6,
            _canvas.GetComponent<RectTransform>().rect.height / 6, _canvas.GetComponent<RectTransform>().rect.width / 2 - _canvas.GetComponent<RectTransform>().rect.height / 12,
            _canvas.GetComponent<RectTransform>().rect.height / 2 - _canvas.GetComponent<RectTransform>().rect.height / 12,
            _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteIcon_01", _canvas.GetComponent<ImageMonitoring>()._icon));
        GameObject.Find("InventoryButton").AddComponent<UIInventory>();

        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("LeftJoystickPanel", _canvas, true,
            _canvas.GetComponent<RectTransform>().rect.width / 4,
            _canvas.GetComponent<RectTransform>().rect.height,
            (Screen.width / -2) + (_canvas.GetComponent<RectTransform>().rect.width / 8) + GameObject.Find("PanelButton").GetComponent<RectTransform>().rect.width, 
            0, Color.clear);
        GameObject.Find("LeftJoystickPanel").AddComponent<UIVirtualLeftJoystick>();

        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("RightJoystickPanel", _canvas, true,
            _canvas.GetComponent<RectTransform>().rect.width / 4,
            _canvas.GetComponent<RectTransform>().rect.height,
            (Screen.width / 2) - (_canvas.GetComponent<RectTransform>().rect.width / 8) - GameObject.Find("InventoryButton").GetComponent<RectTransform>().rect.width, 
            0, Color.clear);
        GameObject.Find("RightJoystickPanel").AddComponent<UIVirtualRightJoystick>();

        GameObject PrefabAstribPlayer = (GameObject)Instantiate(Resources.Load("Astrid/AstridPuppet"));
        GameObject.Find("AstridPuppet(Clone)").name = "AstridPlayer";
    }

    private void FixedUpdate()
    {
        if(GameObject.Find("MenuPanel") == true && isPanelActivated == true && isPanelAnimationOn == true)
        {
            GameObject.Find("PanelButton").transform.Rotate(0, 0, -9);
            isPanelAnimationOn = _canvas.GetComponent<AnimationUserInterfaceController>().VrtAnimToUserInterface("MenuPanel",
                _canvas.GetComponent<RectTransform>().rect.width / -2 + GameObject.Find("PanelButton").GetComponent<RectTransform>().rect.width / 2,
                GameObject.Find("PanelButton").GetComponent<RectTransform>().rect.height / -2, -1);
        }
        else if(GameObject.Find("MenuPanel") == true && isPanelActivated == false && isPanelAnimationOn == true) 
        {
            GameObject.Find("PanelButton").transform.Rotate(0, 0, 9);
            isPanelAnimationOn = _canvas.GetComponent<AnimationUserInterfaceController>().VrtAnimToDestroy("MenuPanel",
                _canvas.GetComponent<RectTransform>().rect.height - GameObject.Find("PanelButton").GetComponent<RectTransform>().rect.height / -2, 1);
        }
    }

    private void CreatePanel()
    {
        if(GameObject.Find("MenuPanel") == false)
        {
            _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("MenuPanel", _canvas, true,
            GameObject.Find("PanelButton").GetComponent<RectTransform>().rect.width,
            _canvas.GetComponent<RectTransform>().rect.height - GameObject.Find("PanelButton").GetComponent<RectTransform>().rect.height,
            _canvas.GetComponent<RectTransform>().rect.width / -2 + GameObject.Find("PanelButton").GetComponent<RectTransform>().rect.width / 2,
             _canvas.GetComponent<RectTransform>().rect.height - GameObject.Find("PanelButton").GetComponent<RectTransform>().rect.height / -2,
             _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteOther_01", _canvas.GetComponent<ImageMonitoring>()._other));

            _menuPanel = GameObject.Find("MenuPanel");

            AddButtonOnMenuPanel();

            isPanelActivated = true;
            isPanelAnimationOn = true;
        }
        else
        {
            isPanelActivated = false;
            isPanelAnimationOn = true;
        }
        
    }

    private void AddButtonOnMenuPanel()
    {
        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("UIMapButton", _menuPanel, true,
            _menuPanel.GetComponent<RectTransform>().rect.width / 1.2f, _menuPanel.GetComponent<RectTransform>().rect.width / 1.2f,
            0, _menuPanel.GetComponent<RectTransform>().rect.height / 3f,
            _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteIcon_02", _canvas.GetComponent<ImageMonitoring>()._icon));
        GameObject.Find("UIMapButton").AddComponent<UIMap>();


        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("UIQuestBookButton", _menuPanel, true,
            _menuPanel.GetComponent<RectTransform>().rect.width / 1.2f, _menuPanel.GetComponent<RectTransform>().rect.width / 1.2f,
            0, _menuPanel.GetComponent<RectTransform>().rect.height / 9f,
            _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteIcon_06", _canvas.GetComponent<ImageMonitoring>()._icon));
        GameObject.Find("UIQuestBookButton").AddComponent<UIQuestBook>();

        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("UIConfigureButton", _menuPanel, true,
            _menuPanel.GetComponent<RectTransform>().rect.width / 1.2f, _menuPanel.GetComponent<RectTransform>().rect.width / 1.2f,
            0, _menuPanel.GetComponent<RectTransform>().rect.height / -9f,
            _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteIcon_05", _canvas.GetComponent<ImageMonitoring>()._icon));
        GameObject.Find("UIConfigureButton").AddComponent<UIConfigure>();

        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("UILeaveButton", _menuPanel, true,
            _menuPanel.GetComponent<RectTransform>().rect.width / 1.2f, _menuPanel.GetComponent<RectTransform>().rect.width / 1.2f,
            0, _menuPanel.GetComponent<RectTransform>().rect.height / -3f,
            _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteIcon_03", _canvas.GetComponent<ImageMonitoring>()._icon));
        GameObject.Find("UILeaveButton").AddComponent<Button>();
        GameObject.Find("UILeaveButton").GetComponent<Button>().onClick.AddListener(() => ReturnMenu());
    }

    private void ReturnMenu()
    {
        SceneManager.LoadScene("LostTimeMenuGame");
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
