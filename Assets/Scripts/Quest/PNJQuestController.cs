using Assets.Scripts.Quest;
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

    public string CurrentPNJQuestContext { get; set; }

    public float CurrentQuestID { get; set; }
    private int PNJCurrentQuestID;
    private int currentObjectiveID;
    private bool _hasQuest;
    private string pnjName;

    //private string tmpFilePath = "./Resources/JSON/tmpFile";
    //private string sourcePath = "./Resources/JSON/QuestTest";

    private string tmpFilePath = "./Assets/Resources/JSON/tmpFile";
    private string sourcePath = "./Assets/Resources/JSON/QuestTest.json";

    QuestController questController;
    List<ObjectiveController> questObjectives;
    ObjectiveController _currentQuestObjectif;

    JSONNode QuestTest;
    JSONNode PNJ;

    public bool isQuestAccepted { get; set; }
    

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
                        /*switch (QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"].Value)
                        {
                            case "Collecte":
                                GameObject OC = new GameObject();
                                tmpIQuestObjective = new ObjectiveController(
                                QuestTest["Quest" + i][0]["Objectives"][count]["QuestID"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveName"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveDescription"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveIsComplete"], QuestTest["Quest" + i][0]["Objectives"][count]["QuestContext"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"], QuestTest["Quest" + i][0]["Objectives"][count]["ItemQuantity"]);
                                questObjectives.Add(tmpIQuestObjective);
                                OC.AddComponent<ObjectiveController>();
                                OC.GetComponent<ObjectiveController>().name = "QID" + QuestTest["Quest" + i][count]["QuestID"].AsFloat + "OID" + QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"].AsInt;
                                OC.GetComponent<ObjectiveController>().QuestID = tmpIQuestObjective.QuestID;
                                OC.GetComponent<ObjectiveController>().ObjectiveID = tmpIQuestObjective.ObjectiveID;
                                OC.GetComponent<ObjectiveController>().ObjectiveDescription = tmpIQuestObjective.ObjectiveDescription;
                                OC.GetComponent<ObjectiveController>().ObjectiveIsComplete = tmpIQuestObjective.ObjectiveIsComplete;
                                OC.GetComponent<ObjectiveController>().ObjectiveContext = tmpIQuestObjective.ObjectiveContext;
                                OC.GetComponent<ObjectiveController>().ObjectiveType = tmpIQuestObjective.ObjectiveType;
                                OC.GetComponent<ObjectiveController>().GoalAmount = tmpIQuestObjective.GoalAmount;

                                //Debug.Log(tmpIQuestObjective.QuestID);
                                //Debug.Log(tmpIQuestObjective.ObjectiveID);
                                //Debug.Log(tmpIQuestObjective.ObjectiveDescription);
                                //Debug.Log(tmpIQuestObjective.ObjectiveIsComplete);
                                //Debug.Log(tmpIQuestObjective.ObjectiveContext);
                                //Debug.Log(tmpIQuestObjective.ObjectiveType);
                                //Debug.Log(tmpIQuestObjective.GoalAmount);
                                GenerateObjectiveItem(QuestTest, i, tmpIQuestObjective.ObjectiveID);
                                break;
                            case "GoToZone":
                                GameObject OGTZ = new GameObject();
                                tmpIQuestObjective = new ObjectiveController(
                                QuestTest["Quest" + i][0]["Objectives"][count]["QuestID"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveName"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveDescription"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveIsComplete"], QuestTest["Quest" + i][0]["Objectives"][count]["QuestContext"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"], QuestTest["Quest" + i][0]["Objectives"][count]["PositionX"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["PositionY"], QuestTest["Quest" + i][0]["Objectives"][count]["PositionZ"]);
                                questObjectives.Add(tmpIQuestObjective);
                                OGTZ.AddComponent<ObjectiveController>();
                                OGTZ.GetComponent<ObjectiveController>().name = "QID" + QuestTest["Quest" + i][count]["QuestID"].AsFloat + "OID" + QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"].AsInt;
                                OGTZ.GetComponent<ObjectiveController>().QuestID = tmpIQuestObjective.QuestID;
                                OGTZ.GetComponent<ObjectiveController>().ObjectiveID = tmpIQuestObjective.ObjectiveID;
                                OGTZ.GetComponent<ObjectiveController>().ObjectiveDescription = tmpIQuestObjective.ObjectiveDescription;
                                OGTZ.GetComponent<ObjectiveController>().ObjectiveIsComplete = tmpIQuestObjective.ObjectiveIsComplete;
                                OGTZ.GetComponent<ObjectiveController>().ObjectiveContext = tmpIQuestObjective.ObjectiveContext;
                                OGTZ.GetComponent<ObjectiveController>().ObjectiveType = tmpIQuestObjective.ObjectiveType;
                                OGTZ.GetComponent<ObjectiveController>().TypeGoToZoneIsComplete = tmpIQuestObjective.TypeGoToZoneIsComplete;

                                Debug.Log(tmpIQuestObjective.QuestID);
                                Debug.Log(tmpIQuestObjective.ObjectiveID);
                                Debug.Log(tmpIQuestObjective.ObjectiveDescription);
                                Debug.Log(tmpIQuestObjective.ObjectiveIsComplete);
                                Debug.Log(tmpIQuestObjective.ObjectiveContext);
                                Debug.Log(tmpIQuestObjective.ObjectiveType);
                                Debug.Log(tmpIQuestObjective.TypeGoToZoneIsComplete);

                                GenerateZone(QuestTest, i, tmpIQuestObjective.QuestID, tmpIQuestObjective.ObjectiveID);
                                break;
                            case "TalkToPNJ":
                                AttributeObjectiveToAPNJ(i);
                                break;
                            default:
                                tmpIQuestObjective = new ObjectiveController(
                                QuestTest["Quest" + i][0]["Objectives"][count]["QuestID"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveName"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveDescription"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveIsComplete"], QuestTest["Quest" + i][0]["Objectives"][count]["QuestContext"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"]);
                                questObjectives.Add(tmpIQuestObjective);
                                break;
                        }*/

                        // changer les quest context en objective context
                        Debug.Log(QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"]);
                        Debug.Log(QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"].Value);

                        if (QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"] == "Collecte")
                        {
                            Debug.Log("Collect");
                            GameObject OC = new GameObject();
                            tmpIQuestObjective = new ObjectiveController(
                            QuestTest["Quest" + i][0]["Objectives"][count]["QuestID"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"],
                            QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveName"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveDescription"],
                            QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveIsComplete"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveContext"],
                            QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"], QuestTest["Quest" + i][0]["Objectives"][count]["ItemQuantity"]);
                            questObjectives.Add(tmpIQuestObjective);
                            OC.AddComponent<ObjectiveController>();
                            OC.GetComponent<ObjectiveController>().name = "QID" + QuestTest["Quest" + i][count]["QuestID"].AsFloat + "OID" + QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"].AsInt;
                            OC.GetComponent<ObjectiveController>().QuestID = tmpIQuestObjective.QuestID;
                            OC.GetComponent<ObjectiveController>().ObjectiveID = tmpIQuestObjective.ObjectiveID;
                            OC.GetComponent<ObjectiveController>().ObjectiveDescription = tmpIQuestObjective.ObjectiveDescription;
                            OC.GetComponent<ObjectiveController>().ObjectiveIsComplete = tmpIQuestObjective.ObjectiveIsComplete;
                            OC.GetComponent<ObjectiveController>().ObjectiveContext = tmpIQuestObjective.ObjectiveContext;
                            OC.GetComponent<ObjectiveController>().ObjectiveType = tmpIQuestObjective.ObjectiveType;
                            OC.GetComponent<ObjectiveController>().GoalAmount = tmpIQuestObjective.GoalAmount;

                            GenerateObjectiveItem(QuestTest, i, tmpIQuestObjective.ObjectiveID);
                            Debug.Log("generate");

                        }
                        else if(QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"] == "GoToZone")
                        {
                            Debug.Log("GoToZone");
                            GameObject OGTZ = new GameObject();
                            tmpIQuestObjective = new ObjectiveController(
                            QuestTest["Quest" + i][0]["Objectives"][count]["QuestID"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"],
                            QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveName"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveDescription"],
                            QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveIsComplete"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveContext"],
                            QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"], QuestTest["Quest" + i][0]["Objectives"][count]["PositionX"],
                            QuestTest["Quest" + i][0]["Objectives"][count]["PositionY"], QuestTest["Quest" + i][0]["Objectives"][count]["PositionZ"]);
                            questObjectives.Add(tmpIQuestObjective);
                            OGTZ.AddComponent<ObjectiveController>();
                            OGTZ.GetComponent<ObjectiveController>().name = "QID" + QuestTest["Quest" + i][count]["QuestID"].AsFloat + "OID" + QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"].AsInt;
                            OGTZ.GetComponent<ObjectiveController>().QuestID = tmpIQuestObjective.QuestID;
                            OGTZ.GetComponent<ObjectiveController>().ObjectiveID = tmpIQuestObjective.ObjectiveID;
                            OGTZ.GetComponent<ObjectiveController>().ObjectiveDescription = tmpIQuestObjective.ObjectiveDescription;
                            OGTZ.GetComponent<ObjectiveController>().ObjectiveIsComplete = tmpIQuestObjective.ObjectiveIsComplete;
                            OGTZ.GetComponent<ObjectiveController>().ObjectiveContext = tmpIQuestObjective.ObjectiveContext;
                            OGTZ.GetComponent<ObjectiveController>().ObjectiveType = tmpIQuestObjective.ObjectiveType;
                            OGTZ.GetComponent<ObjectiveController>().TypeGoToZoneIsComplete = tmpIQuestObjective.TypeGoToZoneIsComplete;

                            GenerateZone(QuestTest, i, tmpIQuestObjective.QuestID, tmpIQuestObjective.ObjectiveID);
                        }else if(QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"] == "TalkToPNJ")
                        {
                            Debug.Log("TalkToPNJ");
                            AttributeObjectiveToAPNJ(i);
                        }else
                        {
                            Debug.Log("Default");
                            tmpIQuestObjective = new ObjectiveController(
                                QuestTest["Quest" + i][0]["Objectives"][count]["QuestID"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveName"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveDescription"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveIsComplete"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveContext"],
                                QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"]);
                            questObjectives.Add(tmpIQuestObjective);
                        }
                        count++;
                    }
                }

                Debug.Log("QuestController");
                questController = new QuestController(QuestTest["Quest" + i][0]["QuestPNJ"], QuestTest["Quest" + i][0]["QuestID"].AsFloat,
                QuestTest["Quest" + i][0]["QuestName"], QuestTest["Quest" + i][0]["QuestContext"], QuestTest["Quest" + i][0]["QuestDescription"],
                QuestTest["Quest" + i][0]["QuestIsComplete"].AsBool, QuestTest["Quest" + i][0]["ObjectiveID"].AsInt, QuestTest["Quest" + i][0]["ObjectiveMax"].AsInt, questObjectives);

                Debug.Log(questController.QuestContext);
                CurrentPNJQuestContext = questController.QuestContext;
                Debug.Log(CurrentPNJQuestContext);
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
        if (collision.transform.name == "AstridPlayer")  
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
        if (collision.transform.name == "AstridPlayer")
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
        if (collision.transform.name == "AstridPlayer") 
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
        if (QuestTest["Quest" + CurrentQuestID][0]["QuestIsComplete"].AsBool == false)
        {
            int objID = 0;

            for (int i = 0; i <= questController.ObjectiveMax; i++)
            {
                if (questController.ObjectiveID == objID)
                {
                    if (this.GetComponent<PNJQuestController>().isQuestAccepted == true)
                    {
                        questController.ObjectiveID++;
                        this.GetComponent<PNJQuestController>().isQuestAccepted = false;

                        WriteAndDeleteJSONFile();
                    }
                }
                else
                {
                    int count = 0;
                    // switch par type
                    foreach (ObjectiveController objC in questObjectives)
                    {
                        if (objC.ObjectiveID == questController.ObjectiveID)
                        {
                            _currentQuestObjectif = objC;
                            Debug.Log(objC.ObjectiveContext);
                            CurrentPNJQuestContext = objC.ObjectiveContext;
                            if (this.GetComponent<PNJQuestController>().isQuestAccepted == true)
                            {
                                _currentQuestObjectif.ObjectiveIsComplete = true;
                                this.GetComponent<PNJQuestController>().isQuestAccepted = false;
                                questController.QuestDescription = "test";
                                QuestTest["Quest" + CurrentQuestID][0]["Objectives"][count]["ObjectiveIsComplete"].AsBool = true;
                            }
                        }
                        count++;
                    }
                    if (questController.ObjectiveID > questController.ObjectiveMax)
                    {
                        questController.QuestIsComplete = true;
                        _hasQuest = false;
                        QuestTest["Quest" + CurrentQuestID][0]["QuestIsComplete"].AsBool = true;
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
            CurrentPNJQuestContext = "Bonjour Astrind. Quelle belle journée aujourd'hui, n'est-ce-pas ?";
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
        if (QuestTest["Quest" + CurrentQuestID][0]["ObjectiveID"] != null)
        {
            QuestTest["Quest" + CurrentQuestID][0]["ObjectiveID"].AsInt = questController.ObjectiveID;

            Debug.Log(QuestTest["Quest" + CurrentQuestID][0]["ObjectiveID"].AsInt);
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
    private void GenerateObjectiveItem(JSONNode json, float id, int objectiveID)
    {
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
            gameobject.AddComponent<TypeCollectBehavior>();
            gameobject.GetComponent<TypeCollectBehavior>().QuestID = id;
            gameobject.GetComponent<TypeCollectBehavior>().ObjectiveID = objectiveID;
        }
    }

    private void AttributeObjectiveToAPNJ(float id)
    {
        //throw new NotImplementedException();
    }

    /// <summary>
    /// Generates the zone.
    /// </summary>
    /// <param name="id">The identifier.</param>
    private void GenerateZone(JSONNode json, float id, int questID, int objectiveID)
    {
        // Peut etre l'ecrire un peu differemment 
        GameObject gameobject = new GameObject("TypeGoToZone");
        gameobject.transform.position = new Vector3(
            QuestTest["Quest" + id][0]["Objectives"][0]["PositionX"].AsFloat,
            QuestTest["Quest" + id][0]["Objectives"][0]["PositionY"].AsFloat,
            QuestTest["Quest" + id][0]["Objectives"][0]["PositionZ"].AsFloat);
        gameobject.AddComponent<BoxCollider>();
        gameobject.AddComponent<Rigidbody>();
        gameobject.AddComponent<MeshFilter>();
        gameobject.AddComponent<MeshRenderer>();
        gameobject.AddComponent<TypeGoToZoneBehavior>();
        gameobject.GetComponent<TypeGoToZoneBehavior>().QuestID = questID;
        gameobject.GetComponent<TypeGoToZoneBehavior>().ObjectiveID = objectiveID;
    }
}
