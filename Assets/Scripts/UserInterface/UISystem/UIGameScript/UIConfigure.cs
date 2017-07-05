using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIConfigure : MonoBehaviour, IPointerDownHandler
{

    private GameObject _canvas;
    private GameObject _configurePanel;
    private GameObject _SelectLanguagesBackGround;
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
        if (GameObject.Find("ConfigureSoundPrefab(Clone)") == true)
        {
            PlayerPrefs.SetFloat("SoundLevel", GameObject.Find("ConfigureSoundPrefab(Clone)").GetComponent<Slider>().value);
        }
        if (GameObject.Find("ConfigureShadowPrefab(Clone)") == true)
        {
            if (GameObject.Find("ConfigureShadowPrefab(Clone)").GetComponent<Toggle>().isOn == true)
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

            _configurePanel = GameObject.Find("UIConfigurePanel");

            AddComponentToConfigurePanel();
            IsShadowActivated();
            SoundEffect();
            LanguagesPanel();

            _UIConfigureActivated = true;
            _UIConfigureAnimationOn = true;
        }
        else
        {
            _UIConfigureActivated = false;
            _UIConfigureAnimationOn = true;
        }
    }



    private void AddComponentToConfigurePanel()
    {
        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("ConfigurePanelLabel", _configurePanel, true,
            _configurePanel.GetComponent<RectTransform>().rect.width * 8 / 10, _configurePanel.GetComponent<RectTransform>().rect.height / 10,
            0, _configurePanel.GetComponent<RectTransform>().rect.height * 4 / 10, "", _canvas.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(Screen.height / 20)), Color.black);
        GameObject.Find("ConfigurePanelLabel").GetComponent<Text>().resizeTextForBestFit = true;
        _canvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("ConfigurePanelLabel", "Options", "Options");
    }

    private void LanguagesPanel()
    {
        _canvas.GetComponent<CreateUserInterfaceObject>().CreateEmptyGameObject("SelectLanguagesBackGround", _configurePanel, true,
            _configurePanel.GetComponent<RectTransform>().rect.width * 8 / 10, _configurePanel.GetComponent<RectTransform>().rect.height / 10,
            0, _configurePanel.GetComponent<RectTransform>().rect.height * 2 / 10);

        _SelectLanguagesBackGround = GameObject.Find("SelectLanguagesBackGround");

        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("SelectLanguagesArrowFR", _SelectLanguagesBackGround, true,
            _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height, _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height,
            (_SelectLanguagesBackGround.GetComponent<RectTransform>().rect.width / -2) + (_SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height / 2),
            0, null);

        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectButtonWithText("FrenchText", _SelectLanguagesBackGround, true,
            _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.width - _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height,
            _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height, _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.width / 2 -
            (_SelectLanguagesBackGround.GetComponent<RectTransform>().rect.width - _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height) / 2, 0,
            "", _canvas.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, ((int)(Screen.height / 20)), Color.black);
        _canvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("FrenchText", "French", "Français");
        GameObject.Find("FrenchText").GetComponent<Text>().resizeTextForBestFit = true;
        GameObject.Find("FrenchText").GetComponent<Button>().onClick.AddListener(() => FRButton());

        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("SelectLanguagesArrowEN", _SelectLanguagesBackGround, true,
            _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height, _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height,
            (_SelectLanguagesBackGround.GetComponent<RectTransform>().rect.width / -2) + (_SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height / 2),
            _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height * -2, null);

        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectButtonWithText("EnglishText", _SelectLanguagesBackGround, true,
            _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.width - _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height,
            _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height, (_SelectLanguagesBackGround.GetComponent<RectTransform>().rect.width / 2 -
            (_SelectLanguagesBackGround.GetComponent<RectTransform>().rect.width - _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height) / 2),
            _SelectLanguagesBackGround.GetComponent<RectTransform>().rect.height * -2,
            "", _canvas.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, ((int)(Screen.height / 20)), Color.black);
        _canvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("EnglishText", "English", "Anglais");
        GameObject.Find("EnglishText").GetComponent<Text>().resizeTextForBestFit = true;
        GameObject.Find("EnglishText").GetComponent<Button>().onClick.AddListener(() => ENButton());

        if (PlayerPrefs.GetString("CurrentLanguagesUsed") == "French" || PlayerPrefs.GetString("CurrentLanguagesUsed") == "Français")
        {
            GameObject.Find("SelectLanguagesArrowFR").GetComponent<Image>().sprite = _canvas.GetComponent<ImageMonitoring>().GetRightArrow;
            GameObject.Find("SelectLanguagesArrowEN").GetComponent<Image>().color = Color.clear;
        }
        else if (PlayerPrefs.GetString("CurrentLanguagesUsed") == "English" || PlayerPrefs.GetString("CurrentLanguagesUsed") == "Anglais")
        {
            GameObject.Find("SelectLanguagesArrowEN").GetComponent<Image>().sprite = _canvas.GetComponent<ImageMonitoring>().GetRightArrow;
            GameObject.Find("SelectLanguagesArrowFR").GetComponent<Image>().color = Color.clear;
        }
    }

    private void SoundEffect()
    {
        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("SoundEffectLabel", _configurePanel, true,
            _configurePanel.GetComponent<RectTransform>().rect.width, _configurePanel.GetComponent<RectTransform>().rect.height / 10,
            0, (_configurePanel.GetComponent<RectTransform>().rect.height / 10) * -1.5f, "",
            _canvas.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, ((int)(Screen.height / 20)), Color.black);
        GameObject.Find("SoundEffectLabel").GetComponent<Text>().resizeTextForBestFit = true;
        _canvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("SoundEffectLabel", "Sound Level", "Niveau Sonore");

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
        ShadowToggle.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (_configurePanel.GetComponent<RectTransform>().rect.height / 10) * -4);
        GameObject.Find("ShadowToggleLabel").GetComponent<Text>().fontStyle = FontStyle.Bold;
        GameObject.Find("ShadowToggleLabel").GetComponent<Text>().color = Color.black;
        GameObject.Find("ShadowToggleLabel").GetComponent<Text>().fontSize = ((int)(Screen.height / 20));
        GameObject.Find("ShadowToggleLabel").GetComponent<Text>().resizeTextForBestFit = true;
        _canvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("ShadowToggleLabel", "Activate Shadow", "Activer les Ombres");
        GameObject.Find("ShadowToggleBackground").GetComponent<RectTransform>().sizeDelta = new Vector2(ShadowToggle.GetComponent<RectTransform>().rect.height, ShadowToggle.GetComponent<RectTransform>().rect.height);
        GameObject.Find("ToggleShadowGear").GetComponent<RectTransform>().sizeDelta = GameObject.Find("ShadowToggleBackground").GetComponent<RectTransform>().sizeDelta;
        GameObject.Find("ToggleShadowGear").GetComponent<Image>().sprite = _canvas.GetComponent<ImageMonitoring>().GetBlackGear;

        if (PlayerPrefs.GetInt("ShadowIsActivatedSave") == 0)
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
        GameObject.Find("SelectLanguagesArrowFR").GetComponent<Image>().sprite = _canvas.GetComponent<ImageMonitoring>().GetRightArrow;
        GameObject.Find("SelectLanguagesArrowEN").GetComponent<Image>().color = Color.clear;
        GameObject.Find("SelectLanguagesArrowFR").GetComponent<Image>().color = Color.white;

        _canvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("ShadowToggleLabel", "Activate Shadow", "Activer les Ombres");
        _canvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("SoundEffectLabel", "Sound Level", "Niveau Sonore");
        _canvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("EnglishText", "English", "Anglais");
        _canvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("FrenchText", "French", "Français");
    }

    private void ENButton()
    {
        PlayerPrefs.SetString("CurrentLanguagesUsed", "English");
        GameObject.Find("SelectLanguagesArrowEN").GetComponent<Image>().sprite = _canvas.GetComponent<ImageMonitoring>().GetRightArrow;
        GameObject.Find("SelectLanguagesArrowFR").GetComponent<Image>().color = Color.clear;
        GameObject.Find("SelectLanguagesArrowEN").GetComponent<Image>().color = Color.white;

        _canvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("ShadowToggleLabel", "Activate Shadow", "Activer les Ombres");
        _canvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("SoundEffectLabel", "Sound Level", "Niveau Sonore");
        _canvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("EnglishText", "English", "Anglais");
        _canvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("FrenchText", "French", "Français");
    }
}
