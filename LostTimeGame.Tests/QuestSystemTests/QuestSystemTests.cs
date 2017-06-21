using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Assets.Scripts.Quest;
using Assets.Scripts.Quest.ObjectivesTypes;
using Assets.Scripts.Quest.Interfaces;

namespace LostTimeGame.Tests.QuestSystemTests
{
    [TestFixture]
    public class QuestSystemTests
    {
        //[Test]
        //public void Create_quest()
        //{
        //    QuestController quest = new QuestController("Test_Title", 1, "Test", "Tutorial_Context", "Tutorial", false);

        //    Assert.That(quest.QuestTitle == "Test_Title");
        //    Assert.That(quest.QuestID == 1);
        //    Assert.That(quest.QuestName == "Test");
        //    Assert.That(quest.QuestContext == "Tutorial_Context");
        //    Assert.That(quest.QuestDescription == "Tutorial");
        //    Assert.That(quest.QuestIsComplete == false);
        //}

        //[Test]
        //public void Create_quest_objectives()
        //{
        //    TypeCollect TestType = new TypeCollect(0, 10);
        //    ObjectiveController test = new ObjectiveController(1, "test", "this is an objective test", TestType, false);

        //    Assert.That(test.ObjectiveName == "test");
        //    Assert.That(test.ObjectiveDescription == "this is an objective test");
        //    Assert.That(test.TypeCollect == TestType);
        //    Assert.That(test.ObjectiveIsComplete == false);
        //}

        //[Test]
        //public void Validate_quest_objectives()
        //{
        //    TypeCollect TestType = new TypeCollect(0, 10);
        //    ObjectiveController test = new ObjectiveController(1, "test", "this is an objective test", TestType, true);

        //    Assert.That(test.ObjectiveName == "test");
        //    Assert.That(test.ObjectiveDescription == "this is an objective test");
        //    Assert.That(test.TypeCollect == TestType);
        //    Assert.That(test.ObjectiveIsComplete == true);
        //}

        //[Test]
        //public void Validate_quest()
        //{
        //    QuestController quest = new QuestController("Test_Title", 1, "Test", "Tutorial_Context", "Tutorial", true);

        //    Assert.That(quest.QuestTitle == "Test_Title");
        //    Assert.That(quest.QuestID == 1);
        //    Assert.That(quest.QuestName == "Test");
        //    Assert.That(quest.QuestContext == "Tutorial_Context");
        //    Assert.That(quest.QuestDescription == "Tutorial");
        //    Assert.That(quest.QuestIsComplete == true);
        //}

        //[Test]
        //public void Objective_type_collect_can_be_completed()
        //{
        //    TypeCollect TestType = new TypeCollect(0, 10);
        //    ObjectiveController test = new ObjectiveController(1, "test", "this is an objective test", TestType, false);

        //    Assert.That(test.ObjectiveName == "test");
        //    Assert.That(test.ObjectiveDescription == "this is an objective test");
        //    Assert.That(test.TypeCollect == TestType);
        //    Assert.That(test.ObjectiveIsComplete == false);
        //    TestType.Amount = 10;
        //    Assert.That(TestType.IsComplete() == true);
        //}

        //[Test]
        //public void Objective_type_go_to_returns_informations()
        //{
        //    TypeGoToZone typeGoToZone = new TypeGoToZone(1, 3, 4, 5);
        //    ObjectiveController objectiveController = new ObjectiveController(1, "Test", "This is a test", typeGoToZone, false);

        //    Assert.That(objectiveController.ObjectiveName == "Test");
        //    Assert.That(objectiveController.ObjectiveDescription == "This is a test");
        //    Assert.That(objectiveController.TypeGoToZone == typeGoToZone);
        //    Assert.That(objectiveController.ObjectiveIsComplete == false);

        //    typeGoToZone.Zone = 1;
        //    typeGoToZone.PositionX = 3;
        //    typeGoToZone.PositionY = 4;
        //    typeGoToZone.PositionZ = 5;
        //}

        //[Test]
        //public void Objective_talk_to_PNJ_returns_informations()
        //{
        //    TypeTalkToPNJ typeTalkToPNJ = new TypeTalkToPNJ("Test");
        //    ObjectiveController oc = new ObjectiveController(1, "Try something", "Try talktopnj", typeTalkToPNJ, false);

        //    Assert.That(oc.ObjectiveName == "Try something");
        //    Assert.That(oc.ObjectiveDescription == "Try talktopnj");
        //    Assert.That(oc.TypeTalkToPNJ == typeTalkToPNJ);
        //    Assert.That(oc.ObjectiveIsComplete == false);
        //}

        //[Test]
        //public void Objectives_can_be_add_to_a_quest()
        //{
        //    //Quest creation
        //    QuestController quest = new QuestController("Test_Title", 1, "Test", "Tutorial_Context", "Tutorial", false);

        //    Assert.That(quest.QuestTitle == "Test_Title");
        //    Assert.That(quest.QuestID == 1);
        //    Assert.That(quest.QuestName == "Test");
        //    Assert.That(quest.QuestContext == "Tutorial_Context");
        //    Assert.That(quest.QuestDescription == "Tutorial");
        //    Assert.That(quest.QuestIsComplete == false);

        //    //Objective creation
        //    TypeCollect TestType = new TypeCollect(0, 10);
        //    ObjectiveController test = new ObjectiveController(1, "test", "this is an objective test", TestType, false);

        //    Assert.That(test.ObjectiveName == "test");
        //    Assert.That(test.ObjectiveDescription == "this is an objective test");
        //    Assert.That(test.TypeCollect == TestType);
        //    Assert.That(test.ObjectiveIsComplete == false);

        //    //Add the objective to the quest
        //    quest.Objectives.Add(test);

        //    Assert.That(quest.Objectives.Count == 1);
        //    Assert.That(quest.Objectives[0].ObjectiveName == "test");
        //    Assert.That(quest.Objectives[0].ObjectiveDescription == "this is an objective test");
        //    Assert.That(quest.Objectives[0].TypeCollect == TestType);
        //    Assert.That(quest.Objectives[0].ObjectiveIsComplete == false);
        //}

        //Pass without monobehaviour on questlog 
        //Must probably be test inside unity
        /*[Test]
        public void The_Quest_log_contains_questLibrary()
        {
            QuestController quest = new QuestController(1, "Test", "Tutorial", false);
            QuestController quest1 = new QuestController(2, "Test", "Tutorial", false);
            List<IQuest> LIQ = new List<IQuest> { quest, quest1 };
            QuestLibrary QLib = new QuestLibrary(LIQ);

            QuestLog QLog = new QuestLog(QLib);

            Assert.That(QLog.QuestLibrary != null);
        }*/
    }
}
