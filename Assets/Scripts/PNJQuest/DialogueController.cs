using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

    GameObject DialogueBubble;
    GameObject UserInterface;

    private void FixedUpdate()
    {
        if(DialogueBubble != null)
        {
            DialogueBubble.transform.position = new Vector3(this.transform.position.x, Mathf.Abs(this.transform.position.y) + 1, this.transform.position.z);
        }
        if(GameObject.Find("DialoguePanel" + this.transform.name) == true)
        {
            // traduire le text ici
            GameObject.Find("DialogueTextPanel").GetComponent<Text>().text = this.GetComponent<PNJQuestController>().CurrentPNJQuestContext;

            // traduire le nom ici
            GameObject.Find("PNJNamePanel").GetComponent<Text>().text = this.transform.name;

            UserInterface.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("ButtonDecline", "Decline", "Refuser");
            UserInterface.GetComponent<TextMonitoring>().SetTextInCorrectLanguages("ButtonAccepted", "Accept", "Accepter");
        }
        
    }

    public void StartDialogueWithPNJ(Sprite icon)
    {
        if(GameObject.Find("DialogueBubble" + this.transform.name) == false)
        {
            DialogueBubble = (GameObject)Instantiate(Resources.Load("DialogueBubble/DialogueBubble"));
            GameObject.Find("DialogueBubble(Clone)").transform.name = "DialogueBubble" + this.transform.name;
            DialogueBubble.AddComponent<DialogueBubbleController>();
            DialogueBubble.GetComponent<DialogueBubbleController>().GetParent = this.transform.name;
            DialogueBubble.AddComponent<BoxCollider>();
            DialogueBubble.transform.position = new Vector3(this.transform.position.x, Mathf.Abs(this.transform.position.y) + 1, this.transform.position.z);
            DialogueBubble.GetComponent<SpriteRenderer>().sprite = icon;
        }
    }

    public void DestroyDialoguePanel()
    {
        Destroy(GameObject.Find("DialogueBubble" + this.transform.name));
        Destroy(GameObject.Find("DialoguePanel" + this.transform.name));
    }

    public void UIDialoguePanel()
    {
        // demander à forgeron de te donner dans pnjquestcontroller son questcontext
        // refaire l'affichage de UIDIAlogue

        UserInterface = GameObject.Find("MenuCanvas");

        if (GameObject.Find("DialoguePanel") == false)
        {
            UserInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectImage("DialoguePanel" + this.transform.name, UserInterface, true, 
                Screen.width / 2, Screen.height / 3, 0,Screen.height / -2 + Screen.height / 6, Color.white);

            UserInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("PNJNamePanel", GameObject.Find("DialoguePanel" + this.transform.name), true,
                GameObject.Find("DialoguePanel" + this.transform.name).GetComponent<RectTransform>().rect.width / 2, 
                GameObject.Find("DialoguePanel" + this.transform.name).GetComponent<RectTransform>().rect.height / 6,
                0, GameObject.Find("DialoguePanel" + this.transform.name).GetComponent<RectTransform>().rect.height / 2 
                + GameObject.Find("DialoguePanel" + this.transform.name).GetComponent<RectTransform>().rect.height / 12,
                "", UserInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, 0, Color.black);
            GameObject.Find("PNJNamePanel").GetComponent<Text>().resizeTextForBestFit = true;
            // attribuer le nom en anglais via textmonitoring => créer une fct qui va donner les noms des pnjs en anglais et en français au besoin

            UserInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectTextZone("DialogueTextPanel", GameObject.Find("DialoguePanel" + this.transform.name), true,
                (GameObject.Find("DialoguePanel" + this.transform.name).GetComponent<RectTransform>().rect.width / 10) * 9, 
                (GameObject.Find("DialoguePanel" + this.transform.name).GetComponent<RectTransform>().rect.height / 4) * 3,
                0, 0, "", UserInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleLeft, FontStyle.Bold,
                0, Color.black);

            UserInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectButtonWithText("ButtonAccepted", GameObject.Find("DialoguePanel" + this.transform.name), true,
                GameObject.Find("DialoguePanel" + this.transform.name).GetComponent<RectTransform>().rect.width / 4,
                GameObject.Find("DialoguePanel" + this.transform.name).GetComponent<RectTransform>().rect.height / 6,
                GameObject.Find("DialoguePanel" + this.transform.name).GetComponent<RectTransform>().rect.width / -4,
                GameObject.Find("DialoguePanel" + this.transform.name).GetComponent<RectTransform>().rect.height / -2
                + GameObject.Find("DialoguePanel" + this.transform.name).GetComponent<RectTransform>().rect.height / 6,
                "", UserInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, 0, Color.black);
            GameObject.Find("ButtonAccepted").GetComponent<Text>().resizeTextForBestFit = true;
            GameObject.Find("ButtonAccepted").GetComponent<Button>().onClick.AddListener(() => AcceptedButton());

            UserInterface.GetComponent<CreateUserInterfaceObject>().CreateGameObjectButtonWithText("ButtonDecline", GameObject.Find("DialoguePanel" + this.transform.name), true,
                GameObject.Find("DialoguePanel" + this.transform.name).GetComponent<RectTransform>().rect.width / 4,
                GameObject.Find("DialoguePanel" + this.transform.name).GetComponent<RectTransform>().rect.height / 6,
                GameObject.Find("DialoguePanel" + this.transform.name).GetComponent<RectTransform>().rect.width / 4,
                GameObject.Find("DialoguePanel" + this.transform.name).GetComponent<RectTransform>().rect.height / -2
                + GameObject.Find("DialoguePanel" + this.transform.name).GetComponent<RectTransform>().rect.height / 6,
                "", UserInterface.GetComponent<TextMonitoring>().GetArialTextFont, TextAnchor.MiddleCenter, FontStyle.Bold, 0, Color.black);
            GameObject.Find("ButtonDecline").GetComponent<Text>().resizeTextForBestFit = true;
            GameObject.Find("ButtonDecline").GetComponent<Button>().onClick.AddListener(() => Declinebutton());
        }
    }

    private void AcceptedButton()
    {
        this.GetComponent<PNJQuestController>().IsQuestAccepted = true;

    }

    private void Declinebutton()
    {
        this.GetComponent<PNJQuestController>().IsQuestAccepted = false;
        Destroy(GameObject.Find("DialoguePanel" + this.transform.name));
    }
}
