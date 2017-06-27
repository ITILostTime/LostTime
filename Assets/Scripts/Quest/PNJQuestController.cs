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

    private string currentPNJQuestContext;

    private float currentQuestID;
    private int PNJCurrentQuestID;
    private int currentObjectiveID;
    private bool _hasQuest;
    private string pnjName;

    private string tmpFilePath = "./Assets/Scripts/Quest/JsonParser/tmpFile";
    private string sourcePath = "./Assets/Scripts/Quest/JsonParser/QuestTest.json";

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
    void Start ()
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
        string str = ReadJSON("/Scripts/Quest/JsonParser/QuestTest.json");
        QuestTest = JSON.Parse(str);

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
                            QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveName"],
                            QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveDescription"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveIsComplete"],
                            QuestTest["Quest" + i][0]["Objectives"][count]["QuestContext"]);

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
    void Update ()
    {
        if(_hasQuest == true)
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
        }
    }

    /// <summary>
    /// Quests the system comportement.
    /// </summary>
    private void QuestSystemComportement()
    {
        int objID = 0;
        
        for(int i = 0; i <= questController.ObjectiveMax; i++)
        {
            if(questController.ObjectiveID == objID)
            {
                if(this.GetComponent<PNJQuestController>().IsQuestAccepted == true)
                {
                    questController.ObjectiveID++;
                    this.GetComponent<PNJQuestController>().IsQuestAccepted = false;

                    WriteAndDeleteJSONFile();
                }
            }
            else
            { 
                foreach(ObjectiveController objC in questObjectives)
                {
                    if(objC.ObjectiveID == questController.ObjectiveID)
                    {
                        _currentQuestObjectif = objC;
                        currentPNJQuestContext = objC.ObjectiveContext;
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
                _hasQuest = false;
                CheckNextQuest();
                GetQuestFromJson();
                //fct de recherche quete suivante
                //demander pnj.json sa prochaine quete
                //demande quetes.json donne moi la quete de telle ID
            }
        }
    }

    private void WriteAndDeleteJSONFile()
    {
        //Doesn't work correctly
        // change quest1.1 to dynamic quest
        if (QuestTest["Quest1.1"][0]["ObjectiveID"] != null)
        {
            QuestTest["Quest1.1"][0]["ObjectiveID"].AsInt = questController.ObjectiveID + 1;

            Debug.Log(QuestTest["Quest1.1"][0]["ObjectiveID"].AsInt);
            Debug.Log(questController.ObjectiveID);
            Debug.Log(QuestTest);
            var s = QuestTest.ToString();

            FileStream fs = null;
            try
            {
                // créer dossier tmpFile
                if (!System.IO.Directory.Exists(tmpFilePath))
                {
                    System.IO.Directory.CreateDirectory(tmpFilePath);
                }

                // copier old file .json in tmpFile
                System.IO.File.Copy(sourcePath, tmpFilePath + "QuestTest");

                fs = new FileStream(sourcePath, FileMode.Create);
                Debug.Log(fs);
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

            Debug.Log(s);

            //delete old file 
            System.IO.File.Delete(tmpFilePath + "QuestTest");

            //Debug.Log(questController.ObjectiveID);
            //Debug.Log("Enter in write JSON");
        }
    }

    /// <summary>
    /// Checks the next quest.
    /// </summary>
    private void CheckNextQuest()
    {
        string str = ReadJSON("/Scripts/Quest/JsonParser/PNJ.json");

        PNJ = JSON.Parse(str);

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
        StreamReader sr = new StreamReader(Application.dataPath + JSONPath);
        string content = sr.ReadToEnd();
        sr.Close();

        return content;
    }
}
