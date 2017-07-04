using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour {

    GameObject DialogueBubble;

    private void FixedUpdate()
    {
        if(DialogueBubble != null)
        {
            DialogueBubble.transform.position = new Vector3(this.transform.position.x, Mathf.Abs(this.transform.position.y) * 3, this.transform.position.z);
        }
    }

    public void StartDialogueWithPNJ()
    {
        if(GameObject.Find("DialogueBubble" + this.transform.name) == false)
        {
            DialogueBubble = (GameObject)Instantiate(Resources.Load("DialogueBubble/DialogueBubble"));
            GameObject.Find("DialogueBubble(Clone)").transform.name = "DialogueBubble" + this.transform.name;
            DialogueBubble.AddComponent<DialogueBubbleController>();
            DialogueBubble.GetComponent<DialogueBubbleController>().GetParent = this.transform.name;
            DialogueBubble.AddComponent<BoxCollider>();
            DialogueBubble.transform.position = new Vector3(this.transform.position.x, Mathf.Abs(this.transform.position.y) * 3, this.transform.position.z);
        }
    }

    public void DestroyDialoguePanel()
    {
        Destroy(GameObject.Find("DialogueBubble" + this.transform.name));
    }

    public void UIDialoguePanel()
    {
        Debug.Log("start");
        // demander à forgeron de te donner dans pnjquestcontroller son questcontext
        // refaire l'affichage de UIDIAlogue
    }
}
