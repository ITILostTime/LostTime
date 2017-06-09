using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUserInterfaceMenu : MonoBehaviour {

    private GameObject _menuCanvas;
    private GameObject _gameName;

    private void Start()
    {
        _menuCanvas = GameObject.Find("MenuCanvas");
        _gameName = GameObject.Find("GameName(Clone)");

        setUserInterface();
    }

    private void Update()
    {
        _menuCanvas.GetComponent<TextMonitoring>().setTextInCorrectLanguages("NewGameButton", "New Game", "Nouvelle Partie");
        _menuCanvas.GetComponent<TextMonitoring>().setTextInCorrectLanguages("LoadGameButton", "Load Game", "Charger une partie");
        _menuCanvas.GetComponent<TextMonitoring>().setTextInCorrectLanguages("ConfigureGameButton", "Options", "Options");
    }

    private void setUserInterface()
    {
        _menuCanvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("NewGameButton", _menuCanvas, true, _gameName.GetComponent<RectTransform>().rect.width,
            _gameName.GetComponent<RectTransform>().rect.height / 4, _menuCanvas.GetComponent<RectTransform>().rect.width / -2 + _gameName.GetComponent<RectTransform>().rect.width / 2, 
            _gameName.GetComponent<RectTransform>().rect.height / 2, "",
            _menuCanvas.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, ((int)(Screen.height / 20)), Color.black);
        _menuCanvas.GetComponent<TextMonitoring>().setTextInCorrectLanguages("NewGameButton", "New Game", "Nouvelle Partie");
        GameObject.Find("NewGameButton").AddComponent<SetNewGameButtonScript>();

        _menuCanvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("LoadGameButton", _menuCanvas, true, _gameName.GetComponent<RectTransform>().rect.width,
            _gameName.GetComponent<RectTransform>().rect.height / 4, _menuCanvas.GetComponent<RectTransform>().rect.width / -2 + _gameName.GetComponent<RectTransform>().rect.width / 2, 0, "",
            _menuCanvas.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, ((int)(Screen.height / 20)), Color.black);
        _menuCanvas.GetComponent<TextMonitoring>().setTextInCorrectLanguages("LoadGameButton", "Load Game", "Charger une partie");
        GameObject.Find("LoadGameButton").AddComponent<SetLoadGameButtonScript>();

        _menuCanvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("ConfigureGameButton", _menuCanvas, true,
            _gameName.GetComponent<RectTransform>().rect.width, _gameName.GetComponent<RectTransform>().rect.height / 4,
            _menuCanvas.GetComponent<RectTransform>().rect.width / -2 + _gameName.GetComponent<RectTransform>().rect.width / 2, _gameName.GetComponent<RectTransform>().rect.height / -2,
            "", _menuCanvas.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, ((int)(Screen.height / 20)), Color.black);
        _menuCanvas.GetComponent<TextMonitoring>().setTextInCorrectLanguages("ConfigureGameButton", "Options", "Options");
        GameObject.Find("ConfigureGameButton").AddComponent<SetConfigureButtonScript>();
    }
}
