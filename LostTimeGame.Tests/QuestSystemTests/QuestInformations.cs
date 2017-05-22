using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assets.Scripts.Quest;

namespace LostTimeGame.Tests.QuestSystemTests
{
    [TestFixture]
    public class QuestInformations
    {
        /// <summary>
        /// QuestController takes arguments (int questID, string questName, string questDescription, string questDialogue)
        /// </summary>
        [Test]
        public void Create_basic_quest_informations()
        {
            QuestController questController = new QuestController(1, "Tutoriel", "Vérifier que le test passe", "Hello, je m'appelle Juju");

            Assert.That(questController.QuestID == 1);
        }
    }
}
