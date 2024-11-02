using ContactZone.Api.Controllers;
using ContactZone.Api.Dtos;
using ContactZone.Application.Services;
using ContactZone.Domain.Domains;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ContactZone.Api.Test.Controllers
{
    public class ContactControllerActionResultTestGetByDDD
    {
        private readonly ContactController _controller;
        private readonly Mock<IContactService> _contactServiceMock;

        public ContactControllerActionResultTestGetByDDD()
        {
            _contactServiceMock = new Mock<IContactService>();
            _controller = new ContactController(_contactServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_ValidDDD_ReturnsOk()
        {
            // Arrange
            int validDDD = 11; // Exemplo de DDD válido
                        var expectedContacts = new List<ContactDomain>
                {
                    new ContactDomain { Id = 1, Name = "John Doe" },
                    new ContactDomain { Id = 2, Name = "Jane Doe" }
                };

            _contactServiceMock.Setup(s => s.GetContactFilteringByDDD(validDDD))
                .ReturnsAsync(expectedContacts);

            // Act
            var result = await _controller.GetAll(validDDD);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var contacts = Assert.IsType<List<ContactDto>>(okResult.Value); // Acessa o valor de OkObjectResult
            Assert.Equal(expectedContacts.Count, contacts.Count); // Verifica se o número de contatos é igual
        }

    }
}
