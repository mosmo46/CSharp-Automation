using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace TestAutomationCourse.Demos.d05.APIs
{
    [TestFixture]
    internal class Basic_API_Tests
    {
        [Test]
        public async Task Get_call_assert_status()
        {
            RestClient client = new RestClient("http://jsonplaceholder.typicode.com/");
            RestRequest request = new RestRequest("users/1");

            var response = await client.GetAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Get_call_assert_json()
        {
            RestClient client = new RestClient("http://jsonplaceholder.typicode.com/");
            RestRequest request = new RestRequest("users/1");

            var response = await client.GetAsync(request);

            string body = response.Content;
            Assert.That (body, Does.Contain("Leanne Graham"));
        }

        [Test]
        public async Task Get_call_and_assert_with_json_net()
        {
            RestClient client = new RestClient("http://jsonplaceholder.typicode.com/");
            RestRequest request = new RestRequest("users/1");

            var response = await client.GetAsync(request);
            JObject body = JObject.Parse(response.Content);

            string name_value = (string)body["name"];
            Assert.That(name_value, Is.EqualTo("Leanne Graham"));
        }

        [Test]
        public async Task Get_call_and_assert_returns_json()
        {
            RestClient client = new RestClient("http://jsonplaceholder.typicode.com/");
            RestRequest request = new RestRequest("users/1");

            var response = await client.GetAsync(request);

            Assert.That(response.ContentType, Is.EqualTo(@"application/json"));
        }
    }
}
