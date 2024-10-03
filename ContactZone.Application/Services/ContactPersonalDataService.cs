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
    public class ContactPersonalDataService : IContactPersonalDataService
    {
        private readonly IContactPersonalDataRepository _contactPersonalDataRepository;
        public ContactPersonalDataService(IContactPersonalDataRepository contactPersonalDataRepository)
        {
            _contactPersonalDataRepository = contactPersonalDataRepository;
        }
        public async Task AddAsync(ContactPersonalDataDomain entity)
        {
            await _contactPersonalDataRepository.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<ContactPersonalDataDomain> entities)
        {
            await _contactPersonalDataRepository.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<ContactPersonalDataDomain>> FindAsync(Expression<Func<ContactPersonalDataDomain, bool>> predicate)
        {
            return await _contactPersonalDataRepository.FindAsync(predicate);
        }

        public async Task<IEnumerable<ContactPersonalDataDomain>> GetAllAsync()
        {
           return await _contactPersonalDataRepository.GetAllAsync();
        }

        public async Task<ContactPersonalDataDomain> GetByIdAsync(int id)
        {
            return await _contactPersonalDataRepository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(ContactPersonalDataDomain entity)
        {
            await _contactPersonalDataRepository.RemoveAsync(entity);
        }

        public async Task RemoveRangeAsync(IEnumerable<ContactPersonalDataDomain> entities)
        {
             await _contactPersonalDataRepository.RemoveRangeAsync(entities);
        }

        public async void Update(ContactPersonalDataDomain entity)
        {
            _contactPersonalDataRepository.Update(entity);
        }
    }
}
