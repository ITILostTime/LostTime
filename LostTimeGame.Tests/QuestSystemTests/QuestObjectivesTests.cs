using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assets.Scripts.Quest.Interfaces;
using Assets.Scripts.Quest;

namespace LostTimeGame.Tests.QuestSystemTests
{
    [TestFixture]
    class QuestObjectivesTests
    {
        [Test]
        public void Create_basic_objectives_informations()
        {
            IQuestObjective objectives = new QuestLog(1, "Etape 1 : faire marcher Astrid", false);
        }
    }
}
