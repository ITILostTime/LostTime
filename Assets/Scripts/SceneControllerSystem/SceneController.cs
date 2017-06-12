using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

    private GameObject _canvas;

    private Vector3 AstridLostTimeHouseWayPointsPosition;
    private Vector3 AstridLostTimeHouseWayPointsRotation;

    private Vector3 AstridLostTimeGearDistrictWayPointsPosition;
    private Vector3 AstridLostTimeGearDistrictWayPointsRotation;
    private bool _isCollisionTrue;

    // Use this for initialization
    void Start ()
    {
        _canvas = GameObject.Find("MenuCanvas");

        //if (PlayerPrefs.GetString("CurrentScene") == "LostTimeGearDistrict")
        //{
        //    CreateLostTimeGearDistrictSceneWayPoints();
        //}
        //if (PlayerPrefs.GetString("CurrentScene") == "LostTimeAstridHouse")
        //{
        //    CreateAstridHouseLoadSceneWaypoints();
        //}
    }

    private void Update()
    {
        
    }
    private void CreateAstridHouseLoadSceneWaypoints()
    {
        GameObject AHtoLGD = new GameObject("AstridHouseToLostTimeGearDistrict");
        AHtoLGD.transform.position = new Vector3(-2, 3, 6);
        AHtoLGD.transform.localScale = new Vector3(2.7f, 6, 0.17f);
        AHtoLGD.AddComponent<BoxCollider>();
        AHtoLGD.GetComponent<BoxCollider>().size = new Vector3(1, 1, 12);
    }

    private void CreateLostTimeGearDistrictSceneWayPoints()
    { 
}


    private void CreateWayPoints(string GameObjectName, float PosX, float PosY, float PosZ, float AstridNewPosX, float AstridNewPosY, float AstridNewPosZ, 
        float AstridNewRotationX, float AstridNewRotationY, float AstridNewRotationZ)
    {

        if (GameObject.Find(GameObjectName) == false)
        {
            GameObject gameObject = new GameObject(GameObjectName);
            gameObject.transform.position = new Vector3(PosX, PosY, PosZ);
            gameObject.AddComponent<BoxCollider>();
            gameObject.GetComponent<BoxCollider>().size = new Vector3(1f, 5f, 1f);
            gameObject.AddComponent<CreateLoadSceneWayPoints>();

            GameObject gameObjectAnimation = new GameObject(GameObjectName + "GearAnimation");
            gameObjectAnimation.transform.SetParent(GameObject.Find(GameObjectName).transform, true);
            gameObjectAnimation.transform.position = new Vector3(PosX, PosY, PosZ);
            gameObjectAnimation.AddComponent<SaveStateAnimation>();

            GameObject gameObjectGearSprite = new GameObject(GameObjectName + "GearSprite");
            gameObjectGearSprite.transform.tag = "SaveStateWayPointGearSprite";
            gameObjectGearSprite.transform.SetParent(GameObject.Find(GameObjectName + "GearAnimation").transform, true);
            gameObjectGearSprite.transform.position = new Vector3(PosX, PosY, PosZ);
            gameObjectGearSprite.AddComponent<Image>();
            gameObjectGearSprite.GetComponent<Image>().sprite = _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteIcon_03", _canvas.GetComponent<ImageMonitoring>()._icon);
            //gameObjectGearSprite.AddComponent<SaveStateSpriteAnimation>();
            PlayerPrefs.SetFloat("CurrentAstridPositionX", AstridNewPosX);
            PlayerPrefs.SetFloat("CurrentAstridPositionY", AstridNewPosY);
            PlayerPrefs.SetFloat("CurrentAstridPositionZ", AstridNewPosZ);
            PlayerPrefs.SetFloat("CurrentAstridRotationX", AstridNewRotationX);
            PlayerPrefs.SetFloat("CurrentAstridRotationY", AstridNewRotationY);
            PlayerPrefs.SetFloat("CurrentAstridRotationZ", AstridNewRotationZ);
            //_NewSceneAstridPositionX = x;
            //_NewSceneAstridPositionY = y;
            //_NewSceneAstridPositionZ = z;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            _isCollisionTrue = true;
            LoadNewScene();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            _isCollisionTrue = true;
            LoadNewScene();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            _isCollisionTrue = false;
        }
    }

    private void LoadNewScene()
    {
        SetNewAstridPosition();
        //GameObject.Find("MenuCanvas").GetComponent<SaveController>().LoadSceneAstridPosition(_NewSceneAstridPositionX, _NewSceneAstridPositionY, _NewSceneAstridPositionZ, this.gameObject.name);

        Destroy(GameObject.Find("PanelOverWriteData"));
    }

    private void SetNewAstridPosition()
    {
        if (PlayerPrefs.GetString("CurrentScene") == "LostTimeGearDistrict")
        {
            CreateLostTimeGearDistrictSceneWayPoints();
        }
        if (PlayerPrefs.GetString("CurrentScene") == "LostTimeAstridHouse")
        {
            CreateAstridHouseLoadSceneWaypoints();
        }
    }
}
