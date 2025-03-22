using MassTransit;
using Moq;
using TCFiapProducerCreateContact.Application.Services.Implementation;
using TechChallenge.SDK.Infrastructure.Message;

namespace TCFiapProducerCreateContact.Tests.UnitTests.Services
{
    [TestFixture]
    public class RabbitMqClientTests
    {
        private Mock<IBus> _busMock;
        private Mock<ISendEndpoint> _sendEndpointMock;
        private RabbitMqClient _rabbitMqClient;

        [SetUp]
        public void Setup()
        {
            _busMock = new Mock<IBus>();
            _sendEndpointMock = new Mock<ISendEndpoint>();

            _busMock.Setup(b => b.GetSendEndpoint(It.IsAny<Uri>()))
                    .ReturnsAsync(_sendEndpointMock.Object);

            _rabbitMqClient = new RabbitMqClient(_busMock.Object);
        }

        [Test]
        public async Task PublicMessageCreateAsync_WhenCalled_ShouldSendMessageToCorrectQueue()
        {
            // Arrange
            var message = new CreateContactMessage("Ramon", "Dino", 11, 123456789, "ramon.dino@hotmail.com");
            var expectedUri = new Uri("queue:create-contact-queue");

            // Act
            await _rabbitMqClient.PublicMessageCreateAsync(message);

            // Assert
            _busMock.Verify(b => b.GetSendEndpoint(It.Is<Uri>(uri => uri == expectedUri)), Times.Once);
            _sendEndpointMock.Verify(s => s.Send(message, default), Times.Once);
        }

        [Test]
        public async Task PublicMessageUpdateAsync_WhenCalled_ShouldSendMessageToCorrectQueue()
        {
            // Arrange
            var message = new UpdateContactMessage(Guid.NewGuid(), "Jane", "Dino", 21, 987654321, "ramon.dino@hotmail.com");
            var expectedUri = new Uri("queue:update-contact-queue");

            // Act
            await _rabbitMqClient.PublicMessageUpdateAsync(message);

            // Assert
            _busMock.Verify(b => b.GetSendEndpoint(It.Is<Uri>(uri => uri == expectedUri)), Times.Once);
            _sendEndpointMock.Verify(s => s.Send(message, default), Times.Once);
        }

        [Test]
        public async Task PublicMessageDeleteAsync_WhenCalled_ShouldSendMessageToCorrectQueue()
        {
            // Arrange
            var message = new RemoveContactMessage { ContactId = Guid.NewGuid() };
            var expectedUri = new Uri("queue:delete-contact-queue");

            // Act
            await _rabbitMqClient.PublicMessageDeleteAsync(message);

            // Assert
            _busMock.Verify(b => b.GetSendEndpoint(It.Is<Uri>(uri => uri == expectedUri)), Times.Once);
            _sendEndpointMock.Verify(s => s.Send(message, default), Times.Once);
        }
    }
}