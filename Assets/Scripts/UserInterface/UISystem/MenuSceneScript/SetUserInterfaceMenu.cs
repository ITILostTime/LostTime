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

        SetUserInterface();
    }

    private void Update()
    {
        _menuCanvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("NewGameButton", "New Game", "Nouvelle Partie");
        _menuCanvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("LoadGameButton", "Load Game", "Charger une partie");
        _menuCanvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("ConfigureGameButton", "Options", "Options");
    }

    private void SetUserInterface()
    {
        _menuCanvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("NewGameButton", _menuCanvas, true, _gameName.GetComponent<RectTransform>().rect.width,
            _gameName.GetComponent<RectTransform>().rect.height / 4, _menuCanvas.GetComponent<RectTransform>().rect.width / -2 + _gameName.GetComponent<RectTransform>().rect.width / 2,
             _gameName.GetComponent<RectTransform>().rect.height / 4, "",
            _menuCanvas.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, ((int)(Screen.height / 20)), Color.black);
        _menuCanvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("NewGameButton", "New Game", "Nouvelle Partie");
        GameObject.Find("NewGameButton").AddComponent<SetNewGameButtonScript>();

        _menuCanvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("LoadGameButton", GameObject.Find("NewGameButton"), true, 
            GameObject.Find("NewGameButton").GetComponent<RectTransform>().rect.width, GameObject.Find("NewGameButton").GetComponent<RectTransform>().rect.height, 
            0, GameObject.Find("NewGameButton").GetComponent<RectTransform>().rect.height * -2, "",
            _menuCanvas.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, ((int)(Screen.height / 20)), Color.black);
        _menuCanvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("LoadGameButton", "Load Game", "Charger une partie");
        GameObject.Find("LoadGameButton").AddComponent<SetLoadGameButtonScript>();

        _menuCanvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("ConfigureGameButton", GameObject.Find("LoadGameButton"), true,
            GameObject.Find("LoadGameButton").GetComponent<RectTransform>().rect.width, GameObject.Find("LoadGameButton").GetComponent<RectTransform>().rect.height,
            0, GameObject.Find("LoadGameButton").GetComponent<RectTransform>().rect.height * -2, "",
            _menuCanvas.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, ((int)(Screen.height / 20)), Color.black);
        _menuCanvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("ConfigureGameButton", "Options", "Options");
        GameObject.Find("ConfigureGameButton").AddComponent<SetConfigureButtonScript>();
    }
}
