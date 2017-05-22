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
    public class QuestInformations
    {
        /// <summary>
        /// QuestController takes arguments (int questID, string questName, string questDescription, string questDialogue)
        /// Test works
        /// </summary>
        [Test]
        public void Create_basic_quest_informations()
        {
            IQuest iQuest = new QuestController(1, "Tutoriel", "Vérifier que le test passe", "Hello, je m'appelle Juju");
            IQuest quest2 = new QuestController(2, "Au secours des poulets mécanique", "Julie a perdu ces poulets aide-là à les récupérer", "J'ai perdu mes poulets, aide moi !");
        }
    }
}
