using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assets.Scripts.Quest.Interfaces;
using Assets.Scripts.Quest;
using Assets.Scripts.Quest.ObjectivesTypes;

namespace LostTimeGame.Tests.QuestSystemTests
{
    [TestFixture]
    class QuestObjectivesTests
    {
        [Test]
        public void Create_basic_objectives_informations()
        {
            TypeCollect TestType = new TypeCollect(0, 10);
            ObjectiveController test = new ObjectiveController(1, "test", "this is an objective test", TestType, false);

            Assert.That(test.ObjectiveName == "test");
            Assert.That(test.ObjectiveDescription == "this is an objective test");
            Assert.That(test.TypeCollect == TestType);
            Assert.That(test.IsComplete == false);
        }

        [Test]
        public void Objective_type_collect_can_be_completed()
        {
            TypeCollect TestType = new TypeCollect(0, 10);
            ObjectiveController test = new ObjectiveController(1, "test", "this is an objective test", TestType, false);

            Assert.That(test.ObjectiveName == "test");
            Assert.That(test.ObjectiveDescription == "this is an objective test");
            Assert.That(test.TypeCollect == TestType);
            Assert.That(test.IsComplete == false);
            TestType.Amount = 10;
            Assert.That(TestType.IsComplete() == true);
        }

        [Test]
        public void Objective_type_go_to_returns_informations()
        {
            TypeGoToZone typeGoToZone = new TypeGoToZone(1, 3, 4, 5);
            ObjectiveController objectiveController = new ObjectiveController(1, "Test", "This is a test", typeGoToZone, false);

            Assert.That(objectiveController.ObjectiveName == "Test");
            Assert.That(objectiveController.ObjectiveDescription == "This is a test");
            Assert.That(objectiveController.TypeGoToZone == typeGoToZone);
            Assert.That(objectiveController.IsComplete == false);

            typeGoToZone.Zone = 1;
            typeGoToZone.PositionX = 3;
            typeGoToZone.PositionY = 4;
            typeGoToZone.PositionZ = 5;
        }

        [Test]
        public void Objective_talk_to_PNJ_returns_informations()
        {
            TypeTalkToPNJ typeTalkToPNJ = new TypeTalkToPNJ("Test");
            ObjectiveController oc = new ObjectiveController(1, "Try something", "Try talktopnj", typeTalkToPNJ, false);

            Assert.That(oc.ObjectiveName == "Try something");
            Assert.That(oc.ObjectiveDescription == "Try talktopnj");
            Assert.That(oc.TypeTalkToPNJ == typeTalkToPNJ);
            Assert.That(oc.IsComplete == false); 
        }
    }
}
