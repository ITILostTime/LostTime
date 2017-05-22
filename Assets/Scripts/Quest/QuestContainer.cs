using System.Collections.Generic;

using System.Xml.Serialization;

using System.IO;



[XmlRoot("QuestContainer")]

public class QuestContainer

{

    [XmlArray("QuestCollection")]

    [XmlArrayItem("Quest")]

    public Quest[] questCollection;

    //public List<Quest> questCollection = new List<Quest>();



    public string currentQuest;

    public LinkedActor[] setUpActorList;

}



public class Quest

{

    [XmlAttribute("currentState")]

    public string currentState;

    [XmlAttribute("nameOfQuest")]

    public string questID;

    [XmlArray("stateArray")]

    [XmlArrayItem("State")]

    public State[] stateArray;

}



public class LinkedActor

{

    public string id;

    public string name;

    public string job;

    public float[] position;

    public bool canDie;

}



public class State

{

    [XmlAttribute("valuesList")]

    //public bool[] valuesList;

    public ToggleBool[] valuesList;



    public string name;

    public bool isSetUp;

    public Actor[] actorArray;

    public LinkedActor[] LinkedActor;

}



public class ToggleBool

{

    public bool state;

    public string linkedActorName;

    public bool isDisposable;

}



public class Actor

{

    public string name;

    bool isSetUp { get; set; }

    void Update()

    {

    }



    public List<ActorAction[]> actionListSetUp = new List<ActorAction[]>();

    //public ActorAction[] actionListActive;

    public ActorAction[] currentActions;

}



public class ActorAction

{

    public string name;

    public string switchValue;

    public string value;

    public string target;

}
