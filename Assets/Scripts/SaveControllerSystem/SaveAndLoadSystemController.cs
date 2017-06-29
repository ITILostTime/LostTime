using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveAndLoadSystemController : MonoBehaviour {

	public void InitializeBackUpSystemToZero()
    {
        for (int x = 1; x <= 3; x++)
        {
            GetXAsString(x);
            if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveState" + x)
            {
                PlayerPrefs.SetFloat("SaveState" + x + "AstridPositionX", GameObject.Find("AstridPlayer").transform.position.x);

                PlayerPrefs.SetFloat("SaveState" + x + "AstridPositionX", 6f);
                PlayerPrefs.SetFloat("SaveState" + x + "AstridPositionY", 5f);
                PlayerPrefs.SetFloat("SaveState" + x + "AstridPositionZ", 3f);
                PlayerPrefs.SetFloat("CurrentAstridPositionX", 6f);
                PlayerPrefs.SetFloat("CurrentAstridPositionY", 5f);
                PlayerPrefs.SetFloat("CurrentAstridPositionZ", 3f);
                PlayerPrefs.SetFloat("CurrentAstridRotationX", 0);
                PlayerPrefs.SetFloat("CurrentAstridRotationY", -180);
                PlayerPrefs.SetFloat("CurrentAstridRotationZ", 0);
                PlayerPrefs.SetInt("SaveState" + x + "Cycle", 0);
                PlayerPrefs.SetInt("SaveState" + x + "Fragments", 0);
                PlayerPrefs.SetString("SaveState" + x + "LastScene", "LostTimeAstridHouse");
            }
        }
    }

    public void SaveBackUpSystem(string CurrentScene)
    {
        for (int x = 1; x <= 3; x++)
        {
            GetXAsString(x);
            if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveState" + x)
            {
                PlayerPrefs.SetFloat("SaveState" + x + "AstridPositionX", GameObject.Find("AstridPlayer").transform.position.x);
                PlayerPrefs.SetFloat("SaveState" + x + "AstridPositionY", GameObject.Find("AstridPlayer").transform.position.y + 1); // +1 pour éviter que astrid ne tombe sous la map au prochain chargement du niveau
                PlayerPrefs.SetFloat("SaveState" + x + "AstridPositionZ", GameObject.Find("AstridPlayer").transform.position.z);
                PlayerPrefs.SetFloat("SaveState" + x + "AstridRotationX", GameObject.Find("AstridPlayer").transform.rotation.x);
                PlayerPrefs.SetFloat("SaveState" + x + "AstridRotationY", GameObject.Find("AstridPlayer").transform.rotation.y);
                PlayerPrefs.SetFloat("SaveState" + x + "AstridRotationZ", GameObject.Find("AstridPlayer").transform.rotation.z);
                //PlayerPrefs.SetFloat("SaveStateOneTimer", GameObject.Find("Sun").GetComponent<Timer>().CurrentTimeOfDay);
                PlayerPrefs.SetString("SaveState" + x + "LastScene", CurrentScene);
            }
        }
    }

    public void LoadBackUpSystem()
    {
        for(int x = 1; x <= 3; x++)
        {
            GetXAsString(x);
            if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveState" + x)
            {
                PlayerPrefs.SetFloat("CurrentAstridPositionX", PlayerPrefs.GetFloat("SaveState" + x + "AstridPositionX"));
                PlayerPrefs.SetFloat("CurrentAstridPositionY", PlayerPrefs.GetFloat("SaveState" + x + "AstridPositionY"));
                PlayerPrefs.SetFloat("CurrentAstridPositionZ", PlayerPrefs.GetFloat("SaveState" + x + "AstridPositionZ"));
                PlayerPrefs.SetFloat("CurrentAstridRotationX", PlayerPrefs.GetFloat("SaveState" + x + "AstridRotationX"));
                PlayerPrefs.SetFloat("CurrentAstridRotationY", PlayerPrefs.GetFloat("SaveState" + x + "AstridRotationY"));
                PlayerPrefs.SetFloat("CurrentAstridRotationZ", PlayerPrefs.GetFloat("SaveState" + x + "AstridRotationZ"));
                PlayerPrefs.SetString("CurrentScene", PlayerPrefs.GetString("SaveState" + x + "LastScene"));
                // _LoadTimer = true;
            }
        }
    }

    private string GetXAsString(int x)
    {
        string var;

        switch(x)
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

    private void SetNewCurrentAstridPositionOnLoadScene(string wayPointsName)
    {
        if(wayPointsName == "LostTimeAstridHouseToLostTimeGearDistrictWayPoints")
        {
            PlayerPrefs.SetFloat("CurrentAstridPositionX", 16);
            PlayerPrefs.SetFloat("CurrentAstridPositionY", -0.5f);
            PlayerPrefs.SetFloat("CurrentAstridPositionZ", 30);
            PlayerPrefs.SetFloat("CurrentAstridRotationX", 0);
            PlayerPrefs.SetFloat("CurrentAstridRotationY", 85);
            PlayerPrefs.SetFloat("CurrentAstridRotationZ", 0);
            PlayerPrefs.SetString("CurrentScene", "LostTimeGearDistrict");
        }
        else if(wayPointsName == "LostTimeGearDistrictToAstridHouseWayPoints")
        {
            PlayerPrefs.SetFloat("CurrentAstridPositionX", -1.8f);
            PlayerPrefs.SetFloat("CurrentAstridPositionY", 0.02f);
            PlayerPrefs.SetFloat("CurrentAstridPositionZ", 3.5f);
            PlayerPrefs.SetFloat("CurrentAstridRotationX", 0);
            PlayerPrefs.SetFloat("CurrentAstridRotationY", -180);
            PlayerPrefs.SetFloat("CurrentAstridRotationZ", 0);
            PlayerPrefs.SetString("CurrentScene", "LostTimeAstridHouse");
        }
    }

    public void LoadSceneSystem(string wayPointsName)
    {
        if(wayPointsName == "LostTimeAstridHouseToLostTimeGearDistrictWayPoints")
        {
            SetNewCurrentAstridPositionOnLoadScene(wayPointsName);
            SceneManager.LoadScene("LostTimeGearDistrict");
        }
        else if (wayPointsName == "LostTimeGearDistrictToAstridHouseWayPoints")
        {
            SetNewCurrentAstridPositionOnLoadScene(wayPointsName);
            SceneManager.LoadScene("LostTimeAstridHouse");
        }
    }
}
