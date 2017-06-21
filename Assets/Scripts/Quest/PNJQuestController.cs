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


    // supprimer. l'idée c'est qu'il récupère ses questID via JSON
    // _current questID  recupre les infos du JSON

    public int QuestID;
    public string QuestPNJ;
    public string QuestTitle;
    public QuestController questController;

    private float currentQuestID;

    public float CurrentQuestID
    {
        get
        {
            return currentQuestID;
        }

        set
        {
            currentQuestID = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        string str = ReadJSON();

        //Debug.Log(str);

        JSONNode json = JSON.Parse(str);

        //2 boucles une sur les int ou sur les float
        // questid + i fonctionne
        //
        for(float i = 1; i < json["QuestMax"].AsInt; i += 0.1f)
        {
            if (CurrentQuestID == json["Quest1.1"][0]["QuestID"].AsFloat && this.transform.name == json["Quest1.1"][0]["QuestPNJ"].Value)
            {
               questController = new QuestController(json["Quest1.1"][0]["QuestPNJ"], json["Quest1.1"][0]["QuestID"].AsFloat, 
                json["Quest1.1"][0]["QuestName"], json["Quest1.1"][0]["QuestContext"], json["Quest1.1"][0]["QuestDescription"],
                json["Quest1.1"][0]["QuestIsComplete"].AsBool);
            }
        }
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
