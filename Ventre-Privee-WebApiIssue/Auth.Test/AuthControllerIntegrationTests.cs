using Auth.Core;
using Auth.Infrastructure;
using Auth.WebApi;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Auth.Test
{
    public class AuthControllerIntegrationTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public AuthControllerIntegrationTests()
        {

            // Arrange
            _server = new TestServer(new WebHostBuilder()
                                     .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Auth_AuthenticationWithCorrectParameters_shouldReturnTrue()
        {
            User mycreds = new User("hh.mm@gmail.com", "ddlo252");

            var json = JsonConvert.SerializeObject(mycreds);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await _client.PostAsync("Auth/api/authenticate", stringContent);

            response.EnsureSuccessStatusCode();
            var result =  await response.Content.ReadAsStringAsync();
            bool personExist = Convert.ToBoolean(result);

            personExist.Should().Be(true);
        }

        [Fact]
        public async Task Auth_AuthenticationWithInCorrectParameters_shouldReturnFalse()
        {
            User mycreds = new User("hh.mm@gmaillll.com", "ddlo252");

            var json = JsonConvert.SerializeObject(mycreds);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await _client.PostAsync("Auth/api/authenticate", stringContent);

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            bool personExist = Convert.ToBoolean(result);

            personExist.Should().Be(false);
        }
    }
}
