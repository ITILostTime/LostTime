using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetConfigureButtonScript : MonoBehaviour, IPointerDownHandler
{
    private GameObject _canvasMenu;
    private GameObject _configurePanel;
    private GameObject _SelectLanguagesBackGround;

    private bool _configurePanelActivated;
    private bool _configurePanelAnimationOn;

    public bool ConfigurePanelActivated { get { return _configurePanelActivated; } set { _configurePanelActivated = value; } }
    public bool ConfigurePanelAnimationOn { get { return _configurePanelAnimationOn; } set { _configurePanelAnimationOn = value; } }

    private void Start()
    {
        _canvasMenu = GameObject.Find("MenuCanvas");
    }

    private void Update()
    {
        if (GameObject.Find("ConfigurePanel") == true && _configurePanelActivated == true && _configurePanelAnimationOn == true)
        {
            _configurePanelAnimationOn = _canvasMenu.GetComponent<AnimationUserInterfaceController>().HztAnimToUserInterfaceRightToLeft("ConfigurePanel",
                _canvasMenu.GetComponent<RectTransform>().rect.width / 2.7f, 0, -1);
        }
        else if (GameObject.Find("ConfigurePanel") == true && _configurePanelActivated == false && _configurePanelAnimationOn == true)
        {
            _configurePanelAnimationOn = _canvasMenu.GetComponent<AnimationUserInterfaceController>().HztAnimToDestroyLeftToRight("ConfigurePanel",
                _canvasMenu.GetComponent<RectTransform>().rect.width / 2
                + GameObject.Find("ConfigurePanel").GetComponent<RectTransform>().rect.width / 2,
                1);
        }
        if(GameObject.Find("ConfigureSoundPrefab(Clone)") == true)
        {
            PlayerPrefs.SetFloat("SoundLevel", GameObject.Find("ConfigureSoundPrefab(Clone)").GetComponent<Slider>().value);
        }
        if(GameObject.Find("ConfigureShadowPrefab(Clone)") == true)
        {
            if(GameObject.Find("ConfigureShadowPrefab(Clone)").GetComponent<Toggle>().isOn == true)
            {
                PlayerPrefs.SetInt("ShadowIsActivatedSave", 1);
                GameObject.Find("Sun").GetComponent<Light>().shadows = LightShadows.Soft;
            }
            else
            {
                PlayerPrefs.SetInt("ShadowIsActivatedSave", 0);
                GameObject.Find("Sun").GetComponent<Light>().shadows = LightShadows.None;
            }
            
        }
    }

    private void CheckOpenPanel()
    {
        if (GameObject.Find("LoadGamePanel") == true)
        {
            GameObject.Find("LoadGameButton").GetComponent<SetLoadGameButtonScript>().LoadGamePanelActivated = false;
            GameObject.Find("LoadGameButton").GetComponent<SetLoadGameButtonScript>().LoadGameAnimationOn = true;
        }

        if (GameObject.Find("NewGamePanel") == true)
        {
            GameObject.Find("NewGameButton").GetComponent<SetNewGameButtonScript>().NewGamePanelActivated = false;
            GameObject.Find("NewGameButton").GetComponent<SetNewGameButtonScript>().NewGameAnimationOn = true;
        }
    }

    public virtual void OnPointerDown(PointerEventData ConfigurePanel)
    {
        CheckOpenPanel();
        CreateConfigurePanel();
    }

    private void CreateConfigurePanel()
    {

        if (GameObject.Find("ConfigurePanel") == false)
        {
            _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateEmptyGameObject("ConfigurePanel", _canvasMenu, true, _canvasMenu.GetComponent<RectTransform>().rect.width / 4,
            _canvasMenu.GetComponent<RectTransform>().rect.height, ((_canvasMenu.GetComponent<RectTransform>().rect.width / 2) + (_canvasMenu.GetComponent<RectTransform>().rect.width / 8)), 0);

            _configurePanel = GameObject.Find("ConfigurePanel");

            AddComponentToConfigurePanel();

            IsShadowActivated();
            SoundEffect();
            LanguagesPanel();

            _configurePanelActivated = true;
            _configurePanelAnimationOn = true;
        }
        else
        {
            _configurePanelActivated = false;
            _configurePanelAnimationOn = true;
        }

    }

    private void AddComponentToConfigurePanel()
    {
        _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("ConfigurePanelLabel", _configurePanel, true,
            _configurePanel.GetComponent<RectTransform>().rect.width * 8 / 10, _configurePanel.GetComponent<RectTransform>().rect.height / 10,
            0, _configurePanel.GetComponent<RectTransform>().rect.height * 4 / 10, "", _canvasMenu.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(Screen.height / 20)), Color.black);
        _canvasMenu.GetComponent<TextMonitoring>().setTextInCorrectLanguages("ConfigurePanelLabel", "Options", "Options");
    }

    private void LanguagesPanel()
    {
        _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateEmptyGameObject("SelectLanguagesBackGround", _configurePanel, true, 
            _configurePanel.GetComponent<RectTransform>().rect.width * 8 / 10, _configurePanel.GetComponent<RectTransform>().rect.height / 10, 
            0, _configurePanel.GetComponent<RectTransform>().rect.height * 2 / 10);

        _SelectLanguagesBackGround = GameObject.Find("SelectLanguagesBackGround");

        _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("SelectLanguagesArrowFR", _SelectLanguagesBackGround, true,
            _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height, _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height,
            (_SelectLanguagesBackGround.GetComponent<RectTransform>().rect.width / -2) + (_SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height / 2),
            0, null);

        _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateGameObjectButtonWithText("FrenchText", _SelectLanguagesBackGround, true,
            _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.width - _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height,
            _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height, _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.width / 2 -
            (_SelectLanguagesBackGround.GetComponent<RectTransform>().rect.width - _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height) / 2, 0,
            "", _canvasMenu.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, ((int)(Screen.height / 20)), Color.black);
        _canvasMenu.GetComponent<TextMonitoring>().setTextInCorrectLanguages("FrenchText", "French", "Français");
        GameObject.Find("FrenchText").GetComponent<Button>().onClick.AddListener(() => FRButton());

        _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("SelectLanguagesArrowEN", _SelectLanguagesBackGround, true,
            _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height, _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height,
            (_SelectLanguagesBackGround.GetComponent<RectTransform>().rect.width / -2) + (_SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height / 2),
            _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height * -2, null);

        _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateGameObjectButtonWithText("EnglishText", _SelectLanguagesBackGround, true,
            _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.width - _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height,
            _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height, (_SelectLanguagesBackGround.GetComponent<RectTransform>().rect.width / 2 -
            (_SelectLanguagesBackGround.GetComponent<RectTransform>().rect.width - _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height) / 2),
            _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height * -2,
            "", _canvasMenu.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, ((int)(Screen.height / 20)), Color.black);
        _canvasMenu.GetComponent<TextMonitoring>().setTextInCorrectLanguages("EnglishText", "English", "Anglais");
        GameObject.Find("EnglishText").GetComponent<Button>().onClick.AddListener(() => ENButton());

        if (PlayerPrefs.GetString("CurrentLanguagesUsed") == "French" || PlayerPrefs.GetString("CurrentLanguagesUsed") == "Français")
        {
            GameObject.Find("SelectLanguagesArrowFR").GetComponent<Image>().sprite = _canvasMenu.GetComponent<ImageMonitoring>().GetRightArrow;
            GameObject.Find("SelectLanguagesArrowEN").GetComponent<Image>().color = Color.clear;
        }
        else if (PlayerPrefs.GetString("CurrentLanguagesUsed") == "English" || PlayerPrefs.GetString("CurrentLanguagesUsed") == "Anglais")
        {
            GameObject.Find("SelectLanguagesArrowEN").GetComponent<Image>().sprite = _canvasMenu.GetComponent<ImageMonitoring>().GetRightArrow;
            GameObject.Find("SelectLanguagesArrowFR").GetComponent<Image>().color = Color.clear;
        }
    }

    private void SoundEffect()
    {
        _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("SoundEffectLabel", _configurePanel, true,
            _configurePanel.GetComponent<RectTransform>().rect.width, _configurePanel.GetComponent<RectTransform>().rect.height / 10,
            0, (_configurePanel.GetComponent<RectTransform>().rect.height / 10) * -1.5f, "",
            _canvasMenu.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, ((int)(Screen.height / 20)), Color.black);
        _canvasMenu.GetComponent<TextMonitoring>().setTextInCorrectLanguages("SoundEffectLabel", "Sound Level", "Niveau Sonore");

        GameObject SoundEffectSlider = (GameObject)Instantiate(Resources.Load("UnityUserInterfacePrefabs/ConfigureSoundPrefab"));
        SoundEffectSlider.transform.SetParent(_configurePanel.transform, true);
        SoundEffectSlider.GetComponent<RectTransform>().sizeDelta = new Vector2((_configurePanel.GetComponent<RectTransform>().rect.width), _configurePanel.GetComponent<RectTransform>().rect.height / 20);
        SoundEffectSlider.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (_configurePanel.GetComponent<RectTransform>().rect.height / 10) * -2.5f);
        GameObject.Find("ConfigureSoundPrefab(Clone)").GetComponent<Slider>().value = PlayerPrefs.GetFloat("SoundLevel");
    }

    private void IsShadowActivated()
    {
        GameObject ShadowToggle = (GameObject)Instantiate(Resources.Load("UnityUserInterfacePrefabs/ConfigureShadowPrefab"));
        ShadowToggle.transform.SetParent(_configurePanel.transform, true);
        ShadowToggle.GetComponent<RectTransform>().sizeDelta = new Vector2((_configurePanel.GetComponent<RectTransform>().rect.width / 10) * 8, _configurePanel.GetComponent<RectTransform>().rect.height / 10);
        ShadowToggle.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (_configurePanel.GetComponent<RectTransform>().rect.height / 10) * -4  );
        GameObject.Find("ShadowToggleLabel").GetComponent<Text>().fontStyle = FontStyle.Bold;
        GameObject.Find("ShadowToggleLabel").GetComponent<Text>().color = Color.black;
        _canvasMenu.GetComponent<TextMonitoring>().setTextInCorrectLanguages("ShadowToggleLabel", "Activate Shadow", "Activer les Ombres");
        GameObject.Find("ToggleShadowGear").GetComponent<Image>().sprite = _canvasMenu.GetComponent<ImageMonitoring>().GetBlackGear;

        if(PlayerPrefs.GetInt("ShadowIsActivatedSave") == 0)
        {
            GameObject.Find("ConfigureShadowPrefab(Clone)").GetComponent<Toggle>().isOn = false;
        }
        else
        {
            GameObject.Find("ConfigureShadowPrefab(Clone)").GetComponent<Toggle>().isOn = true;
        }
    }

    private void FRButton()
    {
        PlayerPrefs.SetString("CurrentLanguagesUsed", "French");
        GameObject.Find("SelectLanguagesArrowFR").GetComponent<Image>().sprite = _canvasMenu.GetComponent<ImageMonitoring>().GetRightArrow;
        GameObject.Find("SelectLanguagesArrowEN").GetComponent<Image>().color = Color.clear;
        GameObject.Find("SelectLanguagesArrowFR").GetComponent<Image>().color = Color.white;

        _canvasMenu.GetComponent<TextMonitoring>().setTextInCorrectLanguages("ShadowToggleLabel", "Activate Shadow", "Activer les Ombres");
        _canvasMenu.GetComponent<TextMonitoring>().setTextInCorrectLanguages("SoundEffectLabel", "Sound Level", "Niveau Sonore");
        _canvasMenu.GetComponent<TextMonitoring>().setTextInCorrectLanguages("EnglishText", "English", "Anglais");
        _canvasMenu.GetComponent<TextMonitoring>().setTextInCorrectLanguages("FrenchText", "French", "Français");
    }

    private void ENButton()
    {
        PlayerPrefs.SetString("CurrentLanguagesUsed", "English");
        GameObject.Find("SelectLanguagesArrowEN").GetComponent<Image>().sprite = _canvasMenu.GetComponent<ImageMonitoring>().GetRightArrow;
        GameObject.Find("SelectLanguagesArrowFR").GetComponent<Image>().color = Color.clear;
        GameObject.Find("SelectLanguagesArrowEN").GetComponent<Image>().color = Color.white;

        _canvasMenu.GetComponent<TextMonitoring>().setTextInCorrectLanguages("ShadowToggleLabel", "Activate Shadow", "Activer les Ombres");
        _canvasMenu.GetComponent<TextMonitoring>().setTextInCorrectLanguages("SoundEffectLabel", "Sound Level", "Niveau Sonore");
        _canvasMenu.GetComponent<TextMonitoring>().setTextInCorrectLanguages("EnglishText", "English", "Anglais");
        _canvasMenu.GetComponent<TextMonitoring>().setTextInCorrectLanguages("FrenchText", "French", "Français");
    }
}
