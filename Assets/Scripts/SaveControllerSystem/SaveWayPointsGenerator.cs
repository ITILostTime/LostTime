using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveWayPointsGenerator : MonoBehaviour {


    // Script de Génération des Save Waypoints sur la map
    private void Start()
    {
        generateWayPointsOnMap();
    }

    private void generateWayPointsOnMap()
    {
        if (PlayerPrefs.GetString("CurrentScene") == "LostTimeGearDistrict")
        {
            CreateWayPoints("ChunkGardenSave", -16f, 3f, -51f);
            CreateWayPoints("ChunkSouthStreetSave", 15f, 3f, 54f);
            CreateWayPoints("ChunkMarketSave", 12.5f, 2f, -3f);
        }
        else if (PlayerPrefs.GetString("CurrentScene") == "LostTimeAstridHouse")
        {

        }
    }

    private void CreateWayPoints(string WayPointsName, float WayPointsPositionX, float WayPointsPositionY, float WayPointsPositionZ)
    {
        GameObject gameObject = new GameObject(WayPointsName + "WayPoints");
        gameObject.transform.position = new Vector3(WayPointsPositionX, WayPointsPositionY, WayPointsPositionZ);
        gameObject.AddComponent<BoxCollider>();
        gameObject.GetComponent<BoxCollider>().size = new Vector3(1f, 5f, 1f);
        gameObject.AddComponent<SaveWayPointsController>();

        GameObject gameObjectAnimation = new GameObject(WayPointsName + "GearAnimation");
        gameObjectAnimation.transform.SetParent(GameObject.Find(WayPointsName + "WayPoints").transform, true);
        gameObjectAnimation.transform.position = new Vector3(WayPointsPositionX, WayPointsPositionY, WayPointsPositionZ);
        gameObjectAnimation.AddComponent<SaveStateAnimation>();

        GameObject gameObjectGearSprite = new GameObject(WayPointsName + "GearSprite");
        gameObjectGearSprite.transform.tag = "SaveStateWayPointGearSprite";
        gameObjectGearSprite.transform.SetParent(GameObject.Find(WayPointsName + "GearAnimation").transform, true);
        gameObjectGearSprite.transform.position = new Vector3(WayPointsPositionX, WayPointsPositionY, WayPointsPositionZ);
        gameObjectGearSprite.AddComponent<SpriteRenderer>();
        gameObjectGearSprite.GetComponent<SpriteRenderer>().sprite = GameObject.Find("MenuCanvas").GetComponent<ImageMonitoring>().GetBlackGear;
        gameObjectGearSprite.AddComponent<SaveStateSpriteAnimation>();
    }
}
