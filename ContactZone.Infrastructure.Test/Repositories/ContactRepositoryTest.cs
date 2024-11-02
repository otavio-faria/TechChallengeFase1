using ContactZone.Domain.Domains;
using ContactZone.Infrastructure.Data;
using ContactZone.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ContactZone.Infrastructure.Test.Repositories
{
    public class ContactRepositoryTests
    {
        private readonly ContactZoneDbContext _context;
        private readonly ContactRepository _repository;

        public ContactRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ContactZoneDbContext>()
                .UseInMemoryDatabase(databaseName: $"ContactZoneDb_{Guid.NewGuid()}")
                .Options;

            _context = new ContactZoneDbContext(options);

            _context.Contatos.AddRange(
                new ContactDomain { Id = 1, DDD = "11", Name = "João", Email = "joao@example.com", Phone = "111111111" },
                new ContactDomain { Id = 2, DDD = "21", Name = "Maria", Email = "maria@example.com", Phone = "222222222" },
                new ContactDomain { Id = 3, DDD = "11", Name = "Carlos", Email = "carlos@example.com", Phone = "333333333" }
            );
            _context.SaveChanges();

            _repository = new ContactRepository(_context);
        }

        [Fact]
        public async Task GetContactWithAllInformation_ShouldReturnAllContacts()
        {
            var result = await _repository.GetContactWithAllInformation();
            Assert.Equal(3, result.Count());
            Assert.Contains(result, c => c.Name == "João");
            Assert.Contains(result, c => c.Name == "Maria");
            Assert.Contains(result, c => c.Name == "Carlos");
        }

        [Fact]
        public async Task GetContactFilteringByDDD_ShouldReturnContactsWithSpecifiedDDD()
        {
            var result = await _repository.GetContactFilteringByDDD(11);
            Assert.Equal(2, result.Count());
            Assert.All(result, c => Assert.Equal("11", c.DDD));
        }
    }
}
