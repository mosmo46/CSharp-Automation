using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using System.Xml;
using TestAutomationCourse.Demos.d04.Serialization;

namespace TestAutomationCourse.Exercises.e06.combo
{
    public class ComboTests
    {

        // test 1
        // load the beatles xml
        // load the beatles json
        // prove that paul plays bass in both of them

        public string json = File.ReadAllText(".//Exercises//e05.JSON//Beatles.json");
        public Album album;
        public XmlDocument xmlDoc = new XmlDocument();
        public XmlElement root_element;
        [SetUp]
        public void Setup()
        {
            album = JsonConvert.DeserializeObject<Album>(json);
            xmlDoc.Load(@"C:\Users\User\OneDrive\Moshe Yaso Work\C#Projects\CSharp-Automation\TestAutomationCourse\Exercises\e04.XML\Beatles.xml");
            root_element = xmlDoc.DocumentElement;
        }

        [Test]
        public void Root_element_is_Beatles()
        {
            //  Assert.That(album, Is.EqualTo("Beatles"));
            Assert.That(root_element.Name, Is.EqualTo("Beatles"));
        }

        [Test]
        public void CheckThereAreTheSameMusicians()
        {
            var count = root_element.GetElementsByTagName("Artist").Count;
          
            bool sameMusicians = false;
            var artistsFromXml = root_element.GetElementsByTagName("Artist");
            for (int i = 0; i < count; i++)
            {
                var artistsFromJson = album.beatles.artists[i].name;
          
                foreach (XmlElement artist in artistsFromXml)
                {
                    if (artist.Attributes["name"].Value == artistsFromJson)
                    {
                        sameMusicians = true;break;

                    }

                }
              
            }
            Assert.That(sameMusicians, Is.True);

        }

        [Test]

        public void PlaySameInstrument()
        {
            var count = root_element.GetElementsByTagName("Artist").Count;

            bool sameInstrument = false;

            for (int i = 0; i < count; i++)
            {
            var InstrumentFromJson = album.beatles.artists[i].plays;
            var InstrumentFromXml = root_element.GetElementsByTagName("Plays").Item(i).InnerText;
            if (InstrumentFromJson == InstrumentFromXml)
            {
                sameInstrument = true; break;
            }
            }
            Assert.That(sameInstrument, Is.True);
        }

        public void HowManyDeadAndLivingArtistsThereAre()
        {

        }

        // test 2
        // create a data object for the MCU
        // MCU includes films
        // Each film has a name and a series counter (Captain America: The Winter Soldier is 2)
        // Each film has super-heroes in it (could be more than one)

        //Create data objects
        //Load the following data objects as follows:
        // "Thor" -> Thor
        // "Captain America - The First Avenger" -> Cap
        // "Black Widow" -> Black Widow
        // "Avengers" -> Thor, Cap, Black Widow, Hawekeye, Hulk, Iron Man

    // Create the JSON String using ObjectMapper.writeValue()
    // Prove that the JSON String contains the all the names of the super heroes
    // Prove that Ant-Man was not in Avengers

}

}
