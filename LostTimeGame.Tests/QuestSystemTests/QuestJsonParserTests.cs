using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

using System.IO;
using SimpleJSON;

namespace LostTimeGame.Tests.QuestSystemTests.JsonParser
{
    [TestFixture]
    class QuestJsonParserTests
    {
        [Test]
        public void Read_JSON_file()
        {
            //Theoretical test
            string[] n = System.IO.File.ReadAllLines(@"..\..\QuestSystemTests\JsonParser\QuestTest.json");
            Console.WriteLine(n);
        }
    }
}
