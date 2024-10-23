using System.Collections.Generic;
using System.Threading.Tasks;
using ContactZone.Api.Controllers;
using ContactZone.Application.Services;
using ContactZone.Domain.Domains;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ContactZone.Tests.Api
{
    public class ContactControllerActionResultTestGetByDDD
    {
        private readonly ContactController _controller;
        private readonly Mock<IContactService> _contactServiceMock;

        public ContactControllerActionResultTestGetByDDD()
        {
            _contactServiceMock = new Mock<IContactService>();
            _controller = new ContactController(_contactServiceMock.Object,null);
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
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var contacts = Assert.IsType<List<ContactDomain>>(okResult.Value);
            Assert.Equal(expectedContacts.Count, contacts.Count); // Verifica se o número de contatos é igual
        }
    }
}
