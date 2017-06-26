using Assets.Scripts.Quest;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SimpleJSON;
using System.IO;
using Assets.Scripts.Quest.Interfaces;

public class PNJQuestController : MonoBehaviour {

    /*
     * List QuestID par PNJ
     * Pnj recupère CurrentQuestID
     * Start charger sa currentquest
     * quand current quest is complete, il demande a quest manager de lui fournir la prochaine quete
     * */


    // supprimer. l'idée c'est qu'il récupère ses questID via JSON
    // _current questID  recupre les infos du JSON

    
    QuestController questController;
    List<ObjectiveController> questObjectives;
    ObjectiveController _currentQuestObjectif;

    private float currentQuestID;
    private int PNJCurrentQuestID;
    private int currentObjectiveID;

    public float CurrentQuestID
    {
        get { return currentQuestID; }
        set { currentQuestID = value; }
    }
    
    void Start ()
    {
        CheckNextQuest();
        string str = ReadJSON("/Scripts/Quest/JsonParser/QuestTest.json");
        JSONNode json = JSON.Parse(str);

        //2 boucles une sur les int ou sur les float
        // quest + i fonctionne 
        for (float i = 1; i < json["QuestMax"].AsInt; i += 0.1f)
        {
            if (CurrentQuestID == json["Quest" + i][0]["QuestID"].AsFloat && this.transform.name == json["Quest" + i][0]["QuestPNJ"].Value)
            {
                questObjectives = new List<ObjectiveController>();
                ObjectiveController tmpIQuestObjective;
                int count = 0;

                Debug.Log(json["Quest" + i][0]["ObjectiveMax"]);
                for(int j = 1; j <= json["Quest" + i][0]["ObjectiveMax"].AsInt; j++)
                {   
                    if(j == json["Quest" + i][0]["Objectives"][count]["ObjectiveID"])
                    {
                        tmpIQuestObjective = new ObjectiveController(
                            json["Quest" + i][0]["Objectives"][count]["ObjectiveID"], json["Quest" + i][0]["Objectives"][count]["ObjectiveName"],
                            json["Quest" + i][0]["Objectives"][count]["ObjectiveDescription"], json["Quest" + i][0]["Objectives"][count]["ObjectiveIsComplete"],
                            json["Quest" + i][0]["Objectives"][count]["QuestContext"]);

                        questObjectives.Add(tmpIQuestObjective);
                        count++;
                    }
                }
                questController = new QuestController(json["Quest" + i][0]["QuestPNJ"], json["Quest" + i][0]["QuestID"].AsFloat,
                json["Quest" + i][0]["QuestName"], json["Quest" + i][0]["QuestContext"], json["Quest" + i][0]["QuestDescription"],
                json["Quest" + i][0]["QuestIsComplete"].AsBool, json["Quest" + i][0]["ObjectiveID"].AsInt, json["Quest" + i][0]["ObjectiveMax"].AsInt, questObjectives);       
            }
        }
    }

    void Update ()
    {
        //QuestSystemComportement();
    }

    private void QuestSystemComportement()
    {
        int objID = 0;

        for(int i = 0; i <= questController.ObjectiveMax; i++)
        {
            if(questController.ObjectiveID == objID)
            {
                Debug.Log(questController.QuestContext);
                questController.ObjectiveID++;
            }
            else
            { 
                foreach(ObjectiveController objC in questObjectives)
                {
                    if(objC.ObjectiveID == questController.ObjectiveID)
                    {
                        _currentQuestObjectif = objC;
                        Debug.Log(_currentQuestObjectif.ObjectiveContext);
                        _currentQuestObjectif.ObjectiveIsComplete = true;
                    }
                }

                if(_currentQuestObjectif.ObjectiveIsComplete == true)
                {
                    questController.ObjectiveID++;
                }
            } 

            if(questController.ObjectiveID > questController.ObjectiveMax)
            {
                questController.QuestIsComplete = true;
                CheckNextQuest();
                //fct de recherche quete suivante
                //demander pnj.json sa prochaine quete
                // demande quetes.json donne moi la quete de telle ID
            }
        }
    }

    private void CheckNextQuest()
    {
        string str = ReadJSON("/Scripts/Quest/JsonParser/PNJ.json");

        JSONNode json = JSON.Parse(str);

        //Debug.Log(json);

        for (int i = 0; i <= json["PNJCount"]; i++)
        {
            if (transform.name == json["Scene"][0]["PNJ"][i]["PNJName"]) // comparer si on est dans la bonne scène aussi
            {
                PNJCurrentQuestID = json["Scene"][0]["PNJ"][i]["PNJCurrentQuestID"];
                Debug.Log("PNJCurrentQuestID " + PNJCurrentQuestID);

                for (int j = 0; j < json["Scene"][0]["PNJ"][i]["PNJQuestIDMax"]; j++)
                {
                    if (j == json["Scene"][0]["PNJ"][i]["PNJCurrentQuestID"])
                    {
                        CurrentQuestID = json["Scene"][0]["PNJ"][i]["ListQuestID"][0]["QuestID" + j].AsFloat;
                    }

                }
                Debug.Log("CurrentQuestID "+ CurrentQuestID);
            }
        }

        
        //vérifier si on est dans la bonne scene 
    }

    private string ReadJSON(string JSONPath)
    {
        StreamReader sr = new StreamReader(Application.dataPath + JSONPath);
        string content = sr.ReadToEnd();
        sr.Close();

        return content;
    }
}
