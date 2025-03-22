using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using TCFiapProducerCreateContact.Application.Inputs;

namespace TCFiapProducerCreateContact.Tests.IntegrationTests
{
    [TestFixture]
    public class ContactsControllerTests
    {
        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            var projectDir = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory,
                "../../../../TCFiapProducerCreateContact.API"));

            _factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.UseContentRoot(projectDir);
                });

            _client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [Test]
        public async Task Post_ShouldReturnAccepted()
        {
            // Arrange
            var contactInput = new CreateContactInputModel
            {
                Email = "fiap@gmail.com",
                FirstName = "fiap",
                LastName = "postech",
                DDD = 81,
                Phone = 991540124
            };

            // Act
            var response = await _client.PostAsJsonAsync("/Contacts", contactInput);

            // Assert
            Assert.AreEqual(HttpStatusCode.Accepted, response.StatusCode);
        }

        [Test]
        public async Task Put_ShouldReturnBadrequest()
        {
            // Arrange
            var updateInput = new UpdateContactInputModel
            {
                Email = "fiap2@gmail.com",
                FirstName = "fiap2",
                LastName = "postech2",
                DDD = 28,
                Phone = 926492624
            };

            // Act
            var response = await _client.PutAsJsonAsync("/Contacts", updateInput);

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public async Task Delete_ShouldReturnAccepted()
        {
            // Arrange
            var contactId = Guid.NewGuid(); 

            // Act
            var response = await _client.DeleteAsync($"/Contacts/{contactId}");

            // Assert
            Assert.AreEqual(HttpStatusCode.Accepted, response.StatusCode);
        }
    }
}