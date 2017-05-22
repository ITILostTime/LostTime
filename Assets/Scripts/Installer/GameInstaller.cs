using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public GameObject NPCPrefab;
    public override void InstallBindings()
    {

        Container.BindAllInterfaces<NPCSpawner>().To<NPCSpawner>().AsSingle();
        Container.Bind<QuestManager>().AsSingle();


        //Container.Bind<IPositionDirector>().To<NPCPositionDirector>();
        Container.Bind<IPathfinding>().To<NPCPathfinding>();
        Container.Bind<IAnimCtrl>().To<NPCAnimCtrl>();
        Container.Bind<ITailor>().To<NPCTailor>();

        Container.Bind<FactoryAnimation>().AsSingle();
        Container.Bind<FactoryPathfinding>().AsSingle();
        Container.Bind<FactoryTailor>().AsSingle();

        //Container.Bind<float>().FromInstance(0.1f);
        Container.BindFactory<ITailor,QuestM,NPCData,IAnimCtrl,IPathfinding, NPC, NPC.Factory>().FromPrefab(NPCPrefab);

        //Container.Bind<CrossDependecyResolver>().AsSingle().NonLazy();

        Debug.Log("EndBinding");
    }
}