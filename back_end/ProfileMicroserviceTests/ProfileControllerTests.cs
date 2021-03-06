using ProfileMicroservice;
using System;
using Xunit;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using ProfileMicroservice.Models;

namespace ProfileMicroserviceTests
{
    public class ProfileControllerTests : IClassFixture<ProfileMicroserviceFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly ProfileMicroserviceFactory<Startup> _factory;
        public ProfileControllerTests(
        ProfileMicroserviceFactory<Startup> factory)
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
        [Fact]
        public async Task Delete_Succeed_User()
        {
            var response = await _client.DeleteAsync("api/profile/2");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Post_Succeed_User()
        {
            var response = await _client.PostAsync("api/profile/SaveProfile", new StringContent(JsonConvert.SerializeObject(new User()
            {
                UserName = "Jewel",
                DisplayName = "Jewel4Kool",
                Email = "Jewel@gmail.com",
                DateOfBirth = new DateTime(2001, 12, 25)
            }), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        [Fact]
        public async Task Put_Succeed_User()
        {
            var response = await _client.PutAsync("api/Profile/3", new StringContent(JsonConvert.SerializeObject(new User()
            {
                Id = 3,
                UserName = "Peter2",
                DisplayName = "Peter24Cool",
                Email = "Peter2@gmail.com",
                DateOfBirth = new DateTime(2001, 12, 25)
            }), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
