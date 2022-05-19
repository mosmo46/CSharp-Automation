using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

namespace TestAutomationCourse.Demos.d04.Serialization
{
    [TestFixture]
    internal class JSONSerializationTests
    {
           public string json = File.ReadAllText(".//Exercises//e05.JSON//Beatles.json");
           public Album album;
      [SetUp]
        public void Setup()
        {
            album = JsonConvert.DeserializeObject<Album>(json);
        }

        [Test]
        public void There_are_four_artists()
        {
            Assert.That(album.beatles.artists.Length, Is.EqualTo(4));
        }

        [Test]
        public void Two_are_dead_and_two_are_alive()
        {
            var count = album.beatles.artists.Length;
            var alive = 0;
            var dead = 0;
            for (int i = 0; i < count; i++)
            {
            var isAlive = album.beatles.artists[i].isAlive;
            if (isAlive.Equals("Yes"))
            {
                alive++;
            }
            else
            {
                dead++;
            }
            }

            Assert.That(alive, Is.EqualTo(2));
            Assert.That(dead, Is.EqualTo(2));
        }

        [Test]
        public void Ringo_plays_drums()
        {

            var count = album.beatles.artists.Length;
            string plays = "";
            for (int i = 0; i < count; i++)
            {
                var name = album.beatles.artists[i].name;

                if (name.Equals("Ringo Starr"))
                {
                     plays = album.beatles.artists[i].plays;
                }

            }
            Assert.That(count, Is.EqualTo(4));
            Assert.That(plays, Is.EqualTo("Drums"));
        }


    }
}
