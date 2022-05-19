using NUnit.Framework;
using System.Xml;

namespace TestAutomationCourse.Demos.d02.XML
{
    [TestFixture]
    internal class PersonXMLTests
    {
        [Test]
        public void Root_element_is_person()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(XMLExamples.GetPersonXML());
            XmlElement root_element = xmlDoc.DocumentElement;

            Assert.That(root_element.Name, Is.EqualTo("Person"));
        }

        [Test]
        public void First_name_is_joe()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(XMLExamples.GetPersonXML());
            XmlElement root_element = xmlDoc.DocumentElement;

            XmlNode firstNameNode = root_element.GetElementsByTagName("FirstName").Item(0);
            string firstNameTag = firstNameNode.Name;
            string firstName = firstNameNode.InnerText;
            Assert.That(firstNameTag, Is.EqualTo("FirstName"));
            Assert.That(firstName, Is.EqualTo("Joe"));

        }

        [Test]
        public void Joe_has_three_children()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(XMLExamples.GetPersonXML());
            XmlElement root_element = xmlDoc.DocumentElement;

            int num_of_children = root_element.GetElementsByTagName("Child").Count;
            Assert.That(num_of_children, Is.EqualTo(3));
        }

        [Test]
        public void Second_child_name_is_jim()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(XMLExamples.GetPersonXML());
            XmlElement root_element = xmlDoc.DocumentElement;

            var second_child_element = root_element.GetElementsByTagName("Child").Item(1);
            XmlNode name_attribute = second_child_element.Attributes.Item(0);
            string child_name = name_attribute.InnerText;
            Assert.That(child_name, Is.EqualTo("Jim"));
        }
    }
}
