using System.Linq.Expressions;
using ContactZone.Application.Repositories;
using ContactZone.Application.Services;
using ContactZone.Domain.Domains;
using Moq;
using Xunit;

namespace ContactZone.Application.Test.Services
{
    public class ContactServiceTests
    {
        private readonly Mock<IContactRepository> _mockContactRepository;
        private readonly ContactService _contactService;

        public ContactServiceTests()
        {
            _mockContactRepository = new Mock<IContactRepository>();
            _contactService = new ContactService(_mockContactRepository.Object);
        }

        [Fact]
        public async Task AddAsync_Should_Call_AddAsync_On_Repository()
        {
            var contact = new ContactDomain();
            await _contactService.AddAsync(contact);
            _mockContactRepository.Verify(r => r.AddAsync(contact), Times.Once);
        }

        [Fact]
        public async Task AddRangeAsync_Should_Call_AddRangeAsync_On_Repository()
        {
            var contacts = new List<ContactDomain> { new ContactDomain(), new ContactDomain() };
            await _contactService.AddRangeAsync(contacts);
            _mockContactRepository.Verify(r => r.AddRangeAsync(contacts), Times.Once);
        }

        [Fact]
        public async Task FindAsync_Should_Call_FindAsync_On_Repository()
        {
            Expression<Func<ContactDomain, bool>> predicate = c => c.Id == 1;
            await _contactService.FindAsync(predicate);
            _mockContactRepository.Verify(r => r.FindAsync(predicate), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_Should_Call_GetAllAsync_On_Repository()
        {
            await _contactService.GetAllAsync();
            _mockContactRepository.Verify(r => r.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Call_GetByIdAsync_On_Repository()
        {
            int id = 1;
            await _contactService.GetByIdAsync(id);
            _mockContactRepository.Verify(r => r.GetByIdAsync(id), Times.Once);
        }

        [Fact]
        public async Task RemoveAsync_Should_Call_RemoveAsync_On_Repository()
        {
            var contact = new ContactDomain();
            await _contactService.RemoveAsync(contact);
            _mockContactRepository.Verify(r => r.RemoveAsync(contact), Times.Once);
        }

        [Fact]
        public async Task RemoveRangeAsync_Should_Call_RemoveRangeAsync_On_Repository()
        {
            var contacts = new List<ContactDomain> { new ContactDomain(), new ContactDomain() };
            await _contactService.RemoveRangeAsync(contacts);
            _mockContactRepository.Verify(r => r.RemoveRangeAsync(contacts), Times.Once);
        }

        [Fact]
        public void Update_Should_Call_Update_On_Repository()
        {
            var contact = new ContactDomain();
            _contactService.Update(contact);
            _mockContactRepository.Verify(r => r.Update(contact), Times.Once);
        }

        [Fact]
        public async Task GetContactWithAllInformation_Should_Call_GetContactWithAllInformation_On_Repository()
        {
            await _contactService.GetContactWithAllInformation();
            _mockContactRepository.Verify(r => r.GetContactWithAllInformation(), Times.Once);
        }

        [Fact]
        public async Task GetContactFilteringByDDD_Should_Call_GetContactFilteringByDDD_On_Repository()
        {
            int ddd = 11;
            await _contactService.GetContactFilteringByDDD(ddd);
            _mockContactRepository.Verify(r => r.GetContactFilteringByDDD(ddd), Times.Once);
        }
    }
}