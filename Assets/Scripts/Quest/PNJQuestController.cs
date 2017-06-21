using Assets.Scripts.Quest;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SimpleJSON;
using System.IO;

public class PNJQuestController : MonoBehaviour {

    /*
     * List QuestID par PNJ
     * Pnj recupère CurrentQuestID
     * Start charger sa currentquest
     * quand current quest is complete, il demande a quest manager de lui fournir la prochaine quete
     * */
     

    // supprimer. l'idée c'est qu'il récupère ses questID via BD
    // _current questID  recupre les infos ds la BD


    // Use this for initialization
    void Start ()
    {
        string str = ReadJSON();

        Debug.Log(str);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private string ReadJSON()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/Scripts/Quest/JsonParser/QuestTest.json");
        string content = sr.ReadToEnd();
        sr.Close();

        return content;
    }
}
