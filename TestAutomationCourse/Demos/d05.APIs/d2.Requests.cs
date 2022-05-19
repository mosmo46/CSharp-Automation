using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestAutomationCourse.Demos.d05.APIs
{
    [TestFixture]
    internal class Requests
    {
        [Test]
        public async Task Get_call_with_query_parameter()
        {
            RestClient client = new RestClient("http://jsonplaceholder.typicode.com/posts");
            RestRequest request = new RestRequest();
            request.AddQueryParameter("userId", 1);

            var response = await client.GetAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Get_call_with_path_parameter()
        {
            RestClient client =
                new RestClient("http://jsonplaceholder.typicode.com/");
            RestRequest request = new RestRequest("posts/{userId}");
            request.AddUrlSegment("userId", 1);

            var response = await client.GetAsync(request);

            JObject body = JObject.Parse(response.Content);
            string user_id_value = (string)body["userId"];
            Assert.That(user_id_value, Is.EqualTo("1"));
        }

        [Test]
        public async Task Post_with_json_body()
        {
            string newPost = @"{
                                'title':'gil-test',
                                'body': 'bar',
                                'userId': 1
                                }";

            RestClient client =
                new RestClient("http://jsonplaceholder.typicode.com/posts");
            RestRequest request = new RestRequest();

            request.AddParameter("application/json", newPost, 
                ParameterType.RequestBody);
            var response = await client.PostAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
    }
}
