using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Light sun; // Stock directionnal light
    public float secondsInFullDay = 120f; // durée d'un jour en secondes (mettre à 20 minutes)
    [Range(0, 1)] // permet d'intégrer un slider pour déplacer currentTimeOfDay de 0 à 1
    public float currentTimeOfDay = 0; // l'heure actuelle sur une echelle de 0 à 1

    [HideInInspector] // permet de cacher la variable dans l'inspecteur, on peut donc l'utiliser dans un autre script si besoin
    public float timeMutiplier = 1f; //variable permettant de faire avancer le temps
    public float sunInitialIntensity; // stocke valeur initial de l'intensité de notre soleil

    //Useless ? 
    bool gameFinish;
    string level;
    private static float wakeUpSun = 0.22f;

    void Start()
    {
        sunInitialIntensity = sun.intensity; //on dit que la var suninitialintensity est egale a l'intensiite de base de la directionnal light

        // Rajouté
        gameFinish = false;
        level = "LostTimeGearDistrict";
        // Fin rajout
    }

    void Update()
    {
        // Rajouté à l'instant de leur méthode
        Chrono();
        // FIn rajout

        //On va lancer une fonction UpdateSun qui va modifier le soleil
        UpdateSun(); //on lance en permanence la fonction Updatesun() qui nous permet de changer l'intensiter de la lumiere en fonction de l'heure

        //Le temps actuel va augmenter (mis en commentaire)
        //currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMutiplier; //permet de faire avancer le temps

        if (currentTimeOfDay > 0.57) // (currentTimeOfDay >= 1) la condition qui permet a la var currentTimeOffDay de toujours etre entre 0 et 1
        {
            GameObject.Find("Sun").GetComponent<SoundController>().GetSongOnOff = true;
            GameObject.Find("Sun").GetComponent<SoundController>().GetComponent<AudioSource>().volume = 0.2f;
            //currentTimeOfDay = 0;
        }
        //rajouté
        else
        {
            GameObject.Find("Sun").GetComponent<SoundController>().GetSongOnOff = false;
        }
    }


    public float CurrentTimeOfDay
    {
        get { return currentTimeOfDay; }
        set { currentTimeOfDay = value; }
    }


    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0); //Permet de faire tourner le soleil autour de la scène

        float intensityMultiplier = 1; // Var qui permet de modifier l'intensité de notre directionnal light

        //Permet de mettre l'intensité de nuit.
        /*if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) // Permet de regler l'intensité de la lumière entre 00h et 7h puis entre 19h et 00h (0.23f, 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if(currentTimeOfDay <= 0.25f) // permet de regler l'intensité et l'apparition du soleil le matin
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if(currentTimeOfDay >= 0.73f) // permet de regler l'intensite et la disparition du soleil le soir
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }*/

        sun.intensity = sunInitialIntensity * intensityMultiplier; // l'intensité du soleil est toujours égale à l'intensité initiale multiplié par la var intensityMultiplier.
    }


    /// <summary>
    /// Methode void rajouté également de leur classe de base
    /// </summary>
    void Chrono()
    {
        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = wakeUpSun;
            TimeUp();
        }
        else
        {
            if (!gameFinish)
            {
                currentTimeOfDay += ((Time.deltaTime / secondsInFullDay)) * timeMutiplier;
            }
        }
        UpdateSun();
    }

    /// <summary>
    /// Vient d'être rajouté pour essayer de compléter les trucs
    /// </summary>
    void TimeUp()
    {
        gameFinish = !gameFinish;
        GameObject.Find("Canvas").GetComponent<SaveController>().SaveCyclePlayer();

        // Recharge toute la scène => pas efficace
        SceneManager.LoadScene(level);
    }

}
