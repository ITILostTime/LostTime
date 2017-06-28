﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameLanguagesFirstChoiceScript : MonoBehaviour {

    private GameObject _userInterface;
    private bool _AdminCommand;

    private void Start()
    {

        _userInterface = GameObject.Find("Canvas");

        GameObject PrefabCloudLayer = (GameObject)Instantiate(Resources.Load("CloudLayer/CloudLayer"));
        PrefabCloudLayer.transform.SetParent(_userInterface.transform, true);
        PrefabCloudLayer.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        PrefabCloudLayer.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

        GameObject GameLogo = (GameObject)Instantiate(Resources.Load("GameLogo&Title/GameLogo"));
        GameLogo.transform.SetParent(_userInterface.transform, true);
        GameLogo.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height, Screen.height);
        GameLogo.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        GameLogo.GetComponent<Image>().color = new Color(255, 255, 255, 0.4f);

        GameObject GameName = (GameObject)Instantiate(Resources.Load("GameLogo&Title/GameName"));
        GameName.transform.SetParent(_userInterface.transform, true);
        GameName.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 3, Screen.height / 3);
        GameName.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, Screen.height / 3);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("FrenchButton", _userInterface, true,
            _userInterface.GetComponent<RectTransform>().rect.width / 4, _userInterface.GetComponent<RectTransform>().rect.height / 8,
            0, _userInterface.GetComponent<RectTransform>().rect.height / 8, "French", _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(_userInterface.GetComponent<RectTransform>().rect.height / 10)), Color.black);
        GameObject.Find("FrenchButton").AddComponent<Button>();
        GameObject.Find("FrenchButton").GetComponent<Button>().onClick.AddListener(() => FrenchButtonAction());

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("EnglishButton", _userInterface, true,
            _userInterface.GetComponent<RectTransform>().rect.width / 4, _userInterface.GetComponent<RectTransform>().rect.height / 8,
            0, _userInterface.GetComponent<RectTransform>().rect.height / -8, "English", _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(_userInterface.GetComponent<RectTransform>().rect.height / 10)), Color.black);
        GameObject.Find("EnglishButton").AddComponent<Button>();
        GameObject.Find("EnglishButton").GetComponent<Button>().onClick.AddListener(() => EnglishButtonAction());

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("FirstFrenchGear", GameObject.Find("FrenchButton"), true,
            GameObject.Find("FrenchButton").GetComponent<RectTransform>().rect.height, GameObject.Find("FrenchButton").GetComponent<RectTransform>().rect.height,
            GameObject.Find("FrenchButton").GetComponent<RectTransform>().rect.width / -2 - GameObject.Find("FrenchButton").GetComponent<RectTransform>().rect.height / 2, 0, 
            null);
        GameObject.Find("FirstFrenchGear").GetComponent<Image>().color = Color.clear;

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("SecondFrenchGear", GameObject.Find("FrenchButton"), true,
            GameObject.Find("FrenchButton").GetComponent<RectTransform>().rect.height, GameObject.Find("FrenchButton").GetComponent<RectTransform>().rect.height,
            GameObject.Find("FrenchButton").GetComponent<RectTransform>().rect.width / 2 + GameObject.Find("FrenchButton").GetComponent<RectTransform>().rect.height / 2, 0,
            _userInterface.GetComponent<ImageMonitoring>().GetSprite("SpriteLanguages_01", _userInterface.GetComponent<ImageMonitoring>()._LanguagesGear));

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("FirstEnglishGear", GameObject.Find("EnglishButton"), true,
            GameObject.Find("EnglishButton").GetComponent<RectTransform>().rect.height, GameObject.Find("EnglishButton").GetComponent<RectTransform>().rect.height,
            GameObject.Find("EnglishButton").GetComponent<RectTransform>().rect.width / -2 - GameObject.Find("EnglishButton").GetComponent<RectTransform>().rect.height / 2, 0,
            null);
        GameObject.Find("FirstEnglishGear").GetComponent<Image>().color = Color.clear;

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("SecondEnglishGear", GameObject.Find("EnglishButton"), true,
            GameObject.Find("EnglishButton").GetComponent<RectTransform>().rect.height, GameObject.Find("EnglishButton").GetComponent<RectTransform>().rect.height,
            GameObject.Find("EnglishButton").GetComponent<RectTransform>().rect.width / 2 + GameObject.Find("EnglishButton").GetComponent<RectTransform>().rect.height / 2, 0,
            _userInterface.GetComponent<ImageMonitoring>().GetSprite("SpriteLanguages_02", _userInterface.GetComponent<ImageMonitoring>()._LanguagesGear));
        GameObject.Find("SecondEnglishGear").GetComponent<RectTransform>().Rotate(0, 0, -90);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectButtonWithText("Validate", _userInterface, true, 
            _userInterface.GetComponent<RectTransform>().rect.width / 4, (_userInterface.GetComponent<RectTransform>().rect.height / 8), 
            0, (_userInterface.GetComponent<RectTransform>().rect.height / -2) + _userInterface.GetComponent<RectTransform>().rect.height / 8 , 
            "OK", _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, 
            TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(_userInterface.GetComponent<RectTransform>().rect.height / 10)), Color.black);
        GameObject.Find("Validate").GetComponent<Button>().onClick.AddListener(() => ButtonValidation());

        CheckLanguagesLanguages();

        AdminCommand();
    }

    private void AdminCommand()
    {
        if (GameObject.Find("AdminInputZone") == false)
        {
            _userInterface.GetComponent<CreateUserInterfaceObject>().CreateEmptyGameObject("AdminInputZone", GameObject.Find("GameName(Clone)"), true,
            GameObject.Find("GameName(Clone)").GetComponent<RectTransform>().rect.width / 5, GameObject.Find("GameName(Clone)").GetComponent<RectTransform>().rect.height,
            0, 0);
            GameObject.Find("AdminInputZone").AddComponent<Image>();
            GameObject.Find("AdminInputZone").GetComponent<Image>().color = new Color(255, 255, 255, 0f);
            GameObject.Find("AdminInputZone").AddComponent<UIAdminCommand>();
        }
        
    }

    private void Update()
    {
        if (GameObject.Find("AdminInputZone").GetComponent<UIAdminCommand>().IsAdminCommandOn == true && GameObject.Find("AdminPanel") == false)
        {
            CreateAdminPanel();
        }
    }

    private void CreateAdminPanel()
    {
        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateEmptyGameObject("AdminPanel", _userInterface, true,
            _userInterface.GetComponent<RectTransform>().rect.width / 5, _userInterface.GetComponent<RectTransform>().rect.height, 
            _userInterface.GetComponent<RectTransform>().rect.width / 2 - _userInterface.GetComponent<RectTransform>().rect.width / 10, 0);
        GameObject AdminPanel = GameObject.Find("AdminPanel");
        AdminPanel.AddComponent<Image>();
        AdminPanel.GetComponent<Image>().color = new Color(255, 255, 255, 0.1f);

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectButtonWithText("ButtonResetPlayerPrefs", AdminPanel, true, 
            AdminPanel.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height / 10, 0, 
            _userInterface.GetComponent<RectTransform>().rect.height / 3, "Reset All PlayerPrefs", _userInterface.GetComponent<TextMonitoring>().GetArialTextFont, 
            TextAnchor.MiddleCenter, FontStyle.Bold, 0, Color.black);
        GameObject.Find("ButtonResetPlayerPrefs").GetComponent<Button>().onClick.AddListener(() => ResetAllPlayersPrefs());
        

        _userInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectButtonWithText("ClosePanel", AdminPanel, true,
            AdminPanel.GetComponent<RectTransform>().rect.width / 2, _userInterface.GetComponent<RectTransform>().rect.height / 10, 0,
            _userInterface.GetComponent<RectTransform>().rect.height / -3, "Close", _userInterface.GetComponent<TextMonitoring>().GetArialTextFont,
            TextAnchor.MiddleCenter, FontStyle.Bold, 0, Color.black);
        GameObject.Find("ClosePanel").GetComponent<Button>().onClick.AddListener(() => DestroyAdminPanel());
    }

    private void ResetAllPlayersPrefs()
    {

        GameObject.Find("FirstEnglishGear").GetComponent<Image>().color = Color.clear;
        GameObject.Find("FirstFrenchGear").GetComponent<Image>().color = Color.clear;
        PlayerPrefs.DeleteAll();
    }

    private void DestroyAdminPanel()
    {
        GameObject.Find("AdminInputZone").GetComponent<UIAdminCommand>().IsAdminCommandOn = false;
        Destroy(GameObject.Find("AdminPanel"));
    }

    private void CheckLanguagesLanguages()
    {
        if(PlayerPrefs.GetString("CurrentLanguagesUsed") == "Français" || PlayerPrefs.GetString("CurrentLanguagesUsed") == "French")
        {
            FrenchButtonAction();
        }
        else if(PlayerPrefs.GetString("CurrentLanguagesUsed") == "Anglais" || PlayerPrefs.GetString("CurrentLanguagesUsed") == "English")
        {
            EnglishButtonAction();
        }
    }

    private void FrenchButtonAction()
    {
        PlayerPrefs.SetString("CurrentLanguagesUsed", "Français");

        GameObject.Find("FirstFrenchGear").GetComponent<Image>().sprite = _userInterface.GetComponent<ImageMonitoring>().GetSprite("SpriteSteampunkArrow_02", _userInterface.GetComponent<ImageMonitoring>()._arrow);
        GameObject.Find("FirstFrenchGear").GetComponent<Image>().color = Color.white;
        GameObject.Find("FirstEnglishGear").GetComponent<Image>().color = Color.clear;

    }

    private void EnglishButtonAction()
    {
        PlayerPrefs.SetString("CurrentLanguagesUsed", "Anglais");

        GameObject.Find("FirstEnglishGear").GetComponent<Image>().sprite = _userInterface.GetComponent<ImageMonitoring>().GetSprite("SpriteSteampunkArrow_02", _userInterface.GetComponent<ImageMonitoring>()._arrow);
        GameObject.Find("FirstEnglishGear").GetComponent<Image>().color = Color.white;
        GameObject.Find("FirstFrenchGear").GetComponent<Image>().color = Color.clear;
    }

    private void ButtonValidation()
    {
        if (PlayerPrefs.HasKey("CurrentLanguagesUsed") == true)
        {
            SceneManager.LoadScene("LostTimeMenuGame");
        }
    }
}
