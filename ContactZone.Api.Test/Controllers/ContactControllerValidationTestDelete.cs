using ContactZone.Api.Controllers;
using ContactZone.Application.Services;
using ContactZone.Domain.Domains;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ContactZone.Tests.Api
{
    public class ContactControllerValidationTestDelete
    {
        private readonly ContactController _controller;
        private readonly Mock<IContactService> _contactServiceMock;

        public ContactControllerValidationTestDelete()
        {
            _contactServiceMock = new Mock<IContactService>();
            _controller = new ContactController(_contactServiceMock.Object);
        }

        [Fact]
        public async Task Delete_NonExistentId_ReturnsNotFound()
        {
            // Arrange
            int nonExistentId = 99; // ID que não existe

            _contactServiceMock.Setup(s => s.GetByIdAsync(nonExistentId))
                .ReturnsAsync((ContactDomain)null); // Simula que o contato não foi encontrado

            // Act
            var result = await _controller.Delete(nonExistentId);

            // Assert
            Assert.IsType<NotFoundResult>(result); // Verifica se o resultado é NotFound
        }
    }
}
