using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using System.Runtime.Serialization.Json;

using System.IO;
using SimpleJSON;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Assets.Scripts.Quest;

namespace LostTimeGame.Tests.QuestSystemTests.JsonParser
{
    [TestFixture]
    class QuestJsonParserTests
    {
        [Test]
        public void Read_JSON_file()
        {
            //Read JSON from a file

            using (StreamReader reader = File.OpenText(@"..\..\QuestSystemTests\JsonParser\QuestTest.json"))
            {
                JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));

                QuestController quest1 = new QuestController((int)o["Quest"][0]["1"]["QuestID"], (string)o["Quest"][0]["1"]["QuestName"],(string)o["Quest"][0]["1"]["QuestDescription"], (bool)o["Quest"][0]["1"]["QuestIsComplete"]);

                Assert.That(quest1.QuestID == 1);
                Assert.That(quest1.QuestName == "Tutorial");
                Assert.That(quest1.QuestDescription == "Prise en main du jeu et d'astrid");
                Assert.That(quest1.QuestIsComplete == false);
            }
        }

        [Test]
        public void Read_JSON_with_SimpleJSON()
        {
            using (StreamReader reader = File.OpenText(@"..\..\QuestSystemTests\JsonParser\QuestTest.json"))
            {
                string jsonString = reader.ReadToEnd();
                var N = JSON.Parse(jsonString);

                Assert.That(N["Quest"][0]["1"]["QuestID"].Value == "1");
            }
        }

        /*
        Cannot run, unity behavior block
        [Test]
        public void Read_and_create_quest_from_JSON_with_SimpleJSON()
        {
            using (StreamReader reader = File.OpenText(@"..\..\QuestSystemTests\JsonParser\QuestTest.json"))
            {
                string jsonString = reader.ReadToEnd();
                var N = JSON.Parse(jsonString);

                QuestManager QM = new QuestManager();
                QM.InitializeQuest(1);

            }
        }*/
    }
}
