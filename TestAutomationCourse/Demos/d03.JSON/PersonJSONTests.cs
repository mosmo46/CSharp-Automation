using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;

namespace TestAutomationCourse.Demos.d03.JSON
{
    internal class PersonJSONTests
    {
        [Test]
        public void Root_element_is_person()
        {
            JObject json = JObject.Parse(JSONExamples.getPerson());
            var jsonPerson = json["Person"];
            Console.WriteLine(jsonPerson.ToString());
        }


        [Test]
        public void First_name_is_joe()
        {
            JObject json = JObject.Parse(JSONExamples.getPerson());
            var jsonPerson = json["Person"];
            string firstName = (string)jsonPerson["FirstName"];
            Assert.That(firstName, Is.EqualTo("Joe"));
        }

        [Test]
        public void Joe_has_three_children()
        {
            JObject json = JObject.Parse(JSONExamples.getPerson());
            var jsonPerson = json["Person"];
            JArray children = (JArray)jsonPerson["Children"];
            int num_of_children = children.Count;
            Assert.That(num_of_children, Is.EqualTo(3));
        }

        [Test]
        public void Second_child_name_is_jim()
        {
            JObject json = JObject.Parse(JSONExamples.getPerson());
            var jsonPerson = json["Person"];

            var second_child = jsonPerson["Children"][1];
            string child_name = (string) second_child["child"];
            Assert.That(child_name, Is.EqualTo("Jim")); 
    }
}
}
