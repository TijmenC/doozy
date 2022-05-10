using LobbyMicroservice;
using System;
using Xunit;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using LobbyMicroservice.Models;

namespace LobbyMicroserviceTests
{
    public class LobbyControllerTests : IClassFixture<LobbyMicroserviceFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly LobbyMicroserviceFactory<Startup> _factory;
        public LobbyControllerTests(
        LobbyMicroserviceFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }
        [Fact]
        public async Task Get_Request_Should_Return_Ok_One()
        {
            var response = await _client.GetAsync("api/profile/1");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Get_Request_Should_Return_Ok_All()
        {
            var response = await _client.GetAsync("api/profile/");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Get_Request_Wrong_ID()
        {
            var response = await _client.GetAsync("api/profile/8");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        /*
        [Fact]
        public async Task Delete_Succeed_Question()
        {
            var response = await _client.DeleteAsync("api/profile/2");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Post_Succeed_Question()
        {
            var response = await _client.PostAsync("api/profile", new StringContent(JsonConvert.SerializeObject(new User()
            {
                Id = 10,
                UserName = "Jewel",
                DisplayName = "Jewel4Kool",
                Email = "Jewel@gmail.com",
                DateOfBirth = new DateTime(2001, 12, 25)
            }), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
        [Fact]
        public async Task Put_Succeed_Question()
        {
            var response = await _client.PutAsync("api/Question/3", new StringContent(JsonConvert.SerializeObject(new User()
            {
                Id = 3,
                Title = "title changed",
                Description = "description changed",
                Tag = "Relationship changed",
                CommentsEnabled = false,
                Image = "imagechanged.png",
                DeletionTime = new DateTime(2020, 12, 22)
            }), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
        */

    }
}
