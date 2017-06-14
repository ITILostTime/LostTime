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
    QuestM _questM;
    public string _value = null;
    public string _target = null;
    public int indexQuest = 0;
    public int indexState = 0;
    public int indexValue = 1;

    public ToggleEvent()
    {
        _questM = GameObject.Find("QuestTable").GetComponent<QuestM>();
    }

    public void set(string value, string target)
    {
        _value = value;
        _target = target;
    }

    public void Update()
    {
        for (indexValue = 1; _questM.questContainer.questCollection[indexQuest].stateArray[indexState].valuesList[indexValue] != null; indexValue++)
        {
            if (_questM.questContainer.questCollection[indexQuest].stateArray[indexState].valuesList[indexValue].state == true)
            {
                _questM.questContainer.questCollection[indexQuest].stateArray[indexState].valuesList[0].state = true;
            }
        }
    }

    public void doSomething()
    {

        for (; _questM.questContainer.questCollection[indexQuest].questID != null; indexQuest++)
        {
            if (_questM.questContainer.questCollection[indexQuest].questID == _questM.questContainer.currentQuest)
                for (; _questM.questContainer.questCollection[indexQuest].stateArray[indexState].name != null; indexState++)
                {
                    if (_questM.questContainer.questCollection[indexQuest].stateArray[indexState].name == _target)
                    {
                        for (; _questM.questContainer.questCollection[indexQuest].stateArray[indexState].valuesList[indexValue] != null; indexValue++)
                        {
                            if (_questM.questContainer.questCollection[indexQuest].stateArray[indexState].valuesList[indexValue].linkedActorName == _target)
                            {
                                _questM.questContainer.questCollection[indexQuest].stateArray[indexState].valuesList[indexValue].state = true;
                                Update();
                                if (_questM.questContainer.questCollection[indexQuest].stateArray[indexState].valuesList[indexValue].isDisposable == true)
                                {
                                    _questM.questContainer.questCollection[indexQuest].stateArray[indexState].valuesList[0].state = true;
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
    DialogueC _dialogueCollection;
    private string _dialogueId = null;
    List<string> _dialoguelist = new List<string>();

    public EventDialogue()
    {
        QuestM questM = GameObject.Find("QuestTable").GetComponent<QuestM>();
        _dialogueCollection = questM.dialogueCollection;
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
    QuestM _questM;
    public string _value;
    public string _target;
    int indexQuest = 0;


    public SwitchQuest()
    {
        _questM = GameObject.Find("QuestTable").GetComponent<QuestM>();
    }

    public void set(string value, string target)
    {
        _value = value;
        _target = target;
    }

    public void doSomething()
    {
        for (; _questM.questContainer.questCollection[indexQuest].questID != null; indexQuest++)
        {
            if (_questM.questContainer.questCollection[indexQuest].questID == _target)
            {
                _questM.questContainer.currentQuest = _target;
                _questM.questContainer.questCollection[indexQuest].currentState = _questM.questContainer.questCollection[indexQuest].stateArray[0].name;
                _questM.NPCsCaching(_questM.questContainer.questCollection[indexQuest].stateArray[0].LinkedActor);
            }
        }
    }
}

public class SwitchState : IEvent
{
    [Inject]
    QuestM _questM;
    public string _value;
    public string _target;
    int indexQuest;
    int indexState;


    public SwitchState()
    {
        _questM = GameObject.Find("QuestTable").GetComponent<QuestM>();
    }

    public void set(string value, string target)
    {
        _value = value;
        _target = target;
    }

    public void doSomething()
    {
        for (; _questM.questContainer.questCollection[indexQuest].questID != null; indexQuest++)
        {
            if (_questM.questContainer.questCollection[indexQuest].questID == _questM.questContainer.currentQuest)
                for (; _questM.questContainer.questCollection[indexQuest].stateArray[indexState].name != null; indexState++)
                {
                    if (_questM.questContainer.questCollection[indexQuest].stateArray[indexState].name == _target)
                    {
                        _questM.questContainer.questCollection[indexQuest].currentState = _questM.questContainer.questCollection[indexQuest].stateArray[indexState].name;
                        _questM.NPCsCaching(_questM.questContainer.questCollection[indexQuest].stateArray[indexState].LinkedActor);
                    }
                }
        }
    }
}

public class SwitchAction : IEvent
{
    [Inject]
    QuestM _questM;
    int indexQuest = 0;
    int indexState = 0;
    int indexActor = 0;
    int indexAction = 0;
    public int _value;
    public string _target;


    public SwitchAction()
    {
        _questM = GameObject.Find("QuestTable").GetComponent<QuestM>();
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

        for (; _questM.questContainer.questCollection[indexQuest].questID != null; indexQuest++)
        {
            if (_questM.questContainer.questCollection[indexQuest].questID == _questM.questContainer.currentQuest)
                for (; _questM.questContainer.questCollection[indexQuest].stateArray[indexState].name != null; indexState++)
                {
                    if (_questM.questContainer.questCollection[indexQuest].stateArray[indexState].name == _questM.questContainer.questCollection[indexQuest].currentState)
                        for (; _questM.questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor] != null; indexActor++)
                        {
                            if (_questM.questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].name == _target)
                            {
                                current = _questM.questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].currentActions;
                                newActionIndex = _questM.questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].actionListSetUp.IndexOf(current);
                                _questM.questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].currentActions = _questM.questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].actionListSetUp[newActionIndex + _value]; // set la nouvelle list d'action en fonction du int correspondant a la position dans la liste 
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
