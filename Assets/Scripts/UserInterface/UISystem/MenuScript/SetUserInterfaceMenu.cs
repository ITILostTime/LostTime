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

    private void FixedUpdate()
    {
        
    }

    private void setUserInterface()
    {
        _menuCanvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("NewGameButtonBackground", _menuCanvas, true, _gameName.GetComponent<RectTransform>().rect.width,
            _gameName.GetComponent<RectTransform>().rect.height / 4, _menuCanvas.GetComponent<RectTransform>().rect.width / -2 + _gameName.GetComponent<RectTransform>().rect.width / 2,
            _gameName.GetComponent<RectTransform>().rect.height / 2, Color.clear);
        GameObject.Find("NewGameButtonBackground").AddComponent<SetNewGameButtonScript>();

        _menuCanvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("NewGameButtonText", GameObject.Find("NewGameButtonBackground"), true,
            GameObject.Find("NewGameButtonBackground").GetComponent<RectTransform>().rect.width, GameObject.Find("NewGameButtonBackground").GetComponent<RectTransform>().rect.height, 0, 0,
            "", _menuCanvas.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, ((int)(Screen.height / 20)), Color.black);
        _menuCanvas.GetComponent<TextMonitoring>().setTextInCorrectLanguages("NewGameButtonText", "New Game", "Nouvelle Partie");
    }
}
