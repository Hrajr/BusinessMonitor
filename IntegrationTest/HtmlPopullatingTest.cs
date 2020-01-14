using AngleSharp.Html.Dom;
using FluentAssertions;
using Logic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Project.IntegrationTest
{
    public class HtmlPopullatingTest
    {
        [Fact]
        public async Task Get_All_Invoices()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/Invoice");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task Get_All_References()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/Reference");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task Get_All_Items()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/Item");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task Post_New_Item()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("/Item/TestSave", new StringContent(JsonConvert.SerializeObject(new Item()
                {
                    ProductName = "TestProduct",
                    Description = "Product IntegrationTest",
                    Amount = 2,
                    VAT = 21,
                    Price = 15.60m,
                    InStock = true
                })));

                response.EnsureSuccessStatusCode();

                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task Delete_Item()
        {
            using (HttpClient _client = new TestClientProvider().Client)
            {
                // Arrange
                var ItemPage = await _client.GetAsync("/AddItem");
                var content = await HtmlHelper.GetDocumentAsync(ItemPage);

                //Act
                var response = await _client.SendAsync(
                    (IHtmlFormElement)content.QuerySelector("form[id='AddItem']"),
                    (IHtmlButtonElement)content.QuerySelector("button[id='btnAddItem']"));

                // Assert
                Assert.Equal(HttpStatusCode.OK, ItemPage.StatusCode);
            }
        }
    }
}
