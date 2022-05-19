using NUnit.Framework;
using RestSharp;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TestAutomationCourse.Demos.d05.APIs
{
    [TestFixture]
    internal class Serialization_Tests
    {
        [Test]
        public async Task Send_request_body_as_serialized_object()
        {
            Post newPost = new Post();
            newPost.title = "gil-test";
            newPost.body = "bar";
            newPost.userId = 1;

            RestClient client =
                new RestClient("http://jsonplaceholder.typicode.com/posts/");

            RestRequest request = new RestRequest();
            request.AddJsonBody(newPost);

            var response = await client.PostAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public async Task Get_response_as_deserialized_object()
        {
            RestClient client =
                new RestClient("http://jsonplaceholder.typicode.com/");

            RestRequest request = new RestRequest();
            var args = new { userId = 1 };

            var response_post = await client.GetJsonAsync<Post>("posts/{userId}", args);

            Assert.That(response_post.title, Does.Contain("sunt aut facere"));
        }
    }
}
