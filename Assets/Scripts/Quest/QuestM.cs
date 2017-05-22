
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using System;

using System.Xml.Serialization;

using System.IO;

using Zenject;



public class QuestM

{

    public QuestContainer questContainer;

    public ProcessEvent _processEvent;

    public DialogueCollection dialogueCollection;

    public NPCSpawner _npcSpawner;

    List<NPCData> NPCCacheList;



    PositionEntity _positionStorage;

    int amountOfCrowdToSpawn = 30;

    int jobPointer = 0;

    public NPCSpawner NPCSpawnerInjector { get { return _npcSpawner; } set { _npcSpawner = value; } }

    public int AmountOfCrowdToSpawn { get { return amountOfCrowdToSpawn; } }

    public bool hasRequest { get; internal set; }

    public List<NPCData> NPCCache { get { return NPCCacheList; } private set { NPCCacheList = value; } }

    public QuestM()

    {

        NPCCacheList = new List<NPCData>();

        _positionStorage = new PositionEntity();

        _processEvent = new ProcessEvent();

        //setUP();

        Debug.Log("End building QuestManager");



    }

    void setUP()

    {

        //load Quests database

        questContainer = loadQuest();

        Debug.Log(questContainer.currentQuest);



        //load dialogue database

        dialogueCollection = loadDialogue();

        Debug.Log(dialogueCollection.dialogueArray[0]);



        //call the spawner to create the npcs for the begining of the game

        NPCsCaching(questContainer.questCollection[0].stateArray[0].LinkedActor);

    }



    internal void NPCsCaching(LinkedActor[] actorList)

    {

        hasRequest = true;

        List<NPCData> NPCCacheList = new List<NPCData>();

        foreach (LinkedActor actor in actorList)

        {

            //CALL NPCSPAWNER TO CREATE THE NEW NPCS BASED ON THE NPCS DATA CRAFTED HERE

            NPCCacheList.Add(craftNewNpc(actor));

        }

        NPCCache = NPCCacheList;

    }


    public static QuestContainer loadQuest()

    {

        var serializer = new XmlSerializer(typeof(QuestContainer));

        using (var stream = new FileStream("C:\\Users\\Camille\\Desktop\\Quest1.xml", FileMode.Open))

        {

            return serializer.Deserialize(stream) as QuestContainer;

        }

    }



    public static DialogueCollection loadDialogue()

    {

        var serializer = new XmlSerializer(typeof(DialogueCollection));

        using (var stream = new FileStream("C:\\Users\\Camille\\Desktop\\Dialogue.xml", FileMode.Open))

        {

            return serializer.Deserialize(stream) as DialogueCollection;

        }

    }





    /* Invocateur */

    public class ProcessEvent

    {

        private Command Command;



        public ProcessEvent()

        {

            this.Command = null;

        }



        public void executeCmd()

        {

            Command.execute();

        }



        public void setCommand(Command cmd)

        {

            this.Command = cmd;

        }

    }



    public ActorAction[] getcurrentActionList(string name)

    {

        int indexQuest = 0;

        int indexState = 0;

        int indexActor = 0;



        for (; questContainer.questCollection[indexQuest].questID != null; indexQuest++)

        {

            if (questContainer.questCollection[indexQuest].questID == questContainer.currentQuest)

                for (; questContainer.questCollection[indexQuest].stateArray[indexState].name != null; indexState++)

                {

                    if (questContainer.questCollection[indexQuest].stateArray[indexState].name == questContainer.questCollection[indexQuest].currentState)

                        for (; questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor] != null; indexActor++)

                        {

                            if (questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].name == name)

                                return questContainer.questCollection[indexQuest].stateArray[indexState].actorArray[indexActor].currentActions; // modifier pour renvoyer une liste d'Action

                        }

                }

        }



        return null;

    }



    public NPCData craftNewNpc(LinkedActor actor)

    {

        string uuid = Guid.NewGuid().ToString();



        string job = actor.job;



        Vector3 pos = new Vector3(actor.position[0], actor.position[1], actor.position[2]);



        return new NPCData(uuid, job, pos, Quaternion.Euler(0, 0, 0), false, WalkMode.idle, actor.canDie);

    }

    /// <summary>

    /// VERY DIRTY THING TO CREATE RANDOMLY NPC WANDERING ACROSS THE MAP

    /// </summary>

    /// <returns></returns>

    public NPCData craftNewNpcByRandom()

    {

        string uuid = Guid.NewGuid().ToString();



        int randomJobNumber = jobTick();

        string job = Toolbox.jobEnumToString((job)Toolbox.optimizedRand(0, 11));



        Vector3 pos = _positionStorage.getPosition(Mathf.Clamp(randomJobNumber, 0, Toolbox.optimizedRand(0, randomJobNumber)));





        return new NPCData(uuid, job, pos, Quaternion.Euler(0, 0, 0), true, WalkMode.walking, false);

    }

    private int jobTick()

    {

        int ret = jobPointer;

        jobPointer++;

        if (jobPointer > 11) jobPointer = 0;

        return ret;

    }

}