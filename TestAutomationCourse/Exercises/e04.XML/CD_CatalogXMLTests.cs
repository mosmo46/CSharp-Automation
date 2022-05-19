using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TestAutomationCourse.Exercises.e04.XML
{
    internal class CD_CatalogXMLTests
    {
        public XmlDocument doc;

        [SetUp]
        public void Setup()
        {
            doc = new XmlDocument();
            doc.Load(@"C:\Users\User\source\repos\CSharp-Automation\TestAutomationCourse\Exercises\e04.XML\CD_Catalog.xml");
        }

        [Test]
        public void test()
        {
            XmlElement root_element = doc.DocumentElement;

            Assert.That(root_element.Name, Is.EqualTo("CATALOG"));
        }

        [Test]
        public void CDFromUSA()
        {
            XmlElement root_element = doc.DocumentElement;
            var count = root_element.GetElementsByTagName("COUNTRY").Count;
            List<string> conFromUsa = new List<string>();
            for (int i = 0; i < count; i++)
            {
                var country = root_element.GetElementsByTagName("COUNTRY").Item(i).InnerText;

               if (country.Equals("USA"))
                {
                    conFromUsa.Add(root_element.GetElementsByTagName("TITLE").Item(i).InnerText);
                }
            }
          //  conFromUsa.Sort();
            foreach (string node in conFromUsa)
            {
                Console.WriteLine(node);
            }

            Assert.That(conFromUsa.Count, Is.EqualTo(7));
        }

        [Test]

        public void ConnectingAllCDPrices()
        {
            XmlElement root_element = doc.DocumentElement;
            var countLength = root_element.GetElementsByTagName("PRICE").Count;
            float prices = 0;
            for (int i = 0; i < countLength; i++)
            {
                prices += float.Parse(root_element.GetElementsByTagName("PRICE").Item(i).InnerText);
            }
            Assert.That (prices, Is.EqualTo(236).Within(1));
        }

        [Test]

        public void ConnectingAllCDPricesOlderThan1987()
        {
            XmlElement root_element = doc.DocumentElement;
            var countLength = root_element.GetElementsByTagName("YEAR").Count;
            float prices = 0;
            for (int i = 0; i < countLength; i++)
            {
               int year =  int.Parse(root_element.GetElementsByTagName("YEAR").Item(i).InnerText);
                if (year < 1987)
                {
                    prices += float.Parse(root_element.GetElementsByTagName("PRICE").Item(i).InnerText);
                }
            }
            Assert.That(prices, Is.EqualTo(68).Within(1));
        }



    }
}
