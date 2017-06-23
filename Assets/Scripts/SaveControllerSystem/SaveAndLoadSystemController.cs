using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveAndLoadSystemController : MonoBehaviour {

	public void InitializeBackUpSystemToZero()
    {
        // Script de BackUp System

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateOne")
        {
            PlayerPrefs.SetFloat("SaveStateOneAstridPositionX", 6f);
            PlayerPrefs.SetFloat("SaveStateOneAstridPositionY", 5f);
            PlayerPrefs.SetFloat("SaveStateOneAstridPositionZ", 3f);
            PlayerPrefs.SetFloat("CurrentAstridPositionX", 6f);
            PlayerPrefs.SetFloat("CurrentAstridPositionY", 5f);
            PlayerPrefs.SetFloat("CurrentAstridPositionZ", 3f);
            PlayerPrefs.SetFloat("CurrentAstridRotationX", 0);
            PlayerPrefs.SetFloat("CurrentAstridRotationY", -180);
            PlayerPrefs.SetFloat("CurrentAstridRotationZ", 0);
            PlayerPrefs.SetInt("SaveStateOneCycle", 0);
            PlayerPrefs.SetInt("SaveStateOneFragments", 0);
            PlayerPrefs.SetString("SaveStateOneLastScene", "LostTimeAstridHouse");
        }
        else if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateTwo")
        {
            PlayerPrefs.SetFloat("SaveStateTwoAstridPositionX", 6f);
            PlayerPrefs.SetFloat("SaveStateTwoAstridPositionY", 5f);
            PlayerPrefs.SetFloat("SaveStateTwoAstridPositionZ", 3f);
            PlayerPrefs.SetFloat("CurrentAstridPositionX", 6f);
            PlayerPrefs.SetFloat("CurrentAstridPositionY", 5f);
            PlayerPrefs.SetFloat("CurrentAstridPositionZ", 3f);
            PlayerPrefs.SetFloat("CurrentAstridRotationX", 0);
            PlayerPrefs.SetFloat("CurrentAstridRotationY", -180);
            PlayerPrefs.SetFloat("CurrentAstridRotationZ", 0);
            PlayerPrefs.SetInt("SaveStateTwoCycle", 0);
            PlayerPrefs.SetInt("SaveStateTwoFragments", 0);
            PlayerPrefs.SetString("SaveStateTwoLastScene", "LostTimeAstridHouse");
        }
        else if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateThree")
        {
            PlayerPrefs.SetFloat("SaveStatethreeAstridPositionX", 6f);
            PlayerPrefs.SetFloat("SaveStatethreeAstridPositionY", 5f);
            PlayerPrefs.SetFloat("SaveStatethreeAstridPositionZ", 3f);
            PlayerPrefs.SetFloat("CurrentAstridPositionX", 6f);
            PlayerPrefs.SetFloat("CurrentAstridPositionY", 5f);
            PlayerPrefs.SetFloat("CurrentAstridPositionZ", 3f);
            PlayerPrefs.SetFloat("CurrentAstridRotationX", 0);
            PlayerPrefs.SetFloat("CurrentAstridRotationY", -180);
            PlayerPrefs.SetFloat("CurrentAstridRotationZ", 0);
            PlayerPrefs.SetInt("SaveStateThreeCycle", 0);
            PlayerPrefs.SetInt("SaveStateThreeFragments", 0);
            PlayerPrefs.SetString("SaveStateThreeLastScene", "LostTimeAstridHouse");
        }
    }

    public void SaveBackUpSystem(string CurrentScene)
    {
        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateOne")
        {
            PlayerPrefs.SetFloat("SaveStateOneAstridPositionX", GameObject.Find("AstridPlayer").transform.position.x);
            PlayerPrefs.SetFloat("SaveStateOneAstridPositionY", GameObject.Find("AstridPlayer").transform.position.y + 1); // +1 pour éviter que astrid ne tombe sous la map au prochain chargement du niveau
            PlayerPrefs.SetFloat("SaveStateOneAstridPositionZ", GameObject.Find("AstridPlayer").transform.position.z);
            PlayerPrefs.SetFloat("SaveStateOneAstridRotationX", GameObject.Find("AstridPlayer").transform.rotation.x);
            PlayerPrefs.SetFloat("SaveStateOneAstridRotationY", GameObject.Find("AstridPlayer").transform.rotation.y);
            PlayerPrefs.SetFloat("SaveStateOneAstridRotationZ", GameObject.Find("AstridPlayer").transform.rotation.z);
            //PlayerPrefs.SetFloat("SaveStateOneTimer", GameObject.Find("Sun").GetComponent<Timer>().CurrentTimeOfDay);
            PlayerPrefs.SetString("SaveStateOneLastScene", CurrentScene);
        }
        else if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateTwo")
        {
            PlayerPrefs.SetFloat("SaveStateTwoAstridPositionX", GameObject.Find("AstridPlayer").transform.position.x);
            PlayerPrefs.SetFloat("SaveStateTwoAstridPositionY", GameObject.Find("AstridPlayer").transform.position.y + 1); // +1 pour éviter que astrid ne tombe sous la map au prochain chargement du niveau
            PlayerPrefs.SetFloat("SaveStateTwoAstridPositionZ", GameObject.Find("AstridPlayer").transform.position.z);
            PlayerPrefs.SetFloat("SaveStateTwoAstridRotationX", GameObject.Find("AstridPlayer").transform.rotation.x);
            PlayerPrefs.SetFloat("SaveStateTwoAstridRotationY", GameObject.Find("AstridPlayer").transform.rotation.y);
            PlayerPrefs.SetFloat("SaveStateTwoAstridRotationZ", GameObject.Find("AstridPlayer").transform.rotation.z);
            //PlayerPrefs.SetFloat("SaveStateTwoTimer", GameObject.Find("Sun").GetComponent<Timer>().CurrentTimeOfDay);
            PlayerPrefs.SetString("SaveStateTwoLastScene", CurrentScene);
        }
        else if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateThree")
        {
            PlayerPrefs.SetFloat("SaveStateThreeAstridPositionX", GameObject.Find("AstridPlayer").transform.position.x);
            PlayerPrefs.SetFloat("SaveStateThreeAstridPositionY", GameObject.Find("AstridPlayer").transform.position.y + 1); // +1 pour éviter que astrid ne tombe sous la map au prochain chargement du niveau
            PlayerPrefs.SetFloat("SaveStateThreeAstridPositionZ", GameObject.Find("AstridPlayer").transform.position.z);
            PlayerPrefs.SetFloat("SaveStateThreeAstridRotationX", GameObject.Find("AstridPlayer").transform.rotation.x);
            PlayerPrefs.SetFloat("SaveStateThreeAstridRotationY", GameObject.Find("AstridPlayer").transform.rotation.y);
            PlayerPrefs.SetFloat("SaveStateThreeAstridRotationZ", GameObject.Find("AstridPlayer").transform.rotation.z);
            //PlayerPrefs.SetFloat("SaveStateThreeTimer", GameObject.Find("Sun").GetComponent<Timer>().CurrentTimeOfDay);
            PlayerPrefs.SetString("SaveStateThreeLastScene", CurrentScene);
        }
    }

    public void LoadBackUpSystem()
    {
        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateOne")
        {
            PlayerPrefs.SetFloat("CurrentAstridPositionX", PlayerPrefs.GetFloat("SaveStateOneAstridPositionX"));
            PlayerPrefs.SetFloat("CurrentAstridPositionY", PlayerPrefs.GetFloat("SaveStateOneAstridPositionY"));
            PlayerPrefs.SetFloat("CurrentAstridPositionZ", PlayerPrefs.GetFloat("SaveStateOneAstridPositionZ"));
            PlayerPrefs.SetFloat("CurrentAstridRotationX", PlayerPrefs.GetFloat("SaveStateOneAstridRotationX"));
            PlayerPrefs.SetFloat("CurrentAstridRotationY", PlayerPrefs.GetFloat("SaveStateOneAstridRotationY"));
            PlayerPrefs.SetFloat("CurrentAstridRotationZ", PlayerPrefs.GetFloat("SaveStateOneAstridRotationZ"));
            PlayerPrefs.SetString("CurrentScene", PlayerPrefs.GetString("SaveStateOneLastScene"));
            // _LoadTimer = true;
        }
        else if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateTwo")
        {
            PlayerPrefs.SetFloat("CurrentAstridPositionX", PlayerPrefs.GetFloat("SaveStateTwoAstridPositionX"));
            PlayerPrefs.SetFloat("CurrentAstridPositionY", PlayerPrefs.GetFloat("SaveStateTwoAstridPositionY"));
            PlayerPrefs.SetFloat("CurrentAstridPositionZ", PlayerPrefs.GetFloat("SaveStateTwoAstridPositionZ"));
            PlayerPrefs.SetFloat("CurrentAstridRotationX", PlayerPrefs.GetFloat("SaveStateTwoAstridRotationX"));
            PlayerPrefs.SetFloat("CurrentAstridRotationY", PlayerPrefs.GetFloat("SaveStateTwoAstridRotationY"));
            PlayerPrefs.SetFloat("CurrentAstridRotationZ", PlayerPrefs.GetFloat("SaveStateTwoAstridRotationZ"));
            PlayerPrefs.SetString("CurrentScene", PlayerPrefs.GetString("SaveStateTwoLastScene"));
            //_LoadTimer = true;
        }
        else if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateThree")
        {
            PlayerPrefs.SetFloat("CurrentAstridPositionX", PlayerPrefs.GetFloat("SaveStateThreeAstridPositionX"));
            PlayerPrefs.SetFloat("CurrentAstridPositionY", PlayerPrefs.GetFloat("SaveStateThreeAstridPositionY"));
            PlayerPrefs.SetFloat("CurrentAstridPositionZ", PlayerPrefs.GetFloat("SaveStateThreeAstridPositionZ"));
            PlayerPrefs.SetFloat("CurrentAstridRotationX", PlayerPrefs.GetFloat("SaveStateThreeAstridRotationX"));
            PlayerPrefs.SetFloat("CurrentAstridRotationY", PlayerPrefs.GetFloat("SaveStateThreeAstridRotationY"));
            PlayerPrefs.SetFloat("CurrentAstridRotationZ", PlayerPrefs.GetFloat("SaveStateThreeAstridRotationZ"));
            PlayerPrefs.SetString("CurrentScene", PlayerPrefs.GetString("SaveStateThreeLastScene"));
            //_LoadTimer = true;
        }
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
