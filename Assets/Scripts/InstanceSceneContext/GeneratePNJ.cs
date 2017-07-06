using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using System.IO;
using SimpleJSON;

public class GeneratePNJ : MonoBehaviour {

    private void Start()
    {
        GeneratePNJOnMap();
    }

    /// <summary>
    /// Generates the PNJ on map.
    /// </summary>
    private void GeneratePNJOnMap()
    {
        string PNJ = ReadPNJJSON("JSON/PNJ");
        JSONNode json = JSON.Parse(PNJ);

        for(int j = 0; j < json["SceneMax"].AsInt; j++)
        {
            if(json["Scene"][j]["SceneName"] == PlayerPrefs.GetString("CurrentScene"))
            {
                for (int i = 0; i < json["PNJCount"].AsInt; i++)
                {
                    if(json["Scene"][0]["PNJ"][i]["PNJCurrentQuestID"].AsInt > 0)
                    {
                        GeneratePNJQuestGearDistrict(json["Scene"][0]["PNJ"][i]["PNJName"], json["Scene"][0]["PNJ"][i]["PositionX"].AsFloat,
                        json["Scene"][0]["PNJ"][i]["PositionY"].AsFloat, json["Scene"][0]["PNJ"][i]["PositionZ"].AsFloat,
                        json["Scene"][0]["PNJ"][i]["RotationX"].AsFloat, json["Scene"][0]["PNJ"][i]["RotationY"].AsFloat,
                        json["Scene"][0]["PNJ"][i]["RotationZ"].AsFloat, json["Scene"][0]["PNJ"][i]["PNJCurrentQuestID"].AsFloat, json["Scene"][0]["PNJ"][i]["PNJJob"]);
                    }else
                    {
                        GenerateAllPNJGearDistrict(json["Scene"][0]["PNJ"][i]["PNJName"], json["Scene"][0]["PNJ"][i]["PositionX"].AsFloat,
                        json["Scene"][0]["PNJ"][i]["PositionY"].AsFloat, json["Scene"][0]["PNJ"][i]["PositionZ"].AsFloat,
                        json["Scene"][0]["PNJ"][i]["RotationX"].AsFloat, json["Scene"][0]["PNJ"][i]["RotationY"].AsFloat,
                        json["Scene"][0]["PNJ"][i]["RotationZ"].AsFloat, json["Scene"][0]["PNJ"][i]["PNJJob"]);
                    }

                    
                }
            }
        }
        
    }

    private void GenerateAllPNJGearDistrict(string name, float positionX, float positionY, float positionZ,
        float rotationX, float rotationY, float rotationZ, string job)
    {

        GameObject gameobject = (GameObject)Instantiate(Resources.Load("CharacterLowPo/PNJ"));
        GameObject.Find("PNJ(Clone)").transform.name = name;
        gameobject.transform.GetChild(0).transform.name = name + "body";
        gameobject.AddComponent<MeshRenderer>();
        gameobject.GetComponent<CapsuleCollider>().radius = 2;
        gameobject.GetComponent<CapsuleCollider>().height = 4;
        gameobject.GetComponent<CapsuleCollider>().isTrigger = true;
        gameobject.transform.position = new Vector3(positionX, positionY, positionZ);
        GameObject.Find(name + "body").GetComponent<SkinnedMeshRenderer>().material = SetSkin(job);
        gameobject.AddComponent<Rigidbody>();
        gameobject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        gameobject.AddComponent<CharaAnimCtrl>();
        gameobject.GetComponent<CharaAnimCtrl>().walkmode = WalkMode.walking;
        gameobject.AddComponent<NavMeshAgent>();
        gameobject.GetComponent<NavMeshAgent>().radius = 1;
        gameobject.GetComponent<NavMeshAgent>().height = 3.5f;
        gameobject.GetComponent<NavMeshAgent>().speed = 3f;
        gameobject.AddComponent<PNJPathfinding>();
    }

    /// <summary>
    /// Reads the pnjjson.
    /// </summary>
    /// <returns></returns>
    private string ReadPNJJSON(string JSONPath)
    {
        TextAsset file = Resources.Load(JSONPath) as TextAsset;
        string content = file.ToString();
        return content;
    }

