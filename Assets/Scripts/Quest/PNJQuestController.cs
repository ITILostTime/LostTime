﻿using Assets.Scripts.Quest;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SimpleJSON;
using System.IO;
using Assets.Scripts.Quest.Interfaces;
using Assets.Scripts.Quest.ObjectivesTypes;

public class PNJQuestController : MonoBehaviour
{

    /*
     * List QuestID par PNJ
     * Pnj recupère CurrentQuestID
     * Start charger sa currentquest
     * quand current quest is complete, il demande a quest manager de lui fournir la prochaine quete
     * */

    // supprimer. l'idée c'est qu'il récupère ses questID via JSON
    // _current questID  recupre les infos du JSON

    private string currentPNJQuestContext;

    private float currentQuestID;
    private int PNJCurrentQuestID;
    private int currentObjectiveID;
    private bool _hasQuest;
    private string pnjName;

    private string tmpFilePath = "./Resources/JSON/tmpFile";
    private string sourcePath = "./Resources/JSON/QuestTest";

    QuestController questController;
    List<ObjectiveController> questObjectives;
    ObjectiveController _currentQuestObjectif;

    JSONNode QuestTest;
    JSONNode PNJ;

    private bool isQuestAccepted;

    /// <summary>
    /// Gets or sets a value indicating whether this instance is quest accepted.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is quest accepted; otherwise, <c>false</c>.
    /// </value>
    public bool IsQuestAccepted
    {
        get { return isQuestAccepted; }
        set { isQuestAccepted = value; }
    }

    /// <summary>
    /// Gets or sets the current quest identifier.
    /// </summary>
    /// <value>
    /// The current quest identifier.
    /// </value>
    public float CurrentQuestID
    {
        get { return currentQuestID; }
        set { currentQuestID = value; }
    }

    /// <summary>
    /// Gets or sets the current PNJ quest context.
    /// </summary>
    /// <value>
    /// The current PNJ quest context.
    /// </value>
    public string CurrentPNJQuestContext
    {
        get { return currentPNJQuestContext; }
        set { currentPNJQuestContext = value; }
    }

    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start()
    {
        GameObject.Find(this.transform.name).AddComponent<UIDialogueSystem>();

        CheckNextQuest();
        GetQuestFromJson();
    }

    /// <summary>
    /// Gets the quest from json.
    /// </summary>
    private void GetQuestFromJson()
    {
        string str = ReadJSON("JSON/QuestTest");
        QuestTest = JSON.Parse(str);

        Debug.Log(QuestTest);

        //2 boucles une sur les int ou sur les float
        // quest + i fonctionne 
        //for(float x = 1; x<)
        for (float i = 1; i < QuestTest["QuestMax"].AsInt; i += 0.1f)
        {
            if (CurrentQuestID == QuestTest["Quest" + i][0]["QuestID"].AsFloat && this.transform.name == QuestTest["Quest" + i][0]["QuestPNJ"].Value)
            {
                questObjectives = new List<ObjectiveController>();
                ObjectiveController tmpIQuestObjective;
                int count = 0;

                for (int j = 1; j <= QuestTest["Quest" + i][0]["ObjectiveMax"].AsInt; j++)
                {
                    if (j == QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"])
                    {
                        tmpIQuestObjective = new ObjectiveController(
                            QuestTest["Quest" + i][0]["Objectives"][count]["QuestID"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"],
                            QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveName"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveDescription"],
                            QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveIsComplete"], QuestTest["Quest" + i][0]["Objectives"][count]["QuestContext"],
                            QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"]);

                        switch (QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"].Value)
                        {
                            case "Collecte":
                                tmpIQuestObjective = new ObjectiveController(
                                QuestTest["Quest" + i][0]["Objectives"][count]["QuestID"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveName"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveDescription"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveIsComplete"], QuestTest["Quest" + i][0]["Objectives"][count]["QuestContext"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"], QuestTest["Quest" + i][0]["Objectives"][count]["ItemQuantity"]);
                                GenerateObjectiveItem(QuestTest, i);
                                break;
                            case "GoToZone":
                                tmpIQuestObjective = new ObjectiveController(
                                QuestTest["Quest" + i][0]["Objectives"][count]["QuestID"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveName"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveDescription"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveIsComplete"], QuestTest["Quest" + i][0]["Objectives"][count]["QuestContext"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"], QuestTest["Quest" + i][0]["Objectives"][count]["PositionX"], 
                                QuestTest["Quest" + i][0]["Objectives"][count]["PositionY"], QuestTest["Quest" + i][0]["Objectives"][count]["PositionZ"]);
                                GenerateZone(i);
                                break;
                            case "TalkToPNJ":
                                AttributeObjectiveToAPNJ(i);
                                break;
                            default:
                                break;
                        }

                        questObjectives.Add(tmpIQuestObjective);
                        count++;



                    }
                }
                questController = new QuestController(QuestTest["Quest" + i][0]["QuestPNJ"], QuestTest["Quest" + i][0]["QuestID"].AsFloat,
                QuestTest["Quest" + i][0]["QuestName"], QuestTest["Quest" + i][0]["QuestContext"], QuestTest["Quest" + i][0]["QuestDescription"],
                QuestTest["Quest" + i][0]["QuestIsComplete"].AsBool, QuestTest["Quest" + i][0]["ObjectiveID"].AsInt, QuestTest["Quest" + i][0]["ObjectiveMax"].AsInt, questObjectives);

                currentPNJQuestContext = questController.QuestContext;
                _hasQuest = true;
            }

        }
    }

    /// <summary>
    /// Updates this instance.
    /// </summary>
    void Update()
    {
        if (_hasQuest == true)
        {
            QuestSystemComportement();
        }
    }

    /// <summary>
    /// Called when [collision enter].
    /// </summary>
    /// <param name="collision">The collision.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "AstridPlayer") // si le PNJ a une quête 
        {
            if (GameObject.Find("TalkButtonBackground") == false)
            {
                this.gameObject.GetComponent<UIDialogueSystem>().InteractWithPNJ(this.transform.name);
            }
        }
    }

    /// <summary>
    /// Called when [collision stay].
    /// </summary>
    /// <param name="collision">The collision.</param>
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.name == "AstridPlayer") // si le PNJ a une quête 
        {
            if (GameObject.Find("TalkButtonBackground") == false)
            {
                this.gameObject.GetComponent<UIDialogueSystem>().InteractWithPNJ(this.transform.name);
            }
        }
    }

