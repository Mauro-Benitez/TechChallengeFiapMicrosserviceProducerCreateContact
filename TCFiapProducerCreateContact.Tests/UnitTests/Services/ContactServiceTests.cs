using Moq;
using TCFiapProducerCreateContact.Application.Inputs;
using TCFiapProducerCreateContact.Application.Services;
using TCFiapProducerCreateContact.Application.Services.Implementation;
using TechChallenge.SDK.Infrastructure.Message;

namespace TCFiapProducerCreateContact.Tests.UnitTests.Services
{
    [TestFixture]
    public class ContactServiceTests
    {
        private Mock<IRabbitMqClient> _rabbitMqClientMock;
        private ContactService _contactService;

        [SetUp]
        public void Setup()
        {
            _rabbitMqClientMock = new Mock<IRabbitMqClient>();
            _contactService = new ContactService(_rabbitMqClientMock.Object);
        }

        [Test]
        public async Task CreateContactAsync_WithValidInput_ShouldInvokePublicMessageCreateAsyncWithCorrectMessage()
        {
            // Arrange
            var input = new CreateContactInputModel
            {
                FirstName = "Ramon",
                LastName = "Dino",
                DDD = 11,
                Phone = 123456789,
                Email = "ramon.dino@hotmail.com"
            };

            // Act
            await _contactService.CreateContactAsync(input);

            // Assert
            _rabbitMqClientMock.Verify(r =>
                    r.PublicMessageCreateAsync(It.Is<CreateContactMessage>(msg =>
                        msg.FirstName == input.FirstName &&
                        msg.LastName == input.LastName &&
                        msg.DDD == input.DDD &&
                        msg.Phone == input.Phone &&
                        msg.Email == input.Email
                    )),
                Times.Once);
        }

        [Test]
        public async Task UpdateContactAsync_WithValidInput_ShouldInvokePublicMessageUpdateAsyncWithCorrectMessage()
        {
            // Arrange
            var input = new UpdateContactInputModel
            {
                Id = Guid.NewGuid(),
                FirstName = "Ramon",
                LastName = "Dino",
                DDD = 21,
                Phone = 987654321,
                Email = "ramon.dino@hotmail.com"
            };

            // Act
            await _contactService.UpdateContactAsync(input);

            // Assert
            _rabbitMqClientMock.Verify(r =>
                    r.PublicMessageUpdateAsync(It.Is<UpdateContactMessage>(msg =>
                        msg.Id == input.Id &&
                        msg.FirstName == input.FirstName &&
                        msg.LastName == input.LastName &&
                        msg.DDD == input.DDD &&
                        msg.Phone == input.Phone &&
                        msg.Email == input.Email
                    )),
                Times.Once);
        }

        [Test]
        public async Task DeleteContactAsync_WithValidInput_ShouldInvokePublicMessageDeleteAsyncWithCorrectMessage()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            await _contactService.DeleteContactAsync(id);

            // Assert
            _rabbitMqClientMock.Verify(r =>
                    r.PublicMessageDeleteAsync(It.Is<RemoveContactMessage>(msg =>
                        msg.ContactId == id
                    )),
                Times.Once);
        }
    }
}