using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMonitoring : MonoBehaviour {

    public Font GetArialTextFont
    {
        get { return Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font; }
    }

    public void SetTextInCorrectLanguages(string gameObjectName, string englishText, string frenchText)
    {
        if (PlayerPrefs.GetString("CurrentLanguagesUsed") == "French" || PlayerPrefs.GetString("CurrentLanguagesUsed") == "Français")
        {
            GameObject.Find(gameObjectName).GetComponent<Text>().text = frenchText;
        }
        else if (PlayerPrefs.GetString("CurrentLanguagesUsed") == "English" || PlayerPrefs.GetString("CurrentLanguagesUsed") == "Anglais")
        {
            GameObject.Find(gameObjectName).GetComponent<Text>().text = englishText;
        }
    }
}
