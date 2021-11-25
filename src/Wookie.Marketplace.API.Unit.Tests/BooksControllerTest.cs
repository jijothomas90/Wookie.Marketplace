using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wookie.Marketplace.API.Models;
using Xunit;

namespace Wookie.Marketplace.API.Unit.Tests
{
    //Methods for Unit testing
    public class BooksControllerTest
    {
        private readonly HttpClient httpClient;
        public BooksControllerTest()
        {
            var server = new TestServer(new WebHostBuilder().
                UseStartup<Startup>());
            httpClient = server.CreateClient();
        }

        [Fact]
        public async Task GetAllTest()
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/books");

            //Act
            var response = await httpClient.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task GetTestbyId()
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "api/books/1");

            //Act
            var response = await httpClient.SendAsync(request);

            //Asert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var book = JsonConvert.DeserializeObject<Book>(await response.Content.ReadAsStringAsync());

            Assert.IsType<Book>(book);
            Assert.NotEmpty(book.Title);
        }

        [Fact]
        public async Task AddBook_SuccessTest()
        {
            var book = new Book()
            {
                Title = "Da Vinci Code",
                Description = "The Da Vinci Code is a 2003 mystery thriller novel by Dan Brown.",
                Author = "Dan Brown",
                Price = 900.00m
            };

            var jsonData = JsonConvert.SerializeObject(book);

            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/books")
            {
                Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
            };

            //Act
            var response = await httpClient.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task AddBook_BadRequestTest()
        {
            var book = new Book()
            {
                Description = "One of the most dynamic and globally recognized entertainment " +
                "forces of our time opens up fully about his life, in a brave and inspiring book that traces his learning curve to a place where outer success",
                Author = " Will Smith",
                Price = 700.00m
            };

            var jsonData = JsonConvert.SerializeObject(book);

            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/books")
            {
                Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
            };

            //Act
            var response = await httpClient.SendAsync(request);

            //Asert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdateBook_SuccessTest()
        {

            var book = new Book()
            {
                Title = "The Alchemist1",
                Description = "The Alchemist is a novel by Brazilian author Paulo Coelho that was first published in 1988.",
                Author = "Paulo Coelho",
                Price = 280.00m
            };

            var jsonData = JsonConvert.SerializeObject(book);

            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Put, "/api/books/1")
            {
                Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
            };

            //Act
            var response = await httpClient.SendAsync(request);

            //Asert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task UpdateBook_BadRequestTest()
        {
            var book = new Book()
            {
                Description = "The Alchemist is a novel by Brazilian author Paulo Coelho that was first published in 1988.",
                Author = "Paulo Coelho",
                Price = 280.00m
            };

            var jsonData = JsonConvert.SerializeObject(book);

            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Put, "/api/books/1")
            {
                Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
            };

            //Act
            var response = await httpClient.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task DeleteBook_SuccessTest()
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Delete, "/api/books/2");
            
            //Act
            var response = await httpClient.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

    }
}
