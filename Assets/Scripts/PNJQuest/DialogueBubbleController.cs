using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBubbleController : MonoBehaviour
{

    public bool _isActivated { get; set; }

    public string GetParent { get; set; }
    

    private void OnMouseDown()
    {
        _isActivated = true;
    }

    private void OnMouseUp()
    {
        if(_isActivated == true)
        {
            GameObject.Find(GetParent).GetComponent<DialogueController>().UIDialoguePanel();
            _isActivated = false;
        }
    }
}
