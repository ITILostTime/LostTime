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
    private float _timeToWait = 0.01f;
    private GameObject LoadingScreen;
    private string _waypointName;

    public void StartLoadingNewScene(string waypointName)
    {
        _waypointName = waypointName;
        StartCoroutine("LaunchScreen");
    }

    private IEnumerator LaunchScreen()
    {
        CreateCanvas();

        while(_currentCanvasAlpha < 1)
        {
            yield return new WaitForSeconds(_timeToWait);
            _currentCanvasAlpha += 0.05f;

            LoadingScreen.GetComponent<Image>().color = new Color(0, 0, 0, _currentCanvasAlpha);
        }
        EndLoadingScreen();
    }

    private IEnumerator CloseScreen()
    {
        while (_currentCanvasAlpha > 0)
        {
            yield return new WaitForSeconds(_timeToWait);
            _currentCanvasAlpha -= 0.05f;

            LoadingScreen.GetComponent<Image>().color = new Color(0, 0, 0, _currentCanvasAlpha);
        }
        Destroy(GameObject.Find("loadingScreen"));
    }

    private void CreateCanvas()
    {
        LoadingScreen = new GameObject("LoadindCanvas");
        Canvas LoadindCanvas = LoadingScreen.AddComponent<Canvas>();
        LoadingScreen.AddComponent<CanvasScaler>();
        LoadingScreen.AddComponent<GraphicRaycaster>(); 
        LoadindCanvas.renderMode = RenderMode.ScreenSpaceOverlay;

        LoadingScreen.AddComponent<Image>();
        LoadingScreen.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    private void EndLoadingScreen()
    {
        LoadSceneSystem();
        StartCoroutine("CloseScreen");
    }

    public void LoadSceneSystem()
    {
        if (_waypointName == "LostTimeAstridHouseToLostTimeGearDistrictWayPoints")
        {
            GameObject.Find("MenuCanvas").GetComponent<SaveAndLoadSystemController>().SetNewCurrentAstridPositionOnLoadScene(_waypointName);
            SceneManager.LoadScene("LostTimeGearDistrict");
        }
        else if (_waypointName == "LostTimeGearDistrictToAstridHouseWayPoints")
        {
            GameObject.Find("MenuCanvas").GetComponent<SaveAndLoadSystemController>().SetNewCurrentAstridPositionOnLoadScene(_waypointName);
            SceneManager.LoadScene("LostTimeAstridHouse");
        }
    }
}
