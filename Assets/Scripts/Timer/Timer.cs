using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public Light sun;
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
        sun = GameObject.Find("Sun").GetComponent<Light>();
        sunInitialIntensity = sun.intensity;
        jeuFini = false;
        GameObject.Find("Canvas").GetComponent<SaveController>().loadTimer();
        GameObject.Find("Sun").AddComponent<SoundController>();
        GameObject.Find("Sun").GetComponent<SoundController>().PlaySong(((AudioClip)(Resources.Load("Sound/Bruitages horloges - vieille - minuit - 12 coups"))), 2f, true);
        swapMalus = 0;
        level = "LostTimeGearDistrict";
        getSwapMalus();
    }

    void Update () {
        getSwapMalus();
        Chrono();     
        if(currentTimeOfDay > 0.57)
        {
            GameObject.Find("Sun").GetComponent<SoundController>().GetSongOnOff = true;
            GameObject.Find("Sun").GetComponent<SoundController>().GetComponent<AudioSource>().volume = 0.2f;
        }
        else
        {
            GameObject.Find("Sun").GetComponent<SoundController>().GetSongOnOff = false;
        }
	}

    void Chrono()
    {
        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = WAKE_UP_SUN;
            TimeUp();
        }
        else
        {
            if (!jeuFini)
            {
                currentTimeOfDay += ((Time.deltaTime / secondsInFullDay)) * timeMutiplier + swapMalus;
            }
        }
        updateSun();
    }

    public void updateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
        float intensityMultiplier = 1;

        sun.intensity = sunInitialIntensity * intensityMultiplier;
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

    float getSwapMalus()
    {
        return swapMalus = 0;
    }
}
