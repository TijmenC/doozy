using PostsMicroservice;
using System;
using System.Net.Http;
using Xunit;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PostsMicroservice.Models;

namespace PostsMicroserviceTests
{
    public class PostsControllerTests
    {
        public class LobbyControllerTests : IClassFixture<PostsMicroserviceFactory<Startup>>
        {
            private readonly HttpClient _client;
            private readonly PostsMicroserviceFactory<Startup> _factory;
            public LobbyControllerTests(
            PostsMicroserviceFactory<Startup> factory)
            {
                _factory = factory;
                _client = factory.CreateClient();
            }
            [Fact]
            public async Task Get_Request_Should_Return_Ok_One()
            {
                var response = await _client.GetAsync("api/post/1");

                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
            [Fact]
            public async Task Get_Request_Should_Return_Ok_All()
            {
                var response = await _client.GetAsync("api/post/");

                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
            [Fact]
            public async Task Get_Request_Wrong_ID()
            {
                var response = await _client.GetAsync("api/post/8");

                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }
            [Fact]
            public async Task Delete_Succeed_Post()
            {
                var response = await _client.DeleteAsync("api/post/2");

                response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            }

            [Fact]
            public async Task Post_Succeed_Post()
            {
                var response = await _client.PostAsync("api/post", new StringContent(JsonConvert.SerializeObject(new Post()
                {
                    UserId = 0,
                    Title = "Drank so much!",
                    Description = "Doozy",
                    AmountDrank = 8,
                    DrinkType = DrinkType.Beer
                }), Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();

                response.StatusCode.Should().Be(HttpStatusCode.Created);
            }
            [Fact]
            public async Task Put_Succeed_Post()
            {
                var response = await _client.PutAsync("api/Profile/3", new StringContent(JsonConvert.SerializeObject(new Post()
                {
                    Id = 3,
                    UserId = 0,
                    Title = "Drank so much!",
                    Description = "Doozy",
                    AmountDrank = 8,
                    DrinkType = DrinkType.Beer
                }), Encoding.UTF8, "application/json"));

                response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            }
        }
    }
}
