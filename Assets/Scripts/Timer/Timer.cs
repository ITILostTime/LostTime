using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    
    private static float WAKE_UP_SUN = 0.22f;
    public float secondsInFullDay = 120f;
    [Range(0,1)]
    public float currentTimeOfDay;
    public float timeMutiplier = 1f;
    public float sunInitialIntensity = 1f;
    bool jeuFini;
    float swapMalus;
    string level;

    public float CurrentTimeOfDay
    {
        get { return currentTimeOfDay; }
        set { currentTimeOfDay = value; }
    }

    void Start () {
        sunInitialIntensity = this.GetComponent<Light>().intensity;
        jeuFini = false;
        swapMalus = 0;
        level = "LostTimeGearDistrict";
        GetSwapMalus();
    }

    void Update () {
        GetSwapMalus();
        Chrono();     
        if(currentTimeOfDay > 0.57)
        {
            this.gameObject.GetComponent<SoundController>().PlaySong(((AudioClip)(Resources.Load("Sound/Bruitages horloges - vieille - minuit - 12 coups"))), PlayerPrefs.GetFloat("SoundLevel"), true);
            this.gameObject.GetComponent<SoundController>().GetSongOnOff = true;
            this.gameObject.GetComponent<SoundController>().GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SoundLevel");
        }
        else
        {
            this.gameObject.GetComponent<SoundController>().GetSongOnOff = false;
        }
	}

    void Chrono()
    {
        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = WAKE_UP_SUN;
            //TimeUp();
        }
        else
        {
            if (!jeuFini)
            {
                currentTimeOfDay += ((Time.deltaTime / secondsInFullDay)) * timeMutiplier + swapMalus;
            }
        }
        UpdateSun();
    }

    public void UpdateSun()
    {
        this.GetComponent<Light>().transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
        float intensityMultiplier = 1;

        this.GetComponent<Light>().intensity = sunInitialIntensity * intensityMultiplier;
    }

    void TimeUp()
    {
        jeuFini = !jeuFini;
        GameObject.Find("Canvas").GetComponent<SaveController>().SaveCyclePlayer();
        // sauvergarder inventaire
        //afficher texture GAMEOVER
        // WAIT 2s
         SceneManager.LoadScene(level);  
    }

    float GetSwapMalus()
    {
        return swapMalus = 0;
    }
}
