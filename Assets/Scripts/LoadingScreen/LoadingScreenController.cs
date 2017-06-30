using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenController : MonoBehaviour
{

    // générer un new canvas 
    // fct affichage du loading screen
    // fct pour effacer le loadind screen

    /*
     * idée : 
     * le script génère un canvas => page de chargement , charge la nouvelle scene, ferme le canvas
     * ==> ouvre le canvas
     * ==> charge la nouvelle scène
     * ==> ferme le canvas
    */

    private float _currentCanvasAlpha;
    private float _timeToWait = 0.1f;
    private GameObject LoadingScreen;
    private GameObject PrefabCloudLayer;
    private GameObject GameLogo;
    private GameObject LoadingBar;
    private string _waypointName;
    private AsyncOperation operation;

    public void StartLoadingNewScene(string waypointName)
    {
        _waypointName = waypointName;
        StartCoroutine(LaunchScreen());
    }

    private IEnumerator LaunchScreen()
    {
        CreateCanvas();
        
        SetLoadingPanel();
            
        while (_currentCanvasAlpha < 1)
        {
            yield return new WaitForSeconds(_timeToWait);
            _currentCanvasAlpha += 0.05f;

            LoadingScreen.GetComponent<Image>().color = new Color(0, 0, 0, _currentCanvasAlpha);
            PrefabCloudLayerUpdateAlpha(_currentCanvasAlpha);
            PrefabLoadingBarUpdateAlpha(_currentCanvasAlpha);
            if (_currentCanvasAlpha < 0.6f)
            {
                GameLogo.GetComponent<Image>().color = new Color(255, 255, 255, _currentCanvasAlpha);
            }
        }
        EndLoadingScreen();
    }

    private void PrefabCloudLayerUpdateAlpha(float newAlpha)
    {
        for (int i = 1; i <= 5; i++)
        {
            PrefabCloudLayer.transform.FindChild("cloudLayer" + i).GetComponent<Image>().color = new Color(255, 255, 255, newAlpha);
        }
    }

    private void PrefabLoadingBarUpdateAlpha(float newAlpha)
    {
        LoadingBar.transform.FindChild("Background").GetComponent<Image>().color = new Color(255, 255, 255, newAlpha);
        LoadingBar.transform.FindChild("Fill Area").transform.FindChild("Fill").GetComponent<Image>().color = new Color(116, 0, 0, newAlpha);
        LoadingBar.transform.FindChild("Handle Slide Area").transform.FindChild("Handle").GetComponent<Image>().color = new Color(255, 255, 255, newAlpha);

    }

    private void SetLoadingPanel()
    {

        PrefabCloudLayer = (GameObject)Instantiate(Resources.Load("CloudLayer/CloudLayer"));
        PrefabCloudLayer.transform.SetParent(GameObject.Find("LoadingCanvas").transform, true);
        PrefabCloudLayer.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        PrefabCloudLayer.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        PrefabCloudLayerUpdateAlpha(0);

        GameLogo = (GameObject)Instantiate(Resources.Load("GameLogo&Title/GameLogo"));
        GameLogo.transform.SetParent(GameObject.Find("LoadingCanvas").transform, true);
        GameLogo.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height, Screen.height);
        GameLogo.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        GameLogo.GetComponent<Image>().color = new Color(255, 255, 255, 0);

        LoadingBar = (GameObject)Instantiate(Resources.Load("UnityUserInterfacePrefabs/ConfigureSoundPrefab"));
        LoadingBar.transform.name = "LoadingBarUI";
        LoadingBar.transform.SetParent(GameObject.Find("LoadingCanvas").transform, true);
        LoadingBar.GetComponent<RectTransform>().sizeDelta = new Vector2((GameObject.Find("LoadingCanvas").GetComponent<RectTransform>().rect.width / 2), 
            GameObject.Find("LoadingCanvas").GetComponent<RectTransform>().rect.height / 20);
        LoadingBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 
            (GameObject.Find("LoadingCanvas").GetComponent<RectTransform>().rect.height / -2) + GameObject.Find("LoadingCanvas").GetComponent<RectTransform>().rect.height / 40);
        GameObject.Find("LoadingBarUI").GetComponent<Slider>().value = 0;
        LoadingBar.GetComponent<Slider>().interactable = false;
        PrefabLoadingBarUpdateAlpha(0);
    }

    private IEnumerator CloseScreen()
    {
        while (_currentCanvasAlpha > 0)
        {
            yield return new WaitForSeconds(_timeToWait);
            _currentCanvasAlpha -= 0.05f;

            LoadingScreen.GetComponent<Image>().color = new Color(0, 0, 0, _currentCanvasAlpha);
            PrefabCloudLayerUpdateAlpha(_currentCanvasAlpha);
            PrefabLoadingBarUpdateAlpha(_currentCanvasAlpha);
            if (_currentCanvasAlpha < 0.6f)
            {
                GameLogo.GetComponent<Image>().color = new Color(255, 255, 255, _currentCanvasAlpha);
            }
            if(_currentCanvasAlpha < 0.6f)
            {
                operation.allowSceneActivation = true;
            }
        }

        Destroy(GameObject.Find("LoadingCanvas"));
        Destroy(GameObject.Find("loadingScreen"));
    }

    private void CreateCanvas()
    {
        LoadingScreen = new GameObject("LoadingCanvas");
        Canvas LoadingCanvas = LoadingScreen.AddComponent<Canvas>();
        LoadingScreen.AddComponent<CanvasScaler>();
        LoadingScreen.AddComponent<GraphicRaycaster>();
        LoadingCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        LoadingScreen.gameObject.layer = 5;

        LoadingScreen.AddComponent<Image>();
        LoadingScreen.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    private void EndLoadingScreen()
    {
        LoadSceneSystem();
    }

    public void LoadSceneSystem()
    {
        if (_waypointName == "LostTimeAstridHouseToLostTimeGearDistrictWayPoints")
        {
            GameObject.Find("MenuCanvas").GetComponent<SaveAndLoadSystemController>().SetNewCurrentAstridPositionOnLoadScene(_waypointName);
            StartCoroutine(LoadSceneAndLoadingBar("LostTimeGearDistrict"));
        }
        else if (_waypointName == "LostTimeGearDistrictToAstridHouseWayPoints")
        {
            GameObject.Find("MenuCanvas").GetComponent<SaveAndLoadSystemController>().SetNewCurrentAstridPositionOnLoadScene(_waypointName);
            StartCoroutine(LoadSceneAndLoadingBar("LostTimeAstridHouse"));
        }
    }

    private IEnumerator LoadSceneAndLoadingBar(string sceneName)
    {
        DontDestroyOnLoad(GameObject.Find("LoadingCanvas"));
        DontDestroyOnLoad(GameObject.Find("loadingScreen"));

        operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone && GameObject.Find("LoadingBarUI").GetComponent<Slider>().value != GameObject.Find("LoadingBarUI").GetComponent<Slider>().maxValue)
        {
            GameObject.Find("LoadingBarUI").GetComponent<Slider>().value += 0.1f;

            yield return new WaitForSeconds(_timeToWait);
        }
        StartCoroutine(CloseScreen());
    }
}
