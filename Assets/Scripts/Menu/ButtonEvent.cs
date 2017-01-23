﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonEvent : MonoBehaviour
{
    private GameObject _newGamePanel;
    private GameObject _loadGamePanel;
    private GameObject _configureGamePanel;

    private bool _newGamePanelActivated;
    private bool _newGameAnimationOn;

    private bool _loadGamePanelActivated;
    private bool _loadGameAnimationOn;

    private bool _configGamePanelActivated;
    private bool _configGameAnimationOn;

    public Sprite _red;
    public Sprite _blue;
    public Sprite _yellow;

    private void Start()
    {

        GameObject.Find("cloudLayer4").GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * 2, Screen.height * 1.5f);
        GameObject.Find("cloudLayer3").GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * 2, Screen.height * 1.5f);
        GameObject.Find("cloudLayer3.5").GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * 2, Screen.height * 1.5f);
        GameObject.Find("cloudLayer2").GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * 2, Screen.height * 1.5f);
        GameObject.Find("cloudLayer1").GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * 2, Screen.height * 1.5f);

        GameObject.Find("GameTittle").GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 3, Screen.height / 3);
        GameObject.Find("GameTittle").GetComponent<RectTransform>().anchoredPosition = new Vector2((-Screen.width / 2) + GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.width / 2.5f,
            Screen.height / 4);


        GameObject.Find("ButtonNewGame").transform.SetParent(GameObject.Find("GameTittle").transform, true);
        GameObject.Find("ButtonNewGame").GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.width,
            GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.height / 4);
        GameObject.Find("ButtonNewGame").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.height / -2);
        GameObject.Find("ButtonNewGameText").GetComponent<Text>().fontSize = ((int)(GameObject.Find("ButtonNewGame").GetComponent<RectTransform>().rect.height - 10));


        GameObject.Find("ButtonLoadSave").transform.SetParent(GameObject.Find("ButtonNewGame").transform, true);
        GameObject.Find("ButtonLoadSave").GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.width,
            GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.height / 4);
        GameObject.Find("ButtonLoadSave").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.height / 2);
        GameObject.Find("ButtonLoadSaveText").GetComponent<Text>().fontSize = ((int)(GameObject.Find("ButtonLoadSave").GetComponent<RectTransform>().rect.height - 10));


        /*GameObject.Find("ButtonConfigure").transform.SetParent(GameObject.Find("ButtonLoadSave").transform, true);
        GameObject.Find("ButtonConfigure").GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.width,
            GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.height / 4);
        GameObject.Find("ButtonConfigure").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -GameObject.Find("GameTittle").GetComponent<RectTransform>().rect.height / 2);
        GameObject.Find("ButtonConfigureText").GetComponent<Text>().fontSize = ((int)(GameObject.Find("ButtonConfigure").GetComponent<RectTransform>().rect.height - 10));*/


        GameObject.Find("BackGroundMenu").transform.SetParent(GameObject.Find("MenuGameUserInterface").transform, true);
        GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().sizeDelta = GameObject.Find("MenuGameUserInterface").GetComponent<RectTransform>().sizeDelta;
        GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);


        GameObject.Find("BackGroundMenuGame").transform.SetParent(GameObject.Find("BackGroundMenu").transform, true);
        GameObject.Find("BackGroundMenuGame").GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height, Screen.height);
        GameObject.Find("BackGroundMenuGame").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }

    private void Update()
    {
        if (GameObject.Find("NewGamePanel") == true)
        {
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SaveStateOneYellowGearSprite", 0, 0, -1);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SaveStateOneRedGearSprite", 0, 0, 1);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SaveStateOneBlueGearSprite", 0, 0, -1);

            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SaveStateTwoYellowGearSprite", 0, 0, -1);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SaveStateTwoRedGearSprite", 0, 0, 1);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SaveStateTwoBlueGearSprite", 0, 0, -1);

            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SaveStateThreeYellowGearSprite", 0, 0, -1);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SaveStateThreeRedGearSprite", 0, 0, 1);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("SaveStateThreeBlueGearSprite", 0, 0, -1);
        }

        if (GameObject.Find("LoadGamePanel") == true)
        {
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("LoadSaveStateOneYellowGearSprite", 0, 0, -1);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("LoadSaveStateOneRedGearSprite", 0, 0, 1);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("LoadSaveStateOneBlueGearSprite", 0, 0, -1);

            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("LoadSaveStateTwoYellowGearSprite", 0, 0, -1);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("LoadSaveStateTwoRedGearSprite", 0, 0, 1);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("LoadSaveStateTwoBlueGearSprite", 0, 0, -1);

            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("LoadSaveStateThreeYellowGearSprite", 0, 0, -1);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("LoadSaveStateThreeRedGearSprite", 0, 0, 1);
            GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().RotationObjectOnAxe("LoadSaveStateThreeBlueGearSprite", 0, 0, -1);
        }

        if (GameObject.Find("NewGamePanel") == true && _newGamePanelActivated == true && _newGameAnimationOn == true)
        {
            _newGameAnimationOn = GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().HztAnimToUserInterfaceRightToLeft("NewGamePanel",
                GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().rect.width / 2.7f, 0, -1);
        }
        else if (GameObject.Find("NewGamePanel") == true && _newGamePanelActivated == false && _newGameAnimationOn == true)
        {
            _newGameAnimationOn = GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().HztAnimToDestroyLeftToRight("NewGamePanel",
                GameObject.Find("MenuGameUserInterface").GetComponent<RectTransform>().rect.width / 2
                + GameObject.Find("NewGamePanel").GetComponent<RectTransform>().rect.width / 2,
                1);
        }

        if (GameObject.Find("LoadGamePanel") == true && _loadGamePanelActivated == true && _loadGameAnimationOn == true)
        {
            _loadGameAnimationOn = GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().HztAnimToUserInterfaceRightToLeft("LoadGamePanel",
                GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().rect.width / 2.7f, 0, -1);
        }
        else if (GameObject.Find("LoadGamePanel") == true && _loadGamePanelActivated == false && _loadGameAnimationOn == true)
        {
            _loadGameAnimationOn = GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().HztAnimToDestroyLeftToRight("LoadGamePanel",
                GameObject.Find("MenuGameUserInterface").GetComponent<RectTransform>().rect.width / 2
                + GameObject.Find("LoadGamePanel").GetComponent<RectTransform>().rect.width / 2,
                1);
        }

        if (GameObject.Find("ConfigureGamePanel") == true && _configGamePanelActivated == true && _configGameAnimationOn == true)
        {
            _configGameAnimationOn = GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().HztAnimToUserInterfaceRightToLeft("ConfigureGamePanel",
                GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().rect.width / 2.7f, 0, -1);
        }
        else if (GameObject.Find("ConfigureGamePanel") == true && _configGamePanelActivated == false && _configGameAnimationOn == true)
        {
            _configGameAnimationOn = GameObject.Find("MenuGameUserInterface").GetComponent<AnimationUserInterfaceController>().HztAnimToDestroyLeftToRight("ConfigureGamePanel",
                GameObject.Find("MenuGameUserInterface").GetComponent<RectTransform>().rect.width / 2
                + GameObject.Find("ConfigureGamePanel").GetComponent<RectTransform>().rect.width / 2,
                1);
        }

        


    }

    private void checkOpenPanel()
    {
        if (GameObject.Find("NewGamePanel") == true)
        {
            _newGamePanelActivated = false;
            _newGameAnimationOn = true;
        }

        if (GameObject.Find("LoadGamePanel") == true)
        {
            _loadGameAnimationOn = true;
            _loadGamePanelActivated = false;
        }

        if (GameObject.Find("ConfigureGamePanel") == true)
        {
            _configGamePanelActivated = false;
            _configGameAnimationOn = true;
        }
    }

    public void NewGame()
    {
        checkOpenPanel();

        if (GameObject.Find("NewGamePanel") == false)
        {
            _newGamePanel = new GameObject("NewGamePanel");
            _newGamePanel.AddComponent<RectTransform>();
            _newGamePanel.transform.SetParent(GameObject.Find("BackGroundMenu").transform, true);
            _newGamePanel.GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().rect.width / 4,
                                                                                GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().rect.height);
            _newGamePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(GameObject.Find("MenuGameUserInterface").GetComponent<RectTransform>().rect.width / 2
                + GameObject.Find("NewGamePanel").GetComponent<RectTransform>().rect.width / 2, 0);


            CreateNewGamePanelCSaveStateComponent("SaveStateOne", "NewGamePanel", _newGamePanel.GetComponent<RectTransform>().rect.width,
                (_newGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, (_newGamePanel.GetComponent<RectTransform>().rect.height / 10) * 3.5f);
            GameObject.Find("SaveStateOneButtonZone").AddComponent<Button>();
            GameObject.Find("SaveStateOneButtonZone").GetComponent<Button>().onClick.AddListener(() => SaveStateAction("SaveStateOne"));


            CreateNewGamePanelCSaveStateComponent("SaveStateTwo", "NewGamePanel", _newGamePanel.GetComponent<RectTransform>().rect.width,
                (_newGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, 0);
            GameObject.Find("SaveStateTwoButtonZone").AddComponent<Button>();
            GameObject.Find("SaveStateTwoButtonZone").GetComponent<Button>().onClick.AddListener(() => SaveStateAction("SaveStateTwo"));


            CreateNewGamePanelCSaveStateComponent("SaveStateThree", "NewGamePanel", _newGamePanel.GetComponent<RectTransform>().rect.width,
                (_newGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, (_newGamePanel.GetComponent<RectTransform>().rect.height / 10) * -3.5f);
            GameObject.Find("SaveStateThreeButtonZone").AddComponent<Button>();
            GameObject.Find("SaveStateThreeButtonZone").GetComponent<Button>().onClick.AddListener(() => SaveStateAction("SaveStateThree"));


            _newGamePanelActivated = true;
            _newGameAnimationOn = true;
        }
        else
        {
            _newGamePanelActivated = false;
            _newGameAnimationOn = true;
        }
    }

    public void loadGame()
    {
        checkOpenPanel();

        if (GameObject.Find("LoadGamePanel") == false)
        {
            _loadGamePanel = new GameObject("LoadGamePanel");
            _loadGamePanel.AddComponent<RectTransform>();
            _loadGamePanel.transform.SetParent(GameObject.Find("BackGroundMenu").transform, true);
            _loadGamePanel.GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().rect.width / 4,
                                                                                    GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().rect.height);
            _loadGamePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(GameObject.Find("MenuGameUserInterface").GetComponent<RectTransform>().rect.width / 2
                + GameObject.Find("LoadGamePanel").GetComponent<RectTransform>().rect.width / 2, 0);

            CreateNewGamePanelCSaveStateComponent("LoadSaveStateOne", "LoadGamePanel", _loadGamePanel.GetComponent<RectTransform>().rect.width,
                (_loadGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, (_loadGamePanel.GetComponent<RectTransform>().rect.height / 10) * 3.5f);
            GameObject.Find("LoadSaveStateOneButtonZone").AddComponent<Button>();
            GameObject.Find("LoadSaveStateOneButtonZone").GetComponent<Button>().onClick.AddListener(() => LoadStateAction());


            CreateNewGamePanelCSaveStateComponent("LoadSaveStateTwo", "LoadGamePanel", _loadGamePanel.GetComponent<RectTransform>().rect.width,
                (_loadGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, 0);
            GameObject.Find("LoadSaveStateTwoButtonZone").AddComponent<Button>();
            GameObject.Find("LoadSaveStateTwoButtonZone").GetComponent<Button>().onClick.AddListener(() => LoadStateAction());


            CreateNewGamePanelCSaveStateComponent("LoadSaveStateThree", "LoadGamePanel", _loadGamePanel.GetComponent<RectTransform>().rect.width,
                (_loadGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, (_loadGamePanel.GetComponent<RectTransform>().rect.height / 10) * -3.5f);
            GameObject.Find("LoadSaveStateThreeButtonZone").AddComponent<Button>();
            GameObject.Find("LoadSaveStateThreeButtonZone").GetComponent<Button>().onClick.AddListener(() => LoadStateAction());


            _loadGamePanelActivated = true;
            _loadGameAnimationOn = true;
        }
        else
        {
            _loadGamePanelActivated = false;
            _loadGameAnimationOn = true;
        }
    }

    public void ConfigureGame()
    {
        checkOpenPanel();

        if (GameObject.Find("ConfigureGamePanel") == false)
        {

            _configureGamePanel = new GameObject("ConfigureGamePanel");
            _configureGamePanel.AddComponent<RectTransform>();
            Image ConfigureGamePanelImage = _configureGamePanel.AddComponent<Image>();
            ConfigureGamePanelImage.color = Color.green;
            _configureGamePanel.transform.SetParent(GameObject.Find("BackGroundMenu").transform, true);
            _configureGamePanel.GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().rect.width / 4, GameObject.Find("BackGroundMenu").GetComponent<RectTransform>().rect.height);
            _configureGamePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(GameObject.Find("MenuGameUserInterface").GetComponent<RectTransform>().rect.width / 2
                + GameObject.Find("ConfigureGamePanel").GetComponent<RectTransform>().rect.width / 2, 0);

            //CreateConfigureGamePanelComponent();

            _configGamePanelActivated = true;
            _configGameAnimationOn = true;
        }
        else
        {
            _configGamePanelActivated = false;
            _configGameAnimationOn = true;
        }

    }



    private void CreateNewGamePanelCSaveStateComponent(string GameObjectName, string GameObjectParentName, float sizedeltaX, float sizeDeltaY, float anchoredPositionX, float anchoredPositionY)
    {
        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage(GameObjectName, GameObject.Find(GameObjectParentName), true,
            sizedeltaX, sizeDeltaY, anchoredPositionX, anchoredPositionY, Color.clear);

        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite(GameObjectName + "YellowGearSprite", GameObject.Find(GameObjectName), true,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 3, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 3,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / -6, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / -4,
            _yellow);

        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite(GameObjectName + "RedGearSprite", GameObject.Find(GameObjectName), true,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 4, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 4,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / -3, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / 6,
            _red);

        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite(GameObjectName + "BlueGearSprite", GameObject.Find(GameObjectName), true,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 5, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 5,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / -7, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / 3,
            _blue);

        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone(GameObjectName + "CycleTextZone", GameObject.Find(GameObjectName), true,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 2, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / 2,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 4, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / 4, "Nombre de cycle : ",
            GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / 10)), Color.black);
        if (PlayerPrefs.GetInt("Is" + GameObjectName + "Used") != 1)
        {
            GameObject.Find((GameObjectName + "CycleTextZone")).GetComponent<Text>().text = "Empty SaveState";
        }

        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone(GameObjectName + "FragmentTextZone", GameObject.Find(GameObjectName), true,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 2, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / 2,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 4, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / -4, "Nombre de fragments : ",
            GameObject.Find("MenuGameUserInterface").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / 10)), Color.black);
        if (PlayerPrefs.GetInt("Is" + GameObjectName + "Used") != 1)
        {
            GameObject.Find((GameObjectName + "FragmentTextZone")).GetComponent<Text>().text = "Start New Game";
        }

        GameObject.Find("MenuGameUserInterface").GetComponent<CreateUserInterfaceObject>().CreateEmptyGameObject(GameObjectName + "ButtonZone", GameObject.Find(GameObjectName), true,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height, 0, 0);
        
    }

    
    private void SaveStateAction(string SaveStateName)
    {
        if(PlayerPrefs.GetInt("Is"+ SaveStateName + "Used") == 1)
        {
            PlayerPrefs.SetString("CurrentSaveStateUsed", SaveStateName);
        }
        else
        {
            PlayerPrefs.SetInt("Is" + SaveStateName + "Used", 1);
            PlayerPrefs.SetString("CurrentSaveStateUsed", SaveStateName);
        }
    }

    private void LoadStateAction()
    {

    }

    private void ResetPlayerPref()
    {
        PlayerPrefs.DeleteAll();
    }
}
