using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ContactZone.Api.Controllers;
using ContactZone.Application.Services;
using Moq;
using ContactZone.Domain.Domains;

namespace ContactZone.Tests.Api
{
    public class ContactControllerActionResultTestPost
    {
        private readonly Mock<IContactService> _mockContactService;
        private readonly Mock<IContactPersonalDataService> _mockContactPersonalDataService;
        private readonly ContactController _controller;

        public ContactControllerActionResultTestPost()
        {
            // Criando mocks dos serviços
            _mockContactService = new Mock<IContactService>();
            _mockContactPersonalDataService = new Mock<IContactPersonalDataService>();

            // Instanciando o controlador com os mocks
            _controller = new ContactController(_mockContactService.Object, _mockContactPersonalDataService.Object);
        }

        [Fact]
        public async Task Create_ValidDto_ReturnsCreatedAtAction()
        {
            // Arrange
            var validDto = new PostContactAndPersonalDataDto
            {
                Name = "Valid Name",
                DDD = "11",
                Phone = "12345678",
                Email = "valid@email.com"
            };

            // Mockando o serviço para aceitar a criação de um contato
            _mockContactService
                .Setup(service => service.AddAsync(It.IsAny<ContactDomain>()))
                .Returns(Task.CompletedTask); // Simulando uma tarefa completa

            _mockContactPersonalDataService
                .Setup(service => service.AddAsync(It.IsAny<ContactPersonalDataDomain>()))
                .Returns(Task.CompletedTask); // Simulando uma tarefa completa

            // Act
            var result = await _controller.Create(validDto);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result); // Verifica se o resultado é 201 Created
            Assert.Equal(201, createdResult.StatusCode); // Verifica se o status é 201
        }
    }
}
