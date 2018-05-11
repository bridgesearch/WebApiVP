using Auth.Core;
using Auth.Infrastructure;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Ventre_Privee_WebApiIssue.Controllers;
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
    }
}
