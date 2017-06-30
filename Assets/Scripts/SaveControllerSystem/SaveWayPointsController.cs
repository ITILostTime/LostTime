﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveWayPointsController : MonoBehaviour {

    // Script qui gère la sauvegarde des données a partir des save waypoints

    private bool _onCollision;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            _onCollision = true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            _onCollision = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            _onCollision = false;
            Destroy(GameObject.Find("PanelOverWriteData"));
        }
    }

    private void OnMouseDown()
    {
        if (GameObject.Find("PanelOverWriteData") == false && _onCollision == true && GameObject.Find("InventoryBag") == false && GameObject.Find("GameMapPanel") == false
            && GameObject.Find("QuestBookPanel") == false && GameObject.Find("SystemConfigurationPanel") == false)
        {
            GameObject.Find("MenuCanvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("PanelOverWriteData", GameObject.Find("MenuCanvas"), true,
            GameObject.Find("MenuCanvas").GetComponent<RectTransform>().rect.width / 6, GameObject.Find("MenuCanvas").GetComponent<RectTransform>().rect.height / 4,
            0, GameObject.Find("MenuCanvas").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("MenuCanvas").GetComponent<RectTransform>().rect.height / 8, GameObject.Find("MenuCanvas").GetComponent<ImageMonitoring>().GetBackGround5);

            GameObject.Find("MenuCanvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelOverWriteDataLabel", GameObject.Find("PanelOverWriteData"), true,
                GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width, GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2, 0,
                GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 4,
                "Save your data ?", GameObject.Find("MenuCanvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                ((int)(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 10)), Color.black);

            GameObject.Find("MenuCanvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelOverWriteDataLabelYes", GameObject.Find("PanelOverWriteData"), true,
                GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2,
                -GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 3.5f,
                -(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 4),
                "Yes", GameObject.Find("MenuCanvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                ((int)(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 10)), Color.black);
            GameObject.Find("PanelOverWriteDataLabelYes").AddComponent<Button>();
            GameObject.Find("PanelOverWriteDataLabelYes").GetComponent<Button>().onClick.AddListener(() => SaveGame());

            GameObject.Find("MenuCanvas").GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PanelOverWriteDataLabelNo", GameObject.Find("PanelOverWriteData"), true,
                GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 2, GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2,
                GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.width / 3.5f,
                -(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 4),
                "No", GameObject.Find("MenuCanvas").GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold,
                ((int)(GameObject.Find("PanelOverWriteData").GetComponent<RectTransform>().rect.height / 10)), Color.black);
            GameObject.Find("PanelOverWriteDataLabelNo").AddComponent<Button>();
            GameObject.Find("PanelOverWriteDataLabelNo").GetComponent<Button>().onClick.AddListener(() => ClosePanel());
        }
    }

    private void SaveGame()
    {
        GameObject.Find("MenuCanvas").GetComponent<SaveAndLoadSystemController>().SaveBackUpSystem(PlayerPrefs.GetString("CurrentScene"));
        Destroy(GameObject.Find("PanelOverWriteData"));
    }

    private void ClosePanel()
    {
        Destroy(GameObject.Find("PanelOverWriteData"));
    }

}
