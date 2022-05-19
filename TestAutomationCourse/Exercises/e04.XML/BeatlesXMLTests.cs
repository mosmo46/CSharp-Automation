using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.IO;
using System.Xml;

namespace TestAutomationCourse.Exercises.e04.Xml
{
    internal class BeatlesXMLTests
    {
        private JToken jsonBeatles;

        [SetUp]
        public void Setup()
        {
            using (var sr = new StreamReader(@"C:\Users\User\OneDrive\Moshe Yaso Work\C#Projects\CSharp-Automation\TestAutomationCourse\Exercises\e05.JSON\Beatles.json"))
            {
                var reader = new JsonTextReader(sr);
                jsonBeatles = JObject.Load(reader);
            }
        }

        [Test]
        public void There_are_four_artists()
        {
            JToken jsonBearle = jsonBeatles["Beatles"];
            JArray artistsList = (JArray)jsonBearle["Artists"];
            int count_artist = artistsList.Count;
            Assert.That(count_artist, Is.EqualTo(4));
        }

        [Test]
        public void two_are_dead_and_two_are_alive()
        {
            int yes = 0;
            int no = 0;
            JToken jsonBearle = jsonBeatles["Beatles"];
            var artistsList = (JArray)jsonBearle["Artists"];
            int count = artistsList.Count;
            for (int i = 0; i < count; i++)
            {
                var tmp = jsonBearle["Artists"][i];
                string isalive = (string)tmp["IsAlive"];
                if (isalive.Equals("No"))
                {
                    no++;
                }
                if (isalive.Equals("Yes"))
                {
                    yes++;
                }
            }
            Assert.That(yes, Is.EqualTo(2));
            Assert.That(no, Is.EqualTo(2));
        }


        [Test]
        public void ringo_plays_drums()
        {
            JToken jsonBearle = jsonBeatles["Beatles"];
            var artistsList = (JArray)jsonBearle["Artists"];

            foreach (var artist in artistsList)
            {
                var name = (string)artist["Name"];

                if (name.Equals("Ringo Starr"))
                {
                    var res = (string)artist["Plays"];
                    Assert.That(res, Is.EqualTo("Drums"));
                }

            }
           }
        }
}
