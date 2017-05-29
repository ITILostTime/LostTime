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
    }
}
