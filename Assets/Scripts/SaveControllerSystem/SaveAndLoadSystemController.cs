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
            string var = GetXAsString(x);

            if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveState" + var)
            {
                PlayerPrefs.SetFloat("SaveState" + var + "AstridPositionX", 6f);
                PlayerPrefs.SetFloat("SaveState" + var + "AstridPositionY", 5f);
                PlayerPrefs.SetFloat("SaveState" + var + "AstridPositionZ", 3f);
                PlayerPrefs.SetFloat("CurrentAstridPositionX", 6f);
                PlayerPrefs.SetFloat("CurrentAstridPositionY", 5f);
                PlayerPrefs.SetFloat("CurrentAstridPositionZ", 3f);
                PlayerPrefs.SetFloat("CurrentAstridRotationX", 0);
                PlayerPrefs.SetFloat("CurrentAstridRotationY", -180);
                PlayerPrefs.SetFloat("CurrentAstridRotationZ", 0);
                PlayerPrefs.SetInt("SaveState" + var + "Cycle", 0);
                PlayerPrefs.SetInt("SaveState" + var + "Fragments", 0);
                PlayerPrefs.SetString("SaveState" + var + "LastScene", "LostTimeAstridHouse");
            }
        }
    }

    public void SaveBackUpSystem(string CurrentScene)
    {
        for (int x = 1; x <= 3; x++)
        {
            string var = GetXAsString(x);
            if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveState" + var)
            {
                PlayerPrefs.SetFloat("SaveState" + var + "AstridPositionX", GameObject.Find("AstridPlayer").transform.position.x);
                PlayerPrefs.SetFloat("SaveState" + var + "AstridPositionY", GameObject.Find("AstridPlayer").transform.position.y + 1); // +1 pour éviter que astrid ne tombe sous la map au prochain chargement du niveau
                PlayerPrefs.SetFloat("SaveState" + var + "AstridPositionZ", GameObject.Find("AstridPlayer").transform.position.z);
                PlayerPrefs.SetFloat("SaveState" + var + "AstridRotationX", GameObject.Find("AstridPlayer").transform.rotation.x);
                PlayerPrefs.SetFloat("SaveState" + var + "AstridRotationY", GameObject.Find("AstridPlayer").transform.rotation.y);
                PlayerPrefs.SetFloat("SaveState" + var + "AstridRotationZ", GameObject.Find("AstridPlayer").transform.rotation.z);
                //PlayerPrefs.SetFloat("SaveStateOneTimer", GameObject.Find("Sun").GetComponent<Timer>().CurrentTimeOfDay);
                PlayerPrefs.SetString("SaveState" + var + "LastScene", CurrentScene);
            }
        }
    }

    public void LoadBackUpSystem()
    {
        for(int x = 1; x <= 3; x++)
        {
            string var = GetXAsString(x);
            if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveState" + var)
            {
                PlayerPrefs.SetFloat("CurrentAstridPositionX", PlayerPrefs.GetFloat("SaveState" + var + "AstridPositionX"));
                PlayerPrefs.SetFloat("CurrentAstridPositionY", PlayerPrefs.GetFloat("SaveState" + var + "AstridPositionY"));
                PlayerPrefs.SetFloat("CurrentAstridPositionZ", PlayerPrefs.GetFloat("SaveState" + var + "AstridPositionZ"));
                PlayerPrefs.SetFloat("CurrentAstridRotationX", PlayerPrefs.GetFloat("SaveState" + var + "AstridRotationX"));
                PlayerPrefs.SetFloat("CurrentAstridRotationY", PlayerPrefs.GetFloat("SaveState" + var + "AstridRotationY"));
                PlayerPrefs.SetFloat("CurrentAstridRotationZ", PlayerPrefs.GetFloat("SaveState" + var + "AstridRotationZ"));
                PlayerPrefs.SetString("CurrentScene", PlayerPrefs.GetString("SaveState" + var + "LastScene"));
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

    public void SetNewCurrentAstridPositionOnLoadScene(string wayPointsName)
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
}
