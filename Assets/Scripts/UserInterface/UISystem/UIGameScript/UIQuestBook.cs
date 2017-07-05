using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using SimpleJSON;
using System.IO;
using Assets.Scripts.Quest;
using UnityEngine.UI;
using System;

public class UIQuestBook : MonoBehaviour, IPointerDownHandler
{

    private GameObject _canvas;
    private bool _UIQuestBookPanelActivated;
    private bool _UIQuestBookAnimationOn;
    List<QuestController> questLogListCompleted;
    List<QuestController> questOnGoing;
    private GameObject UIQuestBookPanel;

    public bool UIQuestBookAnimationOn { get { return _UIQuestBookAnimationOn; } set { _UIQuestBookAnimationOn = value; } }
    public bool UIQuestBookPanelActivated { get { return _UIQuestBookPanelActivated; } set { _UIQuestBookPanelActivated = value; } }

    private void Start()
    {
        _canvas = GameObject.Find("MenuCanvas");
        questLogListCompleted = new List<QuestController>();
        questOnGoing = new List<QuestController>();
    }

    private void Update()
    {
        if (GameObject.Find("UIQuestBookPanel") == true && _UIQuestBookPanelActivated == true && _UIQuestBookAnimationOn == true)
        {
            _UIQuestBookAnimationOn = _canvas.GetComponent<AnimationUserInterfaceController>().VrtAnimToUserInterface("UIQuestBookPanel", 0, 0, -1);
        }
        else if (GameObject.Find("UIQuestBookPanel") == true && _UIQuestBookPanelActivated == false && _UIQuestBookAnimationOn == true)
        {
            _UIQuestBookAnimationOn = _canvas.GetComponent<AnimationUserInterfaceController>().VrtAnimToDestroy("UIQuestBookPanel",
                _canvas.GetComponent<RectTransform>().rect.height, 1);
        }

    }

