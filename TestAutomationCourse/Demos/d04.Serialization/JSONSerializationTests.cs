using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

namespace TestAutomationCourse.Demos.d04.Serialization
{
    [TestFixture]
    internal class JSONSerializationTests
    {
        [Test]
        public void There_are_four_artists()
        {
            string json = File.ReadAllText(".//Exercises//e05.JSON//Beatles.json");
            Album album = JsonConvert.DeserializeObject<Album>
                (json);
            Assert.That(album.beatles.artists.Length, Is.EqualTo(4));
        }

        [Test]
        public void Two_are_dead_and_two_are_alive()
        {

        }

        [Test]
        public void Ringo_plays_drums()
        {

        }


    }
}
