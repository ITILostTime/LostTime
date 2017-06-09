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
    public class QuestInformationsTests
    {
        /// <summary>
        /// QuestController takes arguments (int questID, string questName, string questDescription, string questDialogue)
        /// Test works
        /// </summary>
        [Test]
        public void Create_basic_quest_informations()
        {
            QuestController quest = new QuestController(1, "Test", "Tutorial");

            Assert.That(quest.QuestID == 1);
            Assert.That(quest.QuestName == "Test");
            Assert.That(quest.QuestDescription == "Tutorial");
        }
    }
}