    /// <summary>
    /// Called when [collision exit].
    /// </summary>
    /// <param name="collision">The collision.</param>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.name == "AstridPlayer") // si le PNJ a une quête 
        {
            if (GameObject.Find("TalkButtonBackground") == true)
            {
                Destroy(GameObject.Find("TalkButtonBackground"));
            }
            if (GameObject.Find("PanelPNJContextBackground") == true)
            {
                Destroy(GameObject.Find("PanelPNJContextBackground"));
            }
        }
    }

    /// <summary>
    /// Quests the system comportement.
    /// </summary>
    private void QuestSystemComportement()
    {
        if (QuestTest["Quest" + currentQuestID][0]["QuestIsComplete"].AsBool == false)
        {
            int objID = 0;

            for (int i = 0; i <= questController.ObjectiveMax; i++)
            {
                if (questController.ObjectiveID == objID)
                {
                    if (this.GetComponent<PNJQuestController>().IsQuestAccepted == true)
                    {
                        questController.ObjectiveID++;
                        this.GetComponent<PNJQuestController>().IsQuestAccepted = false;

                        WriteAndDeleteJSONFile();
                    }
                }
                else
                {
                    int count = 0;
                    foreach (ObjectiveController objC in questObjectives)
                    {
                        if (objC.ObjectiveID == questController.ObjectiveID)
                        {
                            _currentQuestObjectif = objC;
                            currentPNJQuestContext = objC.ObjectiveContext;
                            if (this.GetComponent<PNJQuestController>().IsQuestAccepted == true)
                            {
                                _currentQuestObjectif.ObjectiveIsComplete = true;
                                this.GetComponent<PNJQuestController>().IsQuestAccepted = false;
                                questController.QuestDescription = "test";
                                QuestTest["Quest" + currentQuestID][0]["Objectives"][count]["ObjectiveIsComplete"].AsBool = true;
                            }
                        }
                        count++;
                    }
                    if (questController.ObjectiveID > questController.ObjectiveMax)
                    {
                        questController.QuestIsComplete = true;
                        _hasQuest = false;
                        QuestTest["Quest" + currentQuestID][0]["QuestIsComplete"].AsBool = true;
                        WriteAndDeleteJSONFile();
                        CheckNextQuest();
                        GetQuestFromJson();
                        //fct de recherche quete suivante
                        //demander pnj.json sa prochaine quete
                        //demande quetes.json donne moi la quete de telle ID
                    }
                    else if (_currentQuestObjectif.ObjectiveIsComplete == true)
                    {
                        questController.ObjectiveID++;
                        WriteAndDeleteJSONFile();
                    }
                }
            }
        }
        else
        {
            currentPNJQuestContext = "Bonjour Astrind. Quelle belle journée aujourd'hui, n'est-ce-pas ?";
        }

    }

    /// <summary>
    /// Writes the and delete json file.
    /// </summary>
    private void WriteAndDeleteJSONFile()
    {
        //Doesn't work correctly
        // stocke correctement l'information dans le JSON 
        // A la fin je devrai pouvoir lire le context d'un pnj que ce soit pour la quete ou pour les objectifs
        if (QuestTest["Quest" + currentQuestID][0]["ObjectiveID"] != null)
        {
            QuestTest["Quest" + currentQuestID][0]["ObjectiveID"].AsInt = questController.ObjectiveID;

            Debug.Log(QuestTest["Quest" + currentQuestID][0]["ObjectiveID"].AsInt);
            Debug.Log(questController.ObjectiveID);
            Debug.Log(QuestTest);
            var s = QuestTest.ToString();

            FileStream fs = null;
            try
            {
                // Create file tmpFile
                if (!System.IO.Directory.Exists(tmpFilePath))
                {
                    System.IO.Directory.CreateDirectory(tmpFilePath);
                }

                // Copy old file .json in tmpFile
                System.IO.File.Copy(sourcePath, tmpFilePath + "QuestTest");

                // create
                fs = new FileStream(sourcePath, FileMode.Create);
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine(s);
                }
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }
            //delete old file 
            System.IO.File.Delete(tmpFilePath + "QuestTest");
        }
    }

    /// <summary>
    /// Checks the next quest.
    /// </summary>
    private void CheckNextQuest()
    {
        string str = ReadJSON("JSON/PNJ");
        PNJ = JSON.Parse(str);

        Debug.Log(PNJ);

        for (int i = 0; i <= PNJ["PNJCount"]; i++)
        {
            if (transform.name == PNJ["Scene"][0]["PNJ"][i]["PNJName"]) // comparer si on est dans la bonne scène aussi
            {
                PNJCurrentQuestID = PNJ["Scene"][0]["PNJ"][i]["PNJCurrentQuestID"];

                for (int j = 0; j < PNJ["Scene"][0]["PNJ"][i]["PNJQuestIDMax"]; j++)
                {
                    if (j == PNJ["Scene"][0]["PNJ"][i]["PNJCurrentQuestID"])
                    {
                        CurrentQuestID = PNJ["Scene"][0]["PNJ"][i]["ListQuestID"][0]["QuestID" + j].AsFloat;
                    }
                }
            }
        }
        //vérifier si on est dans la bonne scene 
    }

    /// <summary>
    /// Reads the json.
    /// </summary>
    /// <param name="JSONPath">The json path.</param>
    /// <returns></returns>
    private string ReadJSON(string JSONPath)
    {
        TextAsset file = Resources.Load(JSONPath) as TextAsset;
        string content = file.ToString();
        return content;
    }

    /// <summary>
    /// Generates the objective item.
    /// </summary>
    /// <param name="json">The json.</param>
    private void GenerateObjectiveItem(JSONNode json, float id)
    {
        GameObject typeCollect = new GameObject("TypeCollectController");
        typeCollect.AddComponent<TypeCollect>();
        typeCollect.GetComponent<TypeCollect>().GoalAmount = QuestTest["Quest" + id][0]["Objectives"][0]["ItemQuantity"].AsInt;

        for (int i = 0; i < QuestTest["Quest" + id][0]["Objectives"][0]["ItemQuantity"].AsInt; i++)
        {
            GameObject gameobject = new GameObject(QuestTest["Quest" + id][0]["Objectives"][0]["ObjectiveItems"][i]["ItemName"].Value);
            gameobject.transform.position = new Vector3(
                QuestTest["Quest" + id][0]["Objectives"][0]["ObjectiveItems"][0]["PositionX"].AsFloat,
                QuestTest["Quest" + id][0]["Objectives"][0]["ObjectiveItems"][0]["PositionY"].AsFloat,
                QuestTest["Quest" + id][0]["Objectives"][0]["ObjectiveItems"][0]["PositionZ"].AsFloat);
            gameobject.AddComponent<BoxCollider>();
            gameobject.AddComponent<Rigidbody>();
            gameobject.AddComponent<MeshFilter>();
            gameobject.AddComponent<MeshRenderer>();
            gameobject.AddComponent<TypeCollectBehaviour>();
        }
    }

    private void AttributeObjectiveToAPNJ(float id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Generates the zone.
    /// </summary>
    /// <param name="id">The identifier.</param>
    private void GenerateZone(float id)
    {
        // Peut etre l'ecrire un peu differemment 
        GameObject gameobject = new GameObject("TypeGoToZone");
        gameobject.transform.position = new Vector3(
            QuestTest["Quest" + id][0]["Objectives"][0]["PositionX"].AsFloat,
            QuestTest["Quest" + id][0]["Objectives"][0]["PositionY"].AsFloat,
            QuestTest["Quest" + id][0]["Objectives"][0]["PositionZ"].AsFloat);
        gameobject.AddComponent<BoxCollider>();
        gameobject.AddComponent<Rigidbody>();
        gameobject.AddComponent<MeshCollider>();
        gameobject.AddComponent<MeshFilter>();
        gameobject.AddComponent<MeshRenderer>();
        gameobject.AddComponent<TypeGoToZone>();
        gameobject.GetComponent<TypeGoToZone>().TypeGoToZoneIsComplete = true;
    }
}
