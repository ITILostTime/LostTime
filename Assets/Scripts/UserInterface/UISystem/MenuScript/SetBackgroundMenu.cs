using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetBackgroundMenu : MonoBehaviour {

    private GameObject _menuCanvas;

	void Start ()
    {
        if (PlayerPrefs.HasKey("CurrentLanguagesUsed") == false)
        {
            SceneManager.LoadScene("LostTimeGameLanguagesFirstChoice");
        }

        GameObject CanvasMenu = new GameObject("MenuCanvas");
        Canvas MenuCanvas = CanvasMenu.AddComponent<Canvas>();
        CanvasMenu.AddComponent<CanvasScaler>();
        CanvasMenu.AddComponent<GraphicRaycaster>();
        MenuCanvas.renderMode = RenderMode.ScreenSpaceOverlay;

        CanvasMenu.AddComponent<AnimationUserInterfaceController>();
        CanvasMenu.AddComponent<CreateUserInterfaceObject>();
        CanvasMenu.AddComponent<TextMonitoring>();
        CanvasMenu.AddComponent<SaveController>();
        CanvasMenu.AddComponent<ImageMonitoring>();

        _menuCanvas = GameObject.Find("MenuCanvas");

        GameObject PrefabCloudLayer = (GameObject)Instantiate(Resources.Load("CloudLayer/CloudLayer"));
        PrefabCloudLayer.transform.SetParent(_menuCanvas.transform, true);
        PrefabCloudLayer.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        PrefabCloudLayer.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

        GameObject GameLogo = (GameObject)Instantiate(Resources.Load("GameLogo&Title/GameLogo"));
        GameLogo.transform.SetParent(_menuCanvas.transform, true);
        GameLogo.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height, Screen.height);
        GameLogo.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

        GameObject GameName = (GameObject)Instantiate(Resources.Load("GameLogo&Title/GameName"));
        GameName.transform.SetParent(_menuCanvas.transform, true);
        GameName.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 3, Screen.height / 3);
        GameName.GetComponent<RectTransform>().anchoredPosition = new Vector2(((-Screen.width / 2) + GameObject.Find("GameName(Clone)").GetComponent<RectTransform>().rect.width / 2), Screen.height / 3);

        GameObject UserInterfaceEvent = new GameObject("UserInterfaceEvent");
        UserInterfaceEvent.transform.SetParent(_menuCanvas.transform, true);
        UserInterfaceEvent.AddComponent<StandaloneInputModule>();
        UserInterfaceEvent.AddComponent<SetUserInterfaceMenu>();


    }
}
