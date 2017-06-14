using Assets.Scripts.Quest;
using Assets.Scripts.Quest.Interfaces;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    QuestLibrary _questLibrary;

	// Use this for initialization
	void Start () {
        QuestLibrary _questLibrary = new QuestLibrary();
	}
	
    /// <summary>
    /// Initialize a quest
    /// </summary>
    public void InitializeQuest(int questID)
    {
        // Initialize quest 
        // recois un id
        // recuperer quest
        // ajout à la questlibrary
        try
        {
            using (StreamReader reader = File.OpenText(@"..\..\QuestSystemTests\JsonParser\QuestTest.json"))
            {
                string jsonString = reader.ReadToEnd();
                var N = JSON.Parse(jsonString);

                QuestController QC = new QuestController(N["Quest"][0][questID]["QuestID"], N["Quest"][0][questID]["QuestName"].Value, N["Quest"][0][questID]["QuestDescription"].Value,N["Quest"][0][questID]["QuestIsComplete"]);
                _questLibrary.QuestList.Add(QC);
            }
        }
        catch { }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
