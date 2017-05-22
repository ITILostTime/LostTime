using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;

public class NPCSpawner : ITickable, IInitializable
{
    readonly NPC.Factory _NPCFactory;  

    FactoryAnimation _animationFactory;
    FactoryPathfinding _pathfindingFactory;
    FactoryTailor _tailorFactory;

    QuestM _questManager;
    private int npcCount = 0;
    public QuestM QuestManagerInjector { get { return _questManager; } set { _questManager = value; } }
    public NPCSpawner(
        QuestM questManager,
        FactoryAnimation animationFactory,
        FactoryPathfinding pathfindingFactory,
        FactoryTailor tailorFactory,
        NPC.Factory NPCFactory
        )
    {
        _questManager = questManager;
        _NPCFactory = NPCFactory;
        _animationFactory = animationFactory;
        _tailorFactory = tailorFactory;
        _pathfindingFactory = pathfindingFactory;

        Debug.Log("End Building NPCSpawner");
    }
    public void Initialize()
    {
        _questManager.NPCSpawnerInjector = this;
        Debug.Log("Loaded");
    }
    public void Tick()
    {

        if (_questManager.hasRequest)
        {
            List<NPCData> npcRequested =  _questManager.NPCCache;
            foreach (NPCData data in npcRequested)
            {
                spawnNPC(data);
            }
            _questManager.hasRequest = false;
        }
        if(ShouldSpawnCrowdNPC())
        {
            spawnNPC(_questManager.craftNewNpcByRandom());
        }
        //Debug.Log("Tick");
    }
    private void spawnNPC(NPCData data)
    {
        //Debug.Log(string.Format("Start Factory NPC #{0}",npcCount));      
        var newAnimCtrl = _animationFactory.Create(data);
        var newPathfinding = _pathfindingFactory.Create(data);
        var newTailor = _tailorFactory.Create(data);
        var npc = _NPCFactory.Create(newTailor, _questManager, data, newAnimCtrl, newPathfinding);
        //Debug.Log("End Factory NPC");
        Debug.Log(string.Format("Spawn NPC #{0}, {1}", npcCount, data.ToString()));
    }
    public bool ShouldSpawnCrowdNPC()
    {
        npcCount++;
        return (npcCount<_questManager.AmountOfCrowdToSpawn) ? true : false;
    }

    
}

