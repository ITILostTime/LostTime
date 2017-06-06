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
            /*JObject quest1 = JObject.Parse(File.ReadAllText(@"..\..\QuestSystemTests\JsonParser\QuestTest.json"));

            using (StreamReader file = File.OpenText(@"..\..\QuestSystemTests\JsonParser\QuestTest.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject quest2 = (JObject)JToken.ReadFrom(reader);
            }*/

            //Deserialize JSON 
            /*QuestController quest1 = JsonConvert.DeserializeObject<QuestController>(File.ReadAllText(@"..\..\QuestSystemTests\JsonParser\QuestTest.json"));

            using (StreamReader file = File.OpenText(@"..\..\QuestSystemTests\JsonParser\QuestTest.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                QuestController quest2 = (QuestController)serializer.Deserialize(file, typeof(QuestController));
            }*/

            //Theoretical test
            /*string[] n = System.IO.File.ReadAllLines(@"..\..\QuestSystemTests\JsonParser\QuestTest.json");
            Console.WriteLine(n);

            string[] o = System.IO.File.ReadAllLines(@"..\..\QuestSystemTests\JsonParser\QuestTest1.json");
            Console.WriteLine(o);*/
        }
    }
}