    /// <summary>
    /// Generates the PNJ quest gear district.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="positionX">The position x.</param>
    /// <param name="positionY">The position y.</param>
    /// <param name="positionZ">The position z.</param>
    /// <param name="rotationX">The rotation x.</param>
    /// <param name="rotationY">The rotation y.</param>
    /// <param name="rotationZ">The rotation z.</param>
    /// <param name="questID">The quest identifier.</param>
    private void GeneratePNJQuestGearDistrict(string name, float positionX, float positionY, float positionZ,
        float rotationX, float rotationY, float rotationZ, float questID, string job)
    {

        GameObject gameobject = (GameObject)Instantiate(Resources.Load("CharacterLowPo/PNJ"));
        GameObject.Find("PNJ(Clone)").transform.name = name;
        gameobject.transform.GetChild(0).transform.name = name + "body";
        gameobject.AddComponent<MeshRenderer>();
        gameobject.GetComponent<CapsuleCollider>().radius = 2;
        gameobject.GetComponent<CapsuleCollider>().height = 4;
        gameobject.GetComponent<CapsuleCollider>().isTrigger = true;
        gameobject.transform.position = new Vector3(positionX, positionY, positionZ);
        GameObject.Find(name + "body").GetComponent<SkinnedMeshRenderer>().material = SetSkin(job);
        gameobject.AddComponent<Rigidbody>();
        gameobject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        gameobject.AddComponent<PNJQuestController>();
        gameobject.GetComponent<PNJQuestController>().CurrentQuestID = questID;
        gameobject.AddComponent<CharaAnimCtrl>();
        gameobject.GetComponent<CharaAnimCtrl>().walkmode = WalkMode.walking;
        gameobject.AddComponent<NavMeshAgent>();
        gameobject.GetComponent<NavMeshAgent>().radius = 1;
    }

    /// <summary>
    /// Generates the PNJ gear district.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="positionX">The position x.</param>
    /// <param name="positionY">The position y.</param>
    /// <param name="positionZ">The position z.</param>
    /// <param name="rotationX">The rotation x.</param>
    /// <param name="rotationY">The rotation y.</param>
    /// <param name="rotationZ">The rotation z.</param>
    /// <param name="job">The job.</param>
    public void GeneratePNJGearDistrict(string name, float positionX, float positionY, float positionZ, 
        float rotationX, float rotationY, float rotationZ, string job)
    {
        GameObject generatePNJ = (GameObject)Instantiate(Resources.Load("CharacterLowPo/PNJ"));
        GameObject.Find("PNJ(Clone)").transform.name = name;
        generatePNJ.transform.GetChild(0).transform.name = name + "body";
        generatePNJ.AddComponent<MeshRenderer>();
        generatePNJ.GetComponent<CapsuleCollider>().radius = 2;
        generatePNJ.GetComponent<CapsuleCollider>().height = 4;
        generatePNJ.transform.position = new Vector3(positionX, positionY, positionZ);
        GameObject.Find(name + "body").GetComponent<SkinnedMeshRenderer>().material = SetSkin(job);
        generatePNJ.AddComponent<Rigidbody>();
        generatePNJ.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        generatePNJ.AddComponent<CharaAnimCtrl>();
        generatePNJ.GetComponent<CharaAnimCtrl>().walkmode = WalkMode.walking;
        //generatePNJ.AddComponent<PNJPathfinding>();
    }

    /// <summary>
    /// Sets the skin.
    /// </summary>
    /// <param name="job">The job.</param>
    /// <returns></returns>
    private Material SetSkin(string job)
    {
        Material returned = (Material)Resources.Load("CharacterLowPo/Materials/citizen1");
        string craft = string.Format("CharacterLowPo/Materials/{0}", job);
        returned = (Material)Resources.Load(craft);
        if (returned == null)
        {
            Debug.Log(string.Format("Texture .{0}. does not exist, use default instead", job));
            returned = (Material)Resources.Load("CharacterLowPo/Materials/citizen1");
        }
        return returned;
    }
}
