using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SetNewGameButtonScript : MonoBehaviour, IPointerDownHandler
{
    private GameObject _canvasMenu;
    private GameObject _newGamePanel;

    private bool _newGamePanelActivated;
    private bool _newGameAnimationOn;

    public bool NewGamePanelActivated { get { return _newGamePanelActivated; } set { _newGamePanelActivated = value; } }
    public bool NewGameAnimationOn { get { return _newGameAnimationOn; } set { _newGameAnimationOn = value; } }

    private void Start()
    {
        _canvasMenu = GameObject.Find("MenuCanvas");
    }

    private void Update()
    {
        if (GameObject.Find("NewGamePanel") == true && _newGamePanelActivated == true && _newGameAnimationOn == true)
        {
            _newGameAnimationOn = _canvasMenu.GetComponent<AnimationUserInterfaceController>().HztAnimToUserInterfaceRightToLeft("NewGamePanel",
                ((_canvasMenu.GetComponent<RectTransform>().rect.width / 2) - (_canvasMenu.GetComponent<RectTransform>().rect.width / 6)), 0, -1);
        }
        else if (GameObject.Find("NewGamePanel") == true && _newGamePanelActivated == false && _newGameAnimationOn == true)
        {
            Destroy(GameObject.Find("PanelOverWriteData"));
            _newGameAnimationOn = _canvasMenu.GetComponent<AnimationUserInterfaceController>().HztAnimToDestroyLeftToRight("NewGamePanel",
                _canvasMenu.GetComponent<RectTransform>().rect.width / 2
                + GameObject.Find("NewGamePanel").GetComponent<RectTransform>().rect.width / 2,
                1);
        }
    }

    private void CheckOpenPanel()
    {
        if(GameObject.Find("LoadGamePanel") == true)
        {
            GameObject.Find("LoadGameButton").GetComponent<SetLoadGameButtonScript>().LoadGamePanelActivated = false;
            GameObject.Find("LoadGameButton").GetComponent<SetLoadGameButtonScript>().LoadGameAnimationOn = true;
        }

        if(GameObject.Find("ConfigurePanel") == true)
        {
            GameObject.Find("ConfigureGameButton").GetComponent<SetConfigureButtonScript>().ConfigurePanelActivated = false;
            GameObject.Find("ConfigureGameButton").GetComponent<SetConfigureButtonScript>().ConfigurePanelAnimationOn = true;
        }
    }

    public virtual void OnPointerDown(PointerEventData NewGamePanel)
    {
        CheckOpenPanel();
        CreateNewGamePanel();
    }

    private void CreateNewGamePanel()
    {

        if(GameObject.Find("NewGamePanel") == false)
        {
            _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateEmptyGameObject("NewGamePanel", _canvasMenu, true, _canvasMenu.GetComponent<RectTransform>().rect.width / 3,
            _canvasMenu.GetComponent<RectTransform>().rect.height, ((_canvasMenu.GetComponent<RectTransform>().rect.width / 2) + (_canvasMenu.GetComponent<RectTransform>().rect.width / 6)), 0);

            _newGamePanel = GameObject.Find("NewGamePanel");

            CreateSaveStateButton();

            _newGamePanelActivated = true;
            _newGameAnimationOn = true;
        }
        else
        {
            _newGamePanelActivated = false;
            _newGameAnimationOn = true;
        }

    }

    private void CreateSaveStateButton()
    {
        for(int x = 1; x <= 3; x++)
        {
            float y = 0;
            switch (x)
            {
                case 1:
                    y = 3.5f;
                    break;
                case 2:
                    y = 0;
                    break;
                case 3:
                    y = -3.5f;
                    break;
            }

            string var = GetXAsString(x);
            CreateNewGamePanelCSaveStateComponent("SaveState" + var, "SaveState" + var, "NewGamePanel", _newGamePanel.GetComponent<RectTransform>().rect.width,
                (_newGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, (_newGamePanel.GetComponent<RectTransform>().rect.height / 10) * y);
            GameObject.Find("SaveState" + var + "ButtonZone").AddComponent<Button>();
            GameObject.Find("SaveState" + var + "ButtonZone").GetComponent<Button>().onClick.AddListener(() => SaveStateAction("SaveState" + var));
        }
    }

    private string GetXAsString(int x)
    {
        string var;

        switch (x)
        {
            case 1:
                var = "One";
                return var;
            case 2:
                var = "Two";
                return var;
            case 3:
                var = "Three";
                return var;
        }
        return null;
    }
    

    private void CreateNewGamePanelCSaveStateComponent(string GameObjectName, string PlayerPrefsCurrentSaveState, string GameObjectParentName, float sizedeltaX, float sizeDeltaY, 
        float anchoredPositionX, float anchoredPositionY)
    {
        _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage(GameObjectName, GameObject.Find(GameObjectParentName), true,
            sizedeltaX, sizeDeltaY, anchoredPositionX, anchoredPositionY, Color.clear);

        GameObject PrefabMenuGear = (GameObject)Instantiate(Resources.Load("Gear/SaveStateGear"));
        PrefabMenuGear.transform.SetParent(GameObject.Find(GameObjectName).transform.transform, true);
        PrefabMenuGear.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        PrefabMenuGear.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

        _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone(GameObjectName + "CycleTextZone", GameObject.Find(GameObjectName), true,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 2, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / 2,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 4, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / 4, "",
            _canvasMenu.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(Screen.height / 20)), Color.black);
        if (PlayerPrefs.GetInt("Is" + PlayerPrefsCurrentSaveState + "Used") != 1)
        {
            _canvasMenu.GetComponent<TextMonitoring>().SetTextInCorrectLanguages(GameObjectName + "CycleTextZone", "Empty Save", "Sauvegarde Vide");
        }
        else
        {
            _canvasMenu.GetComponent<TextMonitoring>().SetTextInCorrectLanguages(GameObjectName + "CycleTextZone", "Number of cycle : " + PlayerPrefs.GetInt(PlayerPrefsCurrentSaveState + "Cycle"), "Nombre de cycle : " + PlayerPrefs.GetInt(PlayerPrefsCurrentSaveState + "Cycle"));
        }

        _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone(GameObjectName + "FragmentTextZone", GameObject.Find(GameObjectName), true,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 2, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / 2,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width / 4, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height / -4, "",
            _canvasMenu.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(Screen.height / 20)), Color.black);
        if (PlayerPrefs.GetInt("Is" + PlayerPrefsCurrentSaveState + "Used") != 1)
        {
            _canvasMenu.GetComponent<TextMonitoring>().SetTextInCorrectLanguages((GameObjectName + "FragmentTextZone"), "Start New Game", "Nouvelle Partie");
        }
        else
        {
            _canvasMenu.GetComponent<TextMonitoring>().SetTextInCorrectLanguages((GameObjectName + "FragmentTextZone"), "Number of fragments : " + PlayerPrefs.GetInt(PlayerPrefsCurrentSaveState + "Fragments"), "Nombre de fragments : " + PlayerPrefs.GetInt(PlayerPrefsCurrentSaveState + "Fragments"));
        }

        _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateEmptyGameObject(GameObjectName + "ButtonZone", GameObject.Find(GameObjectName), true,
            GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.width, GameObject.Find(GameObjectName).GetComponent<RectTransform>().rect.height, 0, 0);
        GameObject.Find(GameObjectName + "ButtonZone").AddComponent<Image>();
        GameObject.Find(GameObjectName + "ButtonZone").GetComponent<Image>().color = Color.clear;
    }

    public void SaveStateAction(string SaveStateName)
    {

        if (PlayerPrefs.GetInt("Is" + SaveStateName + "Used") == 1)
        {
            OverWriteDataFile(SaveStateName);
        }
        else
        {
            PlayerPrefs.SetInt("Is" + SaveStateName + "Used", 1);
            PlayerPrefs.SetString("CurrentSaveStateUsed", SaveStateName);
            _canvasMenu.GetComponent<SaveAndLoadSystemController>().InitializeBackUpSystemToZero();
            PlayerPrefs.SetString("CurrentScene", PlayerPrefs.GetString(SaveStateName + "LastScene"));
            SceneManager.LoadScene(PlayerPrefs.GetString(SaveStateName + "LastScene"));
        }
    }

    private void OverWriteDataFile(string SaveStateName)
    {

        _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("PanelOverWriteData", _canvasMenu, true,
            _canvasMenu.GetComponent<RectTransform>().rect.width / 4, _canvasMenu.GetComponent<RectTransform>().rect.height / 2,
            0, 0, _canvasMenu.GetComponent<ImageMonitoring>().GetBackGround5);

        _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelOverWriteDataLabel", GameObject.Find("PanelOverWriteData"), true,
            GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width, GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 3, 0,
            GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 6,
            "", _canvasMenu.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(Screen.height / 20)), Color.black);
        _canvasMenu.GetComponent<TextMonitoring>().SetTextInCorrectLanguages(("PanelOverWriteDataLabel"), "OverWrite Data File", "Ecraser les données");

        _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelOverWriteDataLabelYes", GameObject.Find("PanelOverWriteData"), true,
            GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 3,
            -GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 3.5f,
            -(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 6),
            "", _canvasMenu.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(Screen.height / 20)), Color.black);
        _canvasMenu.GetComponent<TextMonitoring>().SetTextInCorrectLanguages(("PanelOverWriteDataLabelYes"), "YES", "OUI");
        GameObject.Find("PanelOverWriteDataLabelYes").AddComponent<Button>();
        GameObject.Find("PanelOverWriteDataLabelYes").GetComponent<Button>().onClick.AddListener(() => Yes(SaveStateName));

        _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelOverWriteDataLabelNo", GameObject.Find("PanelOverWriteData"), true,
            GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 3,
            GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 3.5f,
            -(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 6),
            "", _canvasMenu.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(Screen.height / 20)), Color.black);
        _canvasMenu.GetComponent<TextMonitoring>().SetTextInCorrectLanguages(("PanelOverWriteDataLabelNo"), "NO", "NON");
        GameObject.Find("PanelOverWriteDataLabelNo").AddComponent<Button>();
        GameObject.Find("PanelOverWriteDataLabelNo").GetComponent<Button>().onClick.AddListener(() => No());
    }

    private void Yes(string SaveStateName)
    {
        Destroy(GameObject.Find("PanelOverWriteData"));

        PlayerPrefs.SetInt("Is" + SaveStateName + "Used", 1);
        PlayerPrefs.SetString("CurrentSaveStateUsed", SaveStateName);
        _canvasMenu.GetComponent<SaveAndLoadSystemController>().InitializeBackUpSystemToZero();
        PlayerPrefs.SetString("CurrentScene", PlayerPrefs.GetString(SaveStateName + "LastScene"));
        SceneManager.LoadScene(PlayerPrefs.GetString(SaveStateName + "LastScene"));
    }

    private void No()
    {
        Destroy(GameObject.Find("PanelOverWriteData"));
    }
}
