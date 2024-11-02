using ContactZone.Api.Controllers;
using ContactZone.Api.Dtos;
using ContactZone.Application.Services;
using ContactZone.Domain.Domains;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ContactZone.Api.Test.Controllers
{
    public class ContactControllerValidationTestGetByDDD
    {
        private readonly Mock<IContactService> _mockContactService;
        private readonly ContactController _controller;

        public ContactControllerValidationTestGetByDDD()
        {
            // Mockando o serviço de contatos
            _mockContactService = new Mock<IContactService>();

            // Instanciando o controlador com o serviço mockado
            _controller = new ContactController(_mockContactService.Object);
        }

        [Fact]
        public async Task GetAll_DDDIsZero_ReturnsContactsWithAnyDDD()
        {
            // Arrange
            var contacts = new List<ContactDomain>
            {
                new ContactDomain { Id = 1, Name = "Contact 1" },
                new ContactDomain { Id = 2, Name = "Contact 2"}
            };

            _mockContactService
                .Setup(service => service.GetContactWithAllInformation())
                .ReturnsAsync(contacts); // Simula o retorno de todos os contatos

            // Act
            var result = await _controller.GetAll(0);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedContacts = Assert.IsType<List<FilterByDDDDto>>(okResult.Value);
            Assert.Equal(contacts.Count, returnedContacts.Count); // Verifica se todos os contatos foram retornados
        }

        [Fact]
        public async Task GetAll_DDDIsNonZero_ReturnsContactsWithSpecificDDD()
        {
            // Arrange
            var ddd = 11;
            var filteredContacts = new List<ContactDomain>
            {
                new ContactDomain 
                { 
                    Id = 1, 
                    Name = "Contact 1",
                            DDD = "11",
                            Email = "teste@teste.com",
                            Phone = "999999999",
                }
            };

            _mockContactService
                .Setup(service => service.GetContactFilteringByDDD(ddd))
                .ReturnsAsync(filteredContacts); // Simula o retorno de contatos filtrados por DDD

            // Act
            var result = await _controller.GetAll(ddd);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedContacts = Assert.IsType<List<FilterByDDDDto>>(okResult.Value);
            Assert.Equal(filteredContacts.Count, returnedContacts.Count); // Verifica se apenas os contatos filtrados foram retornados
        }

        [Fact]
        public async Task GetAll_DDDIsNegative_ReturnsBadRequest()
        {
            // Arrange
            var negativeDDD = -1; // Um valor de DDD negativo

            // Act
            var result = await _controller.GetAll(negativeDDD);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("DDD cannot be negative.", badRequestResult.Value); // Verifica a mensagem de erro
        }
    }
}
