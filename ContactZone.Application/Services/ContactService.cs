using ContactZone.Domain.Domains;
using ContactZone.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactZone.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task AddAsync(ContactDomain entity)
        {
            await _contactRepository.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<ContactDomain> entities)
        {
            await _contactRepository.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<ContactDomain>> FindAsync(Expression<Func<ContactDomain, bool>> predicate)
        {
            return await _contactRepository.FindAsync(predicate);
        }

        public async Task<IEnumerable<ContactDomain>> GetAllAsync()
        {
            return await _contactRepository.GetAllAsync();
        }

        public async Task<ContactDomain> GetByIdAsync(int id)
        {
            return await _contactRepository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(ContactDomain entity)
        {
            await _contactRepository.RemoveAsync(entity);
        }

        public async Task RemoveRangeAsync(IEnumerable<ContactDomain> entities)
        {
            await _contactRepository.RemoveAsync((ContactDomain)entities);
        }

        public async void Update(ContactDomain entity)
        {
            _contactRepository.Update(entity);
        }
    }
}
