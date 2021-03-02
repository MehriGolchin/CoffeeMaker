using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CafeeMaker.Service.Dtos;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Linq;
using FluentAssertions;

namespace CafeeMaker.Web.Test.Integrations.Controllers {

    public class DrinkControllerTests : IClassFixture<CustomWebApplicationFactory> {
        
        private readonly HttpClient _httpClient;
        
        public DrinkControllerTests(CustomWebApplicationFactory webApplicationFactory) {
            _httpClient = webApplicationFactory.CreateClient(new WebApplicationFactoryClientOptions {
                AllowAutoRedirect = false
            });
        }
        
        [Fact]
        public async Task Should_return_a_list_of_drinks() {
            // logging into the system 
            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "EmployeeId", "100" },
            });
            var response = await _httpClient.PostAsync("/account/login", content);
            response.StatusCode.Should().Be(HttpStatusCode.Redirect);

            // getting the drink list
            var drinks = await _httpClient.GetFromJsonAsync<IEnumerable<DrinkDto>>("/api/drink");
            drinks.Should()
                .ContainEquivalentOf(new {DrinkId = 1, Name = "Thé", Image = "/img/tea1.png"}).And
                .ContainEquivalentOf(new {DrinkId = 2, Name = "Café", Image = "/img/coffee1.png"}).And
                .ContainEquivalentOf(new {DrinkId = 3, Name = "Chocolat", Image = "/img/chocolate1.png"});
        }

        [Fact]
        public async Task Should_return_a_list_of_Ingredients_by_drink_id() {
            // logging into the system 
            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "EmployeeId", "100" },
            });
            var response = await _httpClient.PostAsync("/account/login", content);
            response.StatusCode.Should().Be(HttpStatusCode.Redirect);

            var ingredients = await _httpClient.GetFromJsonAsync<IEnumerable<DrinkIngredientDto>>("/api/drink/1");
            ingredients.Should().HaveCount(3);
        }

    }

}