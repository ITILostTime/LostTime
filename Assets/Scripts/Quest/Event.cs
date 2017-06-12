using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public interface IEvent
{
    void doSomething();
}


/// <summary>
/// 
/// Récepteur
/// 
/// </summary>
public class ToggleEvent : IEvent
{
    [Inject]
    QuestManager _questManager;
    public string _value = null;
    public string _target = null;
    public int indexQuest = 0;
    public int indexState = 0;
    public int indexValue = 1;

    public ToggleEvent()
    {
        _questManager = GameObject.Find("QuestTable").GetComponent<QuestManager>();
    }

    public void set(string value, string target)
    {
        _value = value;
        _target = target;
    }

    public void Update()
    {
        for (indexValue = 1; _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].valuesList[indexValue] != null; indexValue++)
        {
            if (_questManager.questContainer.questCollection[indexQuest].stateArray[indexState].valuesList[indexValue].state == true)
            {
                _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].valuesList[0].state = true;
            }
        }
    }

    public void doSomething()
    {

        for (; _questManager.questContainer.questCollection[indexQuest].questID != null; indexQuest++)
        {
            if (_questManager.questContainer.questCollection[indexQuest].questID == _questManager.questContainer.currentQuest)
                for (; _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].name != null; indexState++)
                {
                    if (_questManager.questContainer.questCollection[indexQuest].stateArray[indexState].name == _target)
                    {
                        for (; _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].valuesList[indexValue] != null; indexValue++)
                        {
                            if (_questManager.questContainer.questCollection[indexQuest].stateArray[indexState].valuesList[indexValue].linkedActorName == _target)
                            {
                                _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].valuesList[indexValue].state = true;
                                Update();
                                if (_questManager.questContainer.questCollection[indexQuest].stateArray[indexState].valuesList[indexValue].isDisposable == true)
                                {
                                    _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].valuesList[0].state = true;
                                }
                            }
                        }
                    }
                }
        }
    }
}

public class EventDialogue : IEvent
{
    [Inject]
    DialogueCollection _dialogueCollection;
    private string _dialogueId = null;
    List<string> _dialoguelist = new List<string>();

    public EventDialogue()
    {
        QuestManager questManager = GameObject.Find("QuestTable").GetComponent<QuestManager>();
        _dialogueCollection = questManager.dialogueCollection;
    }

    public void set(string dialogueId)
    {
        _dialogueId = dialogueId;
    }

    public int[] getListDialogue()
    {

        char[] tmpchar = _dialogueId.ToCharArray();
        string tmp = null;
        List<int> dialogueInt = new List<int>();

        for (int i = 0; i < tmpchar.Length; i++)
        {
            if (tmpchar[i] != '§'){
                tmp += tmpchar[i];
            }
            else{
                _dialoguelist.Add(_dialogueCollection.dialogueArray[int.Parse(tmp)]);
                tmp = null;
            }
        }
        return dialogueInt.ToArray();
    }
    public void doSomething()
    {
        if (_dialogueId.Contains("§"))
            getListDialogue();
        //else

        // a terminer
    }
}

public class SwitchQuest : IEvent
{
    [Inject]
    QuestManager _questManager;
    public string _value;
    public string _target;
    int indexQuest = 0;


    public SwitchQuest()
    {
        _questManager = GameObject.Find("QuestTable").GetComponent<QuestManager>();
    }

    public void set(string value, string target)
    {
        _value = value;
        _target = target;
    }

    public void doSomething()
    {
        for (; _questManager.questContainer.questCollection[indexQuest].questID != null; indexQuest++)
        {
            if (_questManager.questContainer.questCollection[indexQuest].questID == _target)
            {
                _questManager.questContainer.currentQuest = _target;
                _questManager.questContainer.questCollection[indexQuest].currentState = _questManager.questContainer.questCollection[indexQuest].stateArray[0].name;
                _questManager.NPCsCaching(_questManager.questContainer.questCollection[indexQuest].stateArray[0].LinkedActor);
            }
        }
    }
}

public class SwitchState : IEvent
{
    [Inject]
    QuestManager _questManager;
    public string _value;
    public string _target;
    int indexQuest;
    int indexState;


    public SwitchState()
    {
        _questManager = GameObject.Find("QuestTable").GetComponent<QuestManager>();
    }

    public void set(string value, string target)
    {
        _value = value;
        _target = target;
    }

    public void doSomething()
    {
        for (; _questManager.questContainer.questCollection[indexQuest].questID != null; indexQuest++)
        {
            if (_questManager.questContainer.questCollection[indexQuest].questID == _questManager.questContainer.currentQuest)
                for (; _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].name != null; indexState++)
                {
                    if (_questManager.questContainer.questCollection[indexQuest].stateArray[indexState].name == _target)
                    {
                        _questManager.questContainer.questCollection[indexQuest].currentState = _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].name;
                        _questManager.NPCsCaching(_questManager.questContainer.questCollection[indexQuest].stateArray[indexState].LinkedActor);
                    }
                }
        }
    }
}

public class SwitchAction : IEvent
{
    [Inject]
    QuestManager _questManager;
    int indexQuest = 0;
    int indexState = 0;
    int indexActor = 0;
    int indexAction = 0;
    public int _value;
    public string _target;


    public SwitchAction()
    {
        _questManager = GameObject.Find("QuestTable").GetComponent<QuestManager>();
    }

    public void set(string value, string target)
    {

        _value = int.Parse(value); // en fonction du choix du player sinon est == a 1
        _target = target; // correspond au nom de l'entité qui doit changer d' action
    }

    public void doSomething()
    {
        int newActionIndex;
        ActorAction[] current;

        for (; _questManager.questContainer.questCollection[indexQuest].questID != null; indexQuest++)
        {
            if (_questManager.questContainer.questCollection[indexQuest].questID == _questManager.questContainer.currentQuest)
                for (; _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].name != null; indexState++)
                {
                    if (_questManager.questContainer.questCollection[indexQuest].stateArray[indexState].name == _questManager.questContainer.questCollection[indexQuest].currentState)
                        for (; _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor] != null; indexActor++)
                        {
                            if (_questManager.questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].name == _target)
                            {
                                current = _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].currentActions;
                                newActionIndex = _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].actionListSetUp.IndexOf(current);
                                _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].currentActions = _questManager.questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].actionListSetUp[newActionIndex + _value]; // set la nouvelle list d'action en fonction du int correspondant a la position dans la liste 
                            }

                        }
                }
        }
    }
}

public interface Command
{
    void execute();
}


/// <summary>
/// 
/// Commande concrète
/// 
/// </summary>
public class ConcreteCommand : Command
{
    private IEvent _action;

    public ConcreteCommand(IEvent action)
    {
        this._action = action;
    }

    public void execute()
    {
        this._action.doSomething();
    }
}
