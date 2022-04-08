using FinalProjectWebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestingUserWebApi.IntegrationTest
{
     class BasicTest : IClassFixture<FinalProjectWebApi.Startup>
     {
        private readonly WebApplicationFactory<FinalProjectWebApi.Startup> _factory;

        public void BasicTests(WebApplicationFactory<FinalProjectWebApi.Startup> factory)
        {
            factory = _factory;
        }

        [Theory]            
        [InlineData("api/AddUser/")]
        [InlineData("api/Login/")]

        public async Task Post_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equals("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());            
        }
     }
}
