using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using SimpleJSON;

public class InstanceLostTimeGearDistrictContext : MonoBehaviour
{
    private void Start()
    {
        GameObject Event = new GameObject("Event");
        Event.AddComponent<UICanvas>();

        GameObject Camera = new GameObject("Main Camera");
        Camera.transform.tag = "MainCamera";
        Camera.AddComponent<Camera>();
        Camera.AddComponent<GUILayer>();
        Camera.AddComponent<FlareLayer>();
        Camera.AddComponent<AudioListener>();
        Camera.AddComponent<CameraBehavior>();
        Camera.GetComponent<Camera>().depth = -1;

        GameObject Sun = new GameObject("Sun");
        Sun.transform.position = new Vector3(32, 33.15f, 13.3f);
        Sun.transform.Rotate(36.31f, -71.2f, 0);
        Sun.AddComponent<Light>();
        Sun.GetComponent<Light>().type = LightType.Directional;
        Sun.GetComponent<Light>().range = 14.68f;
        Sun.GetComponent<Light>().color = new Color(0.96f, 0.96f, 0.96f, 1f);
        Sun.GetComponent<Light>().intensity = 1.26f;
        Sun.GetComponent<Light>().bounceIntensity = 1;
        Sun.GetComponent<Light>().shadowStrength = 0.4f;
        Sun.GetComponent<Light>().shadowBias = 0.05f;
        Sun.GetComponent<Light>().shadowNormalBias = 0.4f;
        Sun.GetComponent<Light>().shadowNearPlane = 0.2f;
        //Sun.AddComponent<Timer>();
        //Sun.AddComponent<lightCtrl>();

        GameObject MapChunkSource = (GameObject)Instantiate(Resources.Load("MapEngrenage/map-chunk-source-v2"));
        GameObject.Find("map-chunk-source-v2(Clone)").name = "map-chunk-source";
        MapChunkSource.transform.position = new Vector3(0.1f, 0, 0);

        GameObject Guild = (GameObject)Instantiate(Resources.Load("Guild/Guild"));
        GameObject.Find("Guild(Clone)").name = "Guild";
        Guild.transform.position = new Vector3(10.3f, 0.92f, 0 - 43.69f);

        GameObject upperWall = (GameObject)Instantiate(Resources.Load("mur/upperwall"));
        GameObject.Find("upperwall(Clone)").name = "upperwall";
        upperWall.transform.position = new Vector3(0.6f, 0, 0);
        upperWall.AddComponent<BoxCollider>();
        upperWall.GetComponent<BoxCollider>().center = new Vector3(-22.04332f, 2.611115f, -10.5541f);
        upperWall.GetComponent<BoxCollider>().size = new Vector3(9.632912f, 14.21727f, 8.876455f);

        GameObject lowerWall = (GameObject)Instantiate(Resources.Load("mur/lowerwall"));
        GameObject.Find("lowerwall(Clone)").name = "lowerwall";
        lowerWall.transform.position = new Vector3(-0.34f, 3.87f, -0.8f);
        lowerWall.transform.localScale = new Vector3(1.01f, 1, 1.03f);

        BoxCollider BoxCollider01 = lowerWall.AddComponent<BoxCollider>();
        BoxCollider01.center = new Vector3(34.06925f, 3.257444f, 31.96719f);
        BoxCollider01.size = new Vector3(6.698563f, 15.50993f, 3.977598f);

        BoxCollider BoxCollider02 = lowerWall.AddComponent<BoxCollider>();
        BoxCollider02.center = new Vector3(35.33563f, 3.257444f, 35.55804f);
        BoxCollider02.size = new Vector3(4.165891f, 15.50993f, 3.41281f);

        BoxCollider BoxCollider03 = lowerWall.AddComponent<BoxCollider>();
        BoxCollider03.center = new Vector3(34.06925f, 3.257444f, 38.76731f);
        BoxCollider03.size = new Vector3(6.698563f, 6.698563f, 3.228249f);

        GameObject Mountains = (GameObject)Instantiate(Resources.Load("LostTimeGearDistrict/Mountains"));
        GameObject.Find("Mountains(Clone)").name = "Mountains";
        Mountains.transform.position = new Vector3(0, 0, 3.2f);
        Mountains.transform.localScale = new Vector3(1.33f, 1.12f, 1);
        GameObject.Find("east_moutain").transform.position = new Vector3(-7.1f, 15.2f, 61.8f);

        GameObject CloudLayer = (GameObject)Instantiate(Resources.Load("LostTimeGearDistrict/CloudLayer"));

        GameObject HouseDefault = (GameObject)Instantiate(Resources.Load("LostTimeGearDistrict/HouseDefaultFinalGroup"));

        GameObject StreetMisc = (GameObject)Instantiate(Resources.Load("LostTimeGearDistrict/StreetMisc"));

        GameObject Barrage = (GameObject)Instantiate(Resources.Load("LostTimeGearDistrict/Barrage"));

        GameObject Bridge = (GameObject)Instantiate(Resources.Load("LostTimeGearDistrict/Bridge"));

        GameObject lampadaire = (GameObject)Instantiate(Resources.Load("LostTimeGearDistrict/Lampadaire"));

        GameObject Waypoints = (GameObject)Instantiate(Resources.Load("LostTimeGearDistrict/WayPoints"));

        // if condition JsonScene == _currentScene (playerprefs)
        // Read PNJ.json
        string PNJ = ReadPNJJSON();
        JSONNode json = JSON.Parse(PNJ);

        for (int i = 0; i < json["PNJCount"].AsInt; i++)
        {
            GeneratePNJQuestGearDistrict(json["Scene"][0]["PNJ"][i]["PNJName"], json["Scene"][0]["PNJ"][i]["PositionX"].AsFloat,
            json["Scene"][0]["PNJ"][i]["PositionY"].AsFloat, json["Scene"][0]["PNJ"][i]["PositionZ"].AsFloat,
            json["Scene"][0]["PNJ"][i]["RotationX"].AsFloat, json["Scene"][0]["PNJ"][i]["RotationY"].AsFloat,
            json["Scene"][0]["PNJ"][i]["RotationZ"].AsFloat, json["Scene"][0]["PNJ"][i]["PNJCurrentQuestID"].AsFloat);
        }
    }

    /// <summary>
    /// Reads the pnjjson.
    /// </summary>
    /// <returns></returns>
    private string ReadPNJJSON()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/Scripts/Quest/JsonParser/PNJ.json");
        string content = sr.ReadToEnd();

        sr.Close();
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
        float rotationX, float rotationY, float rotationZ, float questID)
    {
        GameObject gameobject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject.Find("Cube").transform.name = name;
        gameobject.transform.position = new Vector3(positionX, positionY, positionZ);
        gameobject.AddComponent<MeshCollider>();
        gameobject.AddComponent<BoxCollider>();
        gameobject.AddComponent<Rigidbody>();
        gameobject.AddComponent<MeshFilter>();
        gameobject.AddComponent<PNJQuestController>();
        gameobject.GetComponent<PNJQuestController>().CurrentQuestID = questID;
    }
}
