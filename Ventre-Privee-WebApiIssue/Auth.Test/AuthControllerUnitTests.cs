using Auth.Core;
using Auth.Infrastructure;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Auth.WebApi.Controllers;
using Xunit;

namespace Auth.Test
{
    public class AuthControllerUnitTests
    {
        [Fact]
        public async Task Auth_AuthenticationWithCorrectParameters_shouldReturnTrue()
        {
            var controller = new AuthController(new UserRepo());
            User mycreds = new User("hh.mm@gmail.com", "ddlo252");

            var result = await controller.Authenticate(mycreds);
            bool personExist = Convert.ToBoolean(((ObjectResult)result).Value);
            // Assert
            personExist.Should().Be(true);
        }

        [Fact]
        public async Task Auth_AuthenticationWithInCorrectParameters_shouldReturnFalse()
        {
            var controller = new AuthController(new UserRepo());
            User mycreds = new User("hh.mm@gmail.commmmmm", "ddlo252");

            var result = await controller.Authenticate(mycreds);
            bool personExist = Convert.ToBoolean(((ObjectResult)result).Value);
            // Assert
            personExist.Should().Be(false);
        }

        [Fact]
        public async Task Auth_ConfidentialsWithCorrectParameters_shouldReturnTrue()
        {
            var controller = new AuthController(new UserRepo());
            string email = "hh.mm@gmail.com";
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Request.Headers.Add("Authorization", String.Format("VP {0}:{1}_{2}_{3}", "AKIAIOSFODNN7EXAMPLE", "GET","application/json", DateTime.Now.ToString("ddMMYYYY")));
            controller.HttpContext.Request.ContentType = "application/json";

            var result = await controller.Confidentials(email);
            bool personExist = Convert.ToBoolean(((ObjectResult)result).Value);
            // Assert
            personExist.Should().Be(true);
        }
    }
}
