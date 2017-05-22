using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;

public class NPC : MonoBehaviour
{
    QuestManager _questManager;
    NPCData _data;
    IAnimCtrl _animationControl;
    IPathfinding _pathfinding;
    ITailor _tailor;

    // Note that we can't use a constructor anymore since we are a MonoBehaviour now
    [Inject]
    public void Construct(
        ITailor tailor,
        QuestManager questManager,
        NPCData data,
        IAnimCtrl animationControl,
        IPathfinding pathfinding
        )
    {
        _tailor = tailor;
        _questManager = questManager;
        _data = data;
        _animationControl = animationControl;
        _pathfinding = pathfinding;
    }

    public class Factory : Factory<
        ITailor,
        QuestM,
        NPCData, 
        IAnimCtrl,
        IPathfinding, 
        NPC>
    {      

    }
    void Start()
    {
        //Debug.Log("Begin initializing NewNPC");
        transform.rotation = _data.Rotation;
        transform.position = _data.Position;
        _tailor.setup(this);
        _animationControl.setup(this);
        _pathfinding.setup(this);        
        //Debug.Log("End initializing NewNPC");   
    }
    void Update()
    {
        _pathfinding.update();
        _animationControl.update();
          
    }
    private void OnTriggerEnter(Collider other)
    {
        _pathfinding.collide(other);
    }
}