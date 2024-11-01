using ContactZone.Api.Controllers;
using ContactZone.Application.Services;
using ContactZone.Domain.Domains;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ContactZone.Tests.Api
{
    public class ContactControllerActionResultTestGetById
    {
        private readonly ContactController _controller;
        private readonly Mock<IContactService> _contactServiceMock;

        public ContactControllerActionResultTestGetById()
        {
            _contactServiceMock = new Mock<IContactService>();
            _controller = new ContactController(_contactServiceMock.Object);
        }

        [Fact]
        public async Task GetById_ValidId_ReturnsOk()
        {
            // Arrange
            int validId = 1; // ID válido
            var expectedContact = new ContactDomain { Id = validId, Name = "John Doe" };

            _contactServiceMock.Setup(s => s.GetByIdAsync(validId))
                .ReturnsAsync(expectedContact);

            // Act
            var result = await _controller.GetById(validId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var contact = Assert.IsType<ContactDomain>(okResult.Value);
            Assert.Equal(expectedContact.Id, contact.Id); // Verifica se o ID do contato retornado é o esperado
        }

        [Fact]
        public async Task GetById_NonExistentId_ReturnsNotFound()
        {
            // Arrange
            int nonExistentId = 99; // ID que não existe

            _contactServiceMock.Setup(s => s.GetByIdAsync(nonExistentId))
                .ReturnsAsync((ContactDomain)null); // Simula que o contato não foi encontrado

            // Act
            var result = await _controller.GetById(nonExistentId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
