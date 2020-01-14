using BusinessMonitor;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest
{
    public class BasicTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public BasicTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Invoice")]
        [InlineData("/Item")]
        [InlineData("/Reference")]
        [InlineData("/Registration")]
        [InlineData("/Login")]
        [InlineData("/NewInvoice")]
        [InlineData("/AddItem")]
        [InlineData("/AddReference")]
        [InlineData("/EditInvoice?id=Purchase%3A01%3A13%3A2020%3A20%3A37%3A57")]
        [InlineData("/EditItem?id=5C704287-C86E-4FC6-B307-44128CCEF36C")]
        [InlineData("/EditReference?id=5069609E-5383-4D86-8CFE-A7B8BFC38C38")]
        public async Task HttpRequest(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
