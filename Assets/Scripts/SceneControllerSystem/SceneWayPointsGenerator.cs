using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneWayPointsGenerator : MonoBehaviour {

    private void Start()
    {
        generateWayPointsOnMap();
    }

    private void generateWayPointsOnMap()
    {
        if (PlayerPrefs.GetString("CurrentScene") == "LostTimeGearDistrict")
        {
            CreateWayPoints("LostTimeGearDistrictToAstridHouse", 16, 2.5f, 30);
        }
        else if (PlayerPrefs.GetString("CurrentScene") == "LostTimeAstridHouse")
        {
            CreateWayPoints("LostTimeAstridHouseToLostTimeGearDistrict", -2f, 2.5f, 5f);
        }
    }

    private void CreateWayPoints(string WayPointsName, float WayPointsPositionX, float WayPointsPositionY, float WayPointsPositionZ)
    {
        GameObject gameObject = new GameObject(WayPointsName + "WayPoints");
        gameObject.transform.position = new Vector3(WayPointsPositionX, WayPointsPositionY, WayPointsPositionZ);
        gameObject.AddComponent<BoxCollider>();
        gameObject.GetComponent<BoxCollider>().size = new Vector3(1f, 5f, 1f);
        gameObject.AddComponent<SceneController>();

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
