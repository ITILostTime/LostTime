using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SetLoadGameButtonScript : MonoBehaviour, IPointerDownHandler
{
    private GameObject _canvasMenu;
    private GameObject _loadGamePanel;
    private bool _loadGamePanelActivated;
    private bool _loadGameAnimationOn;

    public bool LoadGamePanelActivated
    { get
        {
            return _loadGamePanelActivated;
        }
        set
        {
            _loadGamePanelActivated = value;
        }

    }

    public bool LoadGameAnimationOn
    {
        get
        {
            return _loadGameAnimationOn;
        }
        set
        {
            _loadGameAnimationOn = value;
        }
    }


    private void Start()
    {
        _canvasMenu = GameObject.Find("MenuCanvas");
    }

    private void Update()
    {

        if (GameObject.Find("LoadGamePanel") == true && _loadGamePanelActivated == true && _loadGameAnimationOn == true)
        {
            _loadGameAnimationOn = _canvasMenu.GetComponent<AnimationUserInterfaceController>().HztAnimToUserInterfaceRightToLeft("LoadGamePanel",
                ((_canvasMenu.GetComponent<RectTransform>().rect.width / 2) - (_canvasMenu.GetComponent<RectTransform>().rect.width / 6)), 0, -1);
        }
        else if (GameObject.Find("LoadGamePanel") == true && _loadGamePanelActivated == false && _loadGameAnimationOn == true)
        {
            Destroy(GameObject.Find("PanelSaveStateEmpty"));
            _loadGameAnimationOn = _canvasMenu.GetComponent<AnimationUserInterfaceController>().HztAnimToDestroyLeftToRight("LoadGamePanel",
                _canvasMenu.GetComponent<RectTransform>().rect.width / 2
                + GameObject.Find("LoadGamePanel").GetComponent<RectTransform>().rect.width / 2,
                1);
        }
    }

    private void CheckOpenPanel()
    {
        if (GameObject.Find("NewGamePanel") == true)
        {
            GameObject.Find("NewGameButton").GetComponent<SetNewGameButtonScript>().NewGamePanelActivated = false;
            GameObject.Find("NewGameButton").GetComponent<SetNewGameButtonScript>().NewGameAnimationOn = true;
        }

        if (GameObject.Find("ConfigurePanel") == true)
        {
            GameObject.Find("ConfigureGameButton").GetComponent<SetConfigureButtonScript>().ConfigurePanelActivated = false;
            GameObject.Find("ConfigureGameButton").GetComponent<SetConfigureButtonScript>().ConfigurePanelAnimationOn = true;
        }
    }

    public virtual void OnPointerDown(PointerEventData LoadGamePanel)
    {
        CheckOpenPanel();
        CreateLoadGamePanel();
    }

    private void CreateLoadGamePanel()
    {
        if (GameObject.Find("LoadGamePanel") == false)
        {
            _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateEmptyGameObject("LoadGamePanel", _canvasMenu, true, _canvasMenu.GetComponent<RectTransform>().rect.width / 3,
            _canvasMenu.GetComponent<RectTransform>().rect.height, ((_canvasMenu.GetComponent<RectTransform>().rect.width / 2) + (_canvasMenu.GetComponent<RectTransform>().rect.width / 6)), 0);

            _loadGamePanel = GameObject.Find("LoadGamePanel");


            CreateLoadSave();

            _loadGamePanelActivated = true;
            _loadGameAnimationOn = true;
        }
        else
        {
            _loadGamePanelActivated = false;
            _loadGameAnimationOn = true;
        }

    }

    private void CreateLoadSave()
    {
        for (int x = 1; x <= 3; x++)
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

            CreateNewGamePanelCSaveStateComponent("LoadSaveState" + var, "SaveState" + var, "LoadGamePanel", _loadGamePanel.GetComponent<RectTransform>().rect.width,
                (_loadGamePanel.GetComponent<RectTransform>().rect.height / 10) * 2.5f, 0, (_loadGamePanel.GetComponent<RectTransform>().rect.height / 10) * y);
            GameObject.Find("LoadSaveState" + var + "ButtonZone").AddComponent<Button>();
            GameObject.Find("LoadSaveState" + var + "ButtonZone").GetComponent<Button>().onClick.AddListener(() => LoadStateAction("SaveState" + var));
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

    private void LoadStateAction(string SaveStateName)
    {
        if (PlayerPrefs.GetInt("Is" + SaveStateName + "Used") == 1)
        {
            PlayerPrefs.SetString("CurrentSaveStateUsed", SaveStateName);
            PlayerPrefs.SetString("CurrentScene", PlayerPrefs.GetString(SaveStateName + "LastScene"));
            _canvasMenu.GetComponent<SaveAndLoadSystemController>().LoadBackUpSystem();
            SceneManager.LoadScene(PlayerPrefs.GetString(SaveStateName + "LastScene"));
        }
        else
        {
            LoadGame();
        }

    }

    private void LoadGame()
    {
        _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("PanelSaveStateEmpty", _canvasMenu, true,
            _canvasMenu.GetComponent<RectTransform>().rect.width / 4, _canvasMenu.GetComponent<RectTransform>().rect.height / 2,
            0, 0, _canvasMenu.GetComponent<ImageMonitoring>().GetBackGround5);

        _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelSaveStateEmptyLabel", GameObject.Find("PanelSaveStateEmpty"), true,
            GameObject.Find("PanelSaveStateEmpty").GetComponent<RectTransform>().rect.width, GameObject.Find("PanelSaveStateEmpty").GetComponent<RectTransform>().rect.height / 3, 0,
            GameObject.Find("PanelSaveStateEmpty").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelSaveStateEmpty").GetComponent<RectTransform>().rect.height / 6,
            "", _canvasMenu.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(Screen.height / 20)), Color.black);
        _canvasMenu.GetComponent<TextMonitoring>().SetTextInCorrectLanguages(("PanelSaveStateEmptyLabel"), "Empty SaveState", "Sauvegarde Vide");

        _canvasMenu.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelSaveStateEmptyLabelYes", GameObject.Find("PanelSaveStateEmpty"), true,
            GameObject.Find("PanelSaveStateEmpty").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("PanelSaveStateEmpty").GetComponent<RectTransform>().rect.height / 3,
            0, -(GameObject.Find("PanelSaveStateEmpty").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelSaveStateEmpty").GetComponent<RectTransform>().rect.height / 6),
            "", _canvasMenu.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
            ((int)(Screen.height / 20)), Color.black);
        _canvasMenu.GetComponent<TextMonitoring>().SetTextInCorrectLanguages(("PanelSaveStateEmptyLabelYes"), "OK", "OK");
        GameObject.Find("PanelSaveStateEmptyLabelYes").AddComponent<Button>();
        GameObject.Find("PanelSaveStateEmptyLabelYes").GetComponent<Button>().onClick.AddListener(() => Ok());
    }

    private void Ok()
    {
        Destroy(GameObject.Find("PanelSaveStateEmpty"));
    }
}
