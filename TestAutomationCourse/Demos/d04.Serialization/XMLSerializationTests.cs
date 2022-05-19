using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;
using TestAutomationCourse.Demos.d02.XML;

namespace TestAutomationCourse.Demos.d04.Serialization
{
    [TestFixture]
    internal class XMLSerializationTests
    {
        [Test]
        public void First_name_is_joe()
        {
            XmlSerializer serializer =
                 new XmlSerializer(typeof(Person));

            Person person;

            using (TextReader reader = new StringReader(XMLExamples.GetPersonXML()))
            {
                person = (Person)serializer.Deserialize(reader);
            }
            Assert.That(person.FirstName, Is.EqualTo("Joe"));
        }

        [Test]
        public void Joe_has_three_children()
        {

        }

        [Test]
        public void Second_child_name_is_jim()
        {

        }
    }


}