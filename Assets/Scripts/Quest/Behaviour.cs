using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Behaviour : MonoBehaviour
{
    public string _name;
    //[Inject]
    QuestManager _questManager;

    ToggleEvent _toggle;
    EventDialogue _eventDialogue;
    SwitchQuest _switchQuest;
    SwitchState _switchState;
    SwitchAction _switchAction;
    Command _concreteCommand = null;
    IEvent _event = null;
    private void Start()
    {
        _name = "Forgeron";

        _questManager = GameObject.Find("QuestTable").GetComponent<QuestManager>();
        _toggle = new ToggleEvent();
        _eventDialogue = new EventDialogue();
        _switchQuest = new SwitchQuest();
        _switchState = new SwitchState();
        _switchAction = new SwitchAction();
    }

    private void OnTriggerEnter(Collider other)
    {
        catchEvent();
    }

    public void catchEvent()
    {
        _event = getEvent();
        _concreteCommand = new ConcreteCommand(_event);
        _questManager._processEvent.setCommand(_concreteCommand);
        _questManager._processEvent.executeCmd();

    }

    public IEvent getEvent()
    {
        ActorAction[] actions = _questManager.getcurrentActionList(_name); // doit retoruner une liste de d'action
                                                                           // créee une bouvcle pour traiter toute les actions 
        foreach (ActorAction action in actions)
        {
            switch (action.switchValue)
            {
                case "editValue":
                    _toggle.set(action.value, action.target);
                    return _toggle;
                case "getDialogue":
                    _eventDialogue.set(action.value);
                    return _eventDialogue;
                case "switchQuest":
                    _switchQuest.set(action.value, action.target);
                    return _switchQuest;
                case "switchState":
                    _switchState.set(action.value, action.target);
                    return _switchState;
                case "switchAction":
                    _switchAction.set(action.value, action.target);
                    return _switchAction;
                default:
                    Debug.Log("Bad name of function");
                    break;
            }
        }
        return null;
    }
}