    private void CheckOpenPanel()
    {
        if (GameObject.Find("UIInventoryPanel") == true)
        {
            GameObject.Find("InventoryButton").GetComponent<UIInventory>().UIInventoryPanelAnimationOn = true;
            GameObject.Find("InventoryButton").GetComponent<UIInventory>().UIInventoryPanelActivated = false;
        }
        if (GameObject.Find("UIConfigurePanel") == true)
        {
            GameObject.Find("UIConfigureButton").GetComponent<UIConfigure>().UIConfigureAnimationOn = true;
            GameObject.Find("UIConfigureButton").GetComponent<UIConfigure>().UIConfigureActivated = false;
        }
        if (GameObject.Find("UIMapPanel") == true)
        {
            GameObject.Find("UIMapButton").GetComponent<UIMap>().UIMapPanelAnimationOn = true;
            GameObject.Find("UIMapButton").GetComponent<UIMap>().UIMapPanelActivated = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        CheckOpenPanel();

        if (GameObject.Find("UIQuestBookPanel") == false)
        {
            _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImageSprite("UIQuestBookPanel", _canvas, true,
            _canvas.GetComponent<RectTransform>().rect.width / 3, (_canvas.GetComponent<RectTransform>().rect.height / 10) * 8,
            0, _canvas.GetComponent<RectTransform>().rect.height,
            _canvas.GetComponent<ImageMonitoring>().GetSprite("SpriteBackGround_03", _canvas.GetComponent<ImageMonitoring>()._BackGroundSprite));

            UIQuestBookPanel = GameObject.Find("UIQuestBookPanel");

            SetTheTwoList();
            SetQuestLogInterface();

            _UIQuestBookPanelActivated = true;
            _UIQuestBookAnimationOn = true;
        }
        else
        {
            _UIQuestBookPanelActivated = false;
            _UIQuestBookAnimationOn = true;
        }
    }

    private string ReadJSON(string JSONPath)
    {
        TextAsset file = Resources.Load(JSONPath) as TextAsset;
        string content = file.ToString();
        return content;
    }

    private void SetTheTwoList()
    {
        string rd = ReadJSON("JSON/QuestTest");
        JSONNode QuestTest = JSON.Parse(rd);

        for(float x = 1; x < QuestTest["QuestMax"]; x += 0.1f)
        {
            if(QuestTest["Quest" + x][0]["QuestIsComplete"].AsBool == false && QuestTest["Quest" + x][0]["ObjectiveID"].AsInt > 0)
            {
                questOnGoing.Add(GetQuest(QuestTest, QuestTest["Quest" + x][0]["QuestID"].AsFloat));
            }else if (QuestTest["Quest" + x][0]["QuestIsComplete"].AsBool == true)
            {
                questLogListCompleted.Add(GetQuest(QuestTest, QuestTest["Quest" + x][0]["QuestID"].AsFloat));
            }
        }

        //foreach (QuestController n in questOnGoing)
        //{
        //    Debug.Log(n.QuestID);
        //}
        //foreach (QuestController n in questLogListCompleted)
        //{
        //    Debug.Log(n.QuestID);
        //}
    }

    private QuestController GetQuest(JSONNode QuestTest, float i)
    {
        List<ObjectiveController> questObjectives = new List<ObjectiveController>();
        ObjectiveController tmpIQuestObjective;
        int count = 0;

        for (int j = 1; j <= QuestTest["Quest" + i][0]["ObjectiveMax"].AsInt; j++)
        {
            if (j == QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"])
            {

                if (QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"] == "Collecte")
                {
                    //Debug.Log("Collect");
                    tmpIQuestObjective = new ObjectiveController(
                    QuestTest["Quest" + i][0]["Objectives"][count]["QuestID"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"],
                    QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveName"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveDescription"],
                    QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveIsComplete"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveContext"],
                    QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"], QuestTest["Quest" + i][0]["Objectives"][count]["ItemQuantity"]);
                    questObjectives.Add(tmpIQuestObjective);

                    if (GameObject.Find("QID" + QuestTest["Quest" + i][count]["QuestID"].AsFloat + "OID" + QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"].AsInt) == false)
                    {
                        GameObject OC = new GameObject();
                        OC.AddComponent<ObjectiveController>();
                        OC.GetComponent<ObjectiveController>().name = "QID" + QuestTest["Quest" + i][count]["QuestID"].AsFloat + "OID" + QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"].AsInt;
                        OC.GetComponent<ObjectiveController>().QuestID = tmpIQuestObjective.QuestID;
                        OC.GetComponent<ObjectiveController>().ObjectiveID = tmpIQuestObjective.ObjectiveID;
                        OC.GetComponent<ObjectiveController>().ObjectiveDescription = tmpIQuestObjective.ObjectiveDescription;
                        OC.GetComponent<ObjectiveController>().ObjectiveIsComplete = tmpIQuestObjective.ObjectiveIsComplete;
                        OC.GetComponent<ObjectiveController>().ObjectiveContext = tmpIQuestObjective.ObjectiveContext;
                        OC.GetComponent<ObjectiveController>().ObjectiveType = tmpIQuestObjective.ObjectiveType;
                        OC.GetComponent<ObjectiveController>().GoalAmount = tmpIQuestObjective.GoalAmount;
                    }
                    //Debug.Log("generate");

                }
                else if (QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"] == "GoToZone")
                {
                    //Debug.Log("GoToZone");
                    tmpIQuestObjective = new ObjectiveController(
                    QuestTest["Quest" + i][0]["QuestID"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"],
                    QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveName"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveDescription"],
                    QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveIsComplete"], QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveContext"],
                    QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"], QuestTest["Quest" + i][0]["Objectives"][count]["PositionX"],
                    QuestTest["Quest" + i][0]["Objectives"][count]["PositionY"], QuestTest["Quest" + i][0]["Objectives"][count]["PositionZ"]);
                    questObjectives.Add(tmpIQuestObjective);

                    if (GameObject.Find("QID" + QuestTest["Quest" + i][count]["QuestID"].AsFloat + "OID" + QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"].AsInt) == false)
                    {
                        GameObject OGTZ = new GameObject();
                        OGTZ.AddComponent<ObjectiveController>();
                        OGTZ.GetComponent<ObjectiveController>().name = "QID" + QuestTest["Quest" + i][count]["QuestID"].AsFloat + "OID" + QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveID"].AsInt;
                        OGTZ.GetComponent<ObjectiveController>().QuestID = tmpIQuestObjective.QuestID;
                        OGTZ.GetComponent<ObjectiveController>().ObjectiveID = tmpIQuestObjective.ObjectiveID;
                        OGTZ.GetComponent<ObjectiveController>().ObjectiveDescription = tmpIQuestObjective.ObjectiveDescription;
                        OGTZ.GetComponent<ObjectiveController>().ObjectiveIsComplete = tmpIQuestObjective.ObjectiveIsComplete;
                        OGTZ.GetComponent<ObjectiveController>().ObjectiveContext = tmpIQuestObjective.ObjectiveContext;
                        OGTZ.GetComponent<ObjectiveController>().ObjectiveType = tmpIQuestObjective.ObjectiveType;
                        OGTZ.GetComponent<ObjectiveController>().TypeGoToZoneIsComplete = tmpIQuestObjective.TypeGoToZoneIsComplete;
                    }
                }
                else if (QuestTest["Quest" + i][0]["Objectives"][count]["ObjectiveType"] == "TalkToPNJ")
                {
                    //Debug.Log("TalkToPNJ");
                    //AttributeObjectiveToAPNJ(QuestTest, i, tmpIQuestObjective.ObjectiveID);
                }
                else
                {
                    //Debug.Log("Default");
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

        QuestController questController = new QuestController(QuestTest["Quest" + i][0]["QuestPNJ"], QuestTest["Quest" + i][0]["QuestID"].AsFloat,
        QuestTest["Quest" + i][0]["QuestName"], QuestTest["Quest" + i][0]["QuestContext"], QuestTest["Quest" + i][0]["QuestDescription"],
        QuestTest["Quest" + i][0]["QuestIsComplete"].AsBool, QuestTest["Quest" + i][0]["ObjectiveID"].AsInt, QuestTest["Quest" + i][0]["ObjectiveMax"].AsInt, questObjectives);

        //Debug.Log(questController.QuestID);

        return questController;
    }

    private void SetQuestLogInterface()
    {
        // set Panel title
        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("UIQuestBookPanelTitle", UIQuestBookPanel, true,
            UIQuestBookPanel.GetComponent<RectTransform>().rect.width / 2, UIQuestBookPanel.GetComponent<RectTransform>().rect.height / 10,
            0, UIQuestBookPanel.GetComponent<RectTransform>().rect.height / 2 - UIQuestBookPanel.GetComponent<RectTransform>().rect.height / 20,
            "", _canvas.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, 0, Color.black);
        GameObject.Find("UIQuestBookPanelTitle").GetComponent<Text>().resizeTextForBestFit = true;
        _canvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("UIQuestBookPanelTitle", "QuestBook", "Livre de quêtes");

        // set button show on going quest
        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("UIQuestBookPanelOnGoingQuestBackground", UIQuestBookPanel, true,
            UIQuestBookPanel.GetComponent<RectTransform>().rect.width / 2, UIQuestBookPanel.GetComponent<RectTransform>().rect.height / 10,
            UIQuestBookPanel.GetComponent<RectTransform>().rect.width / -2 + UIQuestBookPanel.GetComponent<RectTransform>().rect.width / 4,
            UIQuestBookPanel.GetComponent<RectTransform>().rect.height / 4, Color.white);
        GameObject.Find("UIQuestBookPanelOnGoingQuestBackground").AddComponent<Button>();
        GameObject.Find("UIQuestBookPanelOnGoingQuestBackground").GetComponent<Button>().onClick.AddListener(() => GenerateQuestLog(questOnGoing)); 

        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("UIQuestBookPanelOnGoingQuest", GameObject.Find("UIQuestBookPanelOnGoingQuestBackground"), 
            true, GameObject.Find("UIQuestBookPanelOnGoingQuestBackground").GetComponent<RectTransform>().rect.width,
            GameObject.Find("UIQuestBookPanelOnGoingQuestBackground").GetComponent<RectTransform>().rect.height, 0, 0,"", _canvas.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, 0,
            Color.black);
        GameObject.Find("UIQuestBookPanelOnGoingQuest").GetComponent<Text>().resizeTextForBestFit = true;
        GameObject.Find("UIQuestBookPanelOnGoingQuest").GetComponent<Text>().verticalOverflow = VerticalWrapMode.Truncate;
        _canvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("UIQuestBookPanelOnGoingQuest", "On Going Quest", "Quêtes En Cours");

        // set button show completed quest
        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("UIQuestBookPanelCompletedQuestBackground", UIQuestBookPanel, true,
            UIQuestBookPanel.GetComponent<RectTransform>().rect.width / 2, UIQuestBookPanel.GetComponent<RectTransform>().rect.height / 10,
            UIQuestBookPanel.GetComponent<RectTransform>().rect.width / 2 - UIQuestBookPanel.GetComponent<RectTransform>().rect.width / 4,
            UIQuestBookPanel.GetComponent<RectTransform>().rect.height / 4, Color.white);
        GameObject.Find("UIQuestBookPanelCompletedQuestBackground").AddComponent<Button>();
        GameObject.Find("UIQuestBookPanelCompletedQuestBackground").GetComponent<Button>().onClick.AddListener(() => GenerateQuestLog(questLogListCompleted));

        _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("UIQuestBookPanelCompletedQuest", GameObject.Find("UIQuestBookPanelCompletedQuestBackground"), true,
            GameObject.Find("UIQuestBookPanelCompletedQuestBackground").GetComponent<RectTransform>().rect.width,
            GameObject.Find("UIQuestBookPanelCompletedQuestBackground").GetComponent<RectTransform>().rect.height, 0, 0, "", 
            _canvas.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, 0,
            Color.black);
        GameObject.Find("UIQuestBookPanelCompletedQuest").GetComponent<Text>().resizeTextForBestFit = true;
        GameObject.Find("UIQuestBookPanelCompletedQuest").GetComponent<Text>().verticalOverflow = VerticalWrapMode.Truncate;
        _canvas.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("UIQuestBookPanelCompletedQuest", "Completed Quest", "Quêtes Terminer");

    }

    private void GenerateQuestLog(List<QuestController> questLogList)
    {
        Destroy(GameObject.Find("PanelQuest"));

        if (GameObject.Find("PanelQuest") == false)
        {
            // set panel quest
            _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("PanelQuest", UIQuestBookPanel, true,
                UIQuestBookPanel.GetComponent<RectTransform>().rect.width / 10 * 9, UIQuestBookPanel.GetComponent<RectTransform>().rect.height / 3 * 2, 0,
                UIQuestBookPanel.GetComponent<RectTransform>().rect.height / -2 + UIQuestBookPanel.GetComponent<RectTransform>().rect.height / 3, Color.clear);

            int x = 0;
            string newParent = "aaaaaa";
            // set questitem panel
            foreach (QuestController n in questLogList)
            {
                if(newParent == "aaaaaa")
                {
                    _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectButtonWithText(n.QuestName + n.QuestID, GameObject.Find("PanelQuest"), true,
                        GameObject.Find("PanelQuest").GetComponent<RectTransform>().rect.width / 10 * 9, GameObject.Find("PanelQuest").GetComponent<RectTransform>().rect.height / 10,
                        0, GameObject.Find("PanelQuest").GetComponent<RectTransform>().rect.height / 2 - GameObject.Find("PanelQuest").GetComponent<RectTransform>().rect.height / 20,
                        n.QuestName, _canvas.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleLeft, FontStyle.Bold, 0, Color.black);
                    GameObject.Find(n.QuestName + n.QuestID).GetComponent<Text>().resizeTextForBestFit = true;
                    GameObject.Find(n.QuestName + n.QuestID).GetComponent<Text>().verticalOverflow = VerticalWrapMode.Truncate;
                    GameObject.Find(n.QuestName + n.QuestID).GetComponent<Button>().onClick.AddListener(() => ShowQuestDetail(n));

                    newParent = n.QuestName + n.QuestID;
                }else
                {
                    _canvas.GetComponent<CreateUserInterfaceObject>().CreateGameObjectButtonWithText(n.QuestName + n.QuestID, GameObject.Find(newParent), true,
                        GameObject.Find("PanelQuest").GetComponent<RectTransform>().rect.width / 10 * 9, GameObject.Find("PanelQuest").GetComponent<RectTransform>().rect.height / 10,
                        0, - GameObject.Find(newParent).GetComponent<RectTransform>().rect.height,
                        n.QuestName, _canvas.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleLeft, FontStyle.Bold, 0, Color.black);
                    GameObject.Find(n.QuestName + n.QuestID).GetComponent<Text>().resizeTextForBestFit = true;
                    GameObject.Find(n.QuestName + n.QuestID).GetComponent<Text>().verticalOverflow = VerticalWrapMode.Truncate;
                    GameObject.Find(n.QuestName + n.QuestID).GetComponent<Button>().onClick.AddListener(() => ShowQuestDetail(n));

                    newParent = n.QuestName + n.QuestID;
                }
            }
        }
        
    }

    private void ShowQuestDetail(QuestController quest)
    {
        // questdetail
    }
}
