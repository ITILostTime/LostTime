using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SimpleJSON;
using System.IO;

public class InitQuestTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        Debug.Log("Test success");

 //       if (Input.GetKeyDown("Fire1"))
 //       {
 //           try
 //           {
 //               using (StreamReader reader = File.OpenText(@"Assets/Scripts/Quest/JsonParser/QuestTest.json"))
 //               {
 //                   string jsonString = reader.ReadToEnd();
 //                   var N = JSON.Parse(jsonString);

 //                   QuestManager QM = new QuestManager();
 //                   QM.InitializeQuest(1);
 //               }
 //           }
 //           catch(Exception e)
 //           {
 //               Debug.Log(e);
 //           }
 //       }s
	}


}
