using System.Threading.Tasks;
using ContactZone.Api.Controllers;
using ContactZone.Api.DTOs;
using ContactZone.Application.Services;
using ContactZone.Domain.Domains;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ContactZone.Tests.Api
{
    public class ContactControllerActionResultTestUpdate
    {
        private readonly ContactController _controller;
        private readonly Mock<IContactService> _contactServiceMock;

        public ContactControllerActionResultTestUpdate()
        {
            _contactServiceMock = new Mock<IContactService>();
            _controller = new ContactController(_contactServiceMock.Object,null);
        }

        [Fact]
        public async Task Update_ValidId_UpdatesContact_ReturnsNoContent()
        {
            // Arrange
            int validId = 1; // ID válido
            var existingContact = new ContactDomain { Id = validId, Name = "Old Name" };
            var updatedDto = new PostContactDto { Name = "John Doe" };

            _contactServiceMock.Setup(s => s.GetByIdAsync(validId))
                .ReturnsAsync(existingContact); // Simula que o contato existe

            // Act
            var result = await _controller.Update(validId, updatedDto);

            // Assert
            Assert.IsType<NoContentResult>(result); // Verifica se o resultado é NoContent
            Assert.Equal("John Doe", existingContact.Name); // Verifica se o nome foi atualizado corretamente
        }

        [Fact]
        public async Task Update_NonExistentId_ReturnsNotFound()
        {
            // Arrange
            int nonExistentId = 99; // ID que não existe
            var validDto = new PostContactDto { Name = "John Doe" };

            _contactServiceMock.Setup(s => s.GetByIdAsync(nonExistentId))
                .ReturnsAsync((ContactDomain)null); // Simula que o contato não foi encontrado

            // Act
            var result = await _controller.Update(nonExistentId, validDto);

            // Assert
            Assert.IsType<NotFoundResult>(result); // Verifica se o resultado é NotFound
        }
    }
}
