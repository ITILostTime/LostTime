using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveController : MonoBehaviour {

    private bool _LoadTimer;

    public void SaveCurrentGameConfig(string CurrentScene)
    {
        if(PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateOne")
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

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateTwo")
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

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateThree")
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

    public void InitialisePlayerSaveState()
    {
        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateOne")
        {
            PlayerPrefs.SetFloat("SaveStateOneAstridPositionX", 6f);
            PlayerPrefs.SetFloat("SaveStateOneAstridPositionY", 10f); 
            PlayerPrefs.SetFloat("SaveStateOneAstridPositionZ", 25f);
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

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateTwo")
        {
            PlayerPrefs.SetFloat("SaveStateOneAstridPositionX", 6f);
            PlayerPrefs.SetFloat("SaveStateOneAstridPositionY", 10f);
            PlayerPrefs.SetFloat("SaveStateOneAstridPositionZ", 25f);
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

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateThree")
        {
            PlayerPrefs.SetFloat("SaveStateOneAstridPositionX", 6f);
            PlayerPrefs.SetFloat("SaveStateOneAstridPositionY", 5f);
            PlayerPrefs.SetFloat("SaveStateOneAstridPositionZ", 25f);
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

    public void SaveFragmentsPlayer()
    {
        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateOne")
        {
            int tmp = PlayerPrefs.GetInt("SaveStateOneFragments");
                tmp += 1;
            PlayerPrefs.SetInt("SaveStateOneFragments", tmp);
        }

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateTwo")
        {
            int tmp = PlayerPrefs.GetInt("SaveStateTwoFragments");
            tmp += 1;
            PlayerPrefs.SetInt("SaveStateTwoFragments", tmp);
        }

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateThree")
        {
            int tmp = PlayerPrefs.GetInt("SaveStateThreeFragments");
            tmp += 1;
            PlayerPrefs.SetInt("SaveStateThreeFragments", tmp);
        }
    }

    public void SaveCyclePlayer()
    {
        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateOne")
        {
            int tmp = PlayerPrefs.GetInt("SaveStateOneCycle");
            tmp += 1;
            PlayerPrefs.SetInt("SaveStateOneCycle", tmp);
        }

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateTwo")
        {
            int tmp = PlayerPrefs.GetInt("SaveStateThreeCycle");
            tmp += 1;
            PlayerPrefs.SetInt("SaveStateTwoCycle", tmp);
        }

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateThree")
        {
            int tmp = PlayerPrefs.GetInt("SaveStateThreeCycle");
            tmp += 1;
            PlayerPrefs.SetInt("SaveStateThreeCycle", tmp);
        }
    }

    public void LoadSceneAstridPosition(float AstridPositionX, float AstridPositionY, float AstridPositionZ, string NextScene)
    {
        Debug.Log(PlayerPrefs.GetFloat("CurrentAstridPositionX"));
        Debug.Log(PlayerPrefs.GetFloat("CurrentAstridPositionY"));
        Debug.Log(PlayerPrefs.GetFloat("CurrentAstridPositionZ"));

        //PlayerPrefs.SetFloat("CurrentAstridPositionX", AstridPositionX);
        //PlayerPrefs.SetFloat("CurrentAstridPositionY", AstridPositionY);
        //PlayerPrefs.SetFloat("CurrentAstridPositionZ", AstridPositionZ);
        PlayerPrefs.SetString("CurrentScene", NextScene);
        SceneManager.LoadScene(NextScene);
    }

    public void LoadGame()
    {
        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateOne")
        {
            PlayerPrefs.SetFloat("CurrentAstridPositionX", PlayerPrefs.GetFloat("SaveStateOneAstridPositionX"));
            PlayerPrefs.SetFloat("CurrentAstridPositionY", PlayerPrefs.GetFloat("SaveStateOneAstridPositionY"));
            PlayerPrefs.SetFloat("CurrentAstridPositionZ", PlayerPrefs.GetFloat("SaveStateOneAstridPositionZ"));
            PlayerPrefs.SetFloat("CurrentAstridRotationX", PlayerPrefs.GetFloat("SaveStateTwoAstridRotationX"));
            PlayerPrefs.SetFloat("CurrentAstridRotationY", PlayerPrefs.GetFloat("SaveStateTwoAstridRotationY"));
            PlayerPrefs.SetFloat("CurrentAstridRotationZ", PlayerPrefs.GetFloat("SaveStateTwoAstridRotationZ"));
            PlayerPrefs.SetString("CurrentScene", PlayerPrefs.GetString("SaveStateOneLastScene"));
            _LoadTimer = true;

        }

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateTwo")
        {
            PlayerPrefs.SetFloat("CurrentAstridPositionX", PlayerPrefs.GetFloat("SaveStateTwoAstridPositionX"));
            PlayerPrefs.SetFloat("CurrentAstridPositionY", PlayerPrefs.GetFloat("SaveStateTwoAstridPositionY"));
            PlayerPrefs.SetFloat("CurrentAstridPositionZ", PlayerPrefs.GetFloat("SaveStateTwoAstridPositionZ"));
            PlayerPrefs.SetFloat("CurrentAstridRotationX", PlayerPrefs.GetFloat("SaveStateTwoAstridRotationX"));
            PlayerPrefs.SetFloat("CurrentAstridRotationY", PlayerPrefs.GetFloat("SaveStateTwoAstridRotationY"));
            PlayerPrefs.SetFloat("CurrentAstridRotationZ", PlayerPrefs.GetFloat("SaveStateTwoAstridRotationZ"));
            PlayerPrefs.SetString("CurrentScene", PlayerPrefs.GetString("SaveStateTwoLastScene"));
            _LoadTimer = true;
        }

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateThree")
        {
            PlayerPrefs.SetFloat("CurrentAstridPositionX", PlayerPrefs.GetFloat("SaveStateThreeAstridPositionX"));
            PlayerPrefs.SetFloat("CurrentAstridPositionY", PlayerPrefs.GetFloat("SaveStateThreeAstridPositionY"));
            PlayerPrefs.SetFloat("CurrentAstridPositionZ", PlayerPrefs.GetFloat("SaveStateThreeAstridPositionZ"));
            PlayerPrefs.SetFloat("CurrentAstridRotationX", PlayerPrefs.GetFloat("SaveStateTwoAstridRotationX"));
            PlayerPrefs.SetFloat("CurrentAstridRotationY", PlayerPrefs.GetFloat("SaveStateTwoAstridRotationY"));
            PlayerPrefs.SetFloat("CurrentAstridRotationZ", PlayerPrefs.GetFloat("SaveStateTwoAstridRotationZ"));
            PlayerPrefs.SetString("CurrentScene", PlayerPrefs.GetString("SaveStateThreeLastScene"));
            _LoadTimer = true;
        }
    }

    public void loadTimer()
    {
        float setFirstCurrentTimeOfDay = 0.22f;

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateOne")
        {
            Debug.Log(PlayerPrefs.HasKey("SaveStateOneTimer"));

            if (PlayerPrefs.HasKey("SaveStateOneTimer") == true)
            {
                GameObject.Find("Sun").GetComponent<Timer>().CurrentTimeOfDay = PlayerPrefs.GetFloat("SaveStateOneTimer");
            }
            else
            {
                
                GameObject.Find("Sun").GetComponent<Timer>().CurrentTimeOfDay = setFirstCurrentTimeOfDay;
            }
        }

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateTwo")
        {
            if (PlayerPrefs.HasKey("SaveStateTwoTimer") == true)
            {
                GameObject.Find("Sun").GetComponent<Timer>().CurrentTimeOfDay = PlayerPrefs.GetFloat("SaveStateTwoTimer");
            }
            else
            {
                GameObject.Find("Sun").GetComponent<Timer>().CurrentTimeOfDay = setFirstCurrentTimeOfDay;
            }
        }

        if (PlayerPrefs.GetString("CurrentSaveStateUsed") == "SaveStateThree")
        {
            if (PlayerPrefs.HasKey("SaveStateThreeTimer") == true)
            {
                GameObject.Find("Sun").GetComponent<Timer>().CurrentTimeOfDay = PlayerPrefs.GetFloat("SaveStateThreeTimer");
            }
            else
            {
                GameObject.Find("Sun").GetComponent<Timer>().CurrentTimeOfDay = setFirstCurrentTimeOfDay;
            }
        }
    }

    public bool GetIsTimerHaveToBeLoad
    {
        get { return _LoadTimer; }
        set { _LoadTimer = value; }
    }
}
