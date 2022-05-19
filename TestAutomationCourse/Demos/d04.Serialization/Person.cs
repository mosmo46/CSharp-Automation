using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestAutomationCourse.Demos.d04.Serialization
{
    public class Person
    {
        [XmlElement]
        public string FirstName;
        [XmlElement]
        public string SurName;
        [XmlElement]
        public Children Children;
    }

    public class Children
    {
        [XmlElement]
        public List<Child> Child;
    }

    public class Child
    {
        [XmlAttribute]
        public string name;
    }
}
