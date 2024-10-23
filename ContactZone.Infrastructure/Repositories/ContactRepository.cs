using ContactZone.Domain.Domains;
using ContactZone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ContactZone.Infrastructure.Repositories
{
    public class ContactRepository : GenericRepository<ContactDomain>, IContactRepository
    {
        private readonly ContactZoneDbContext _context;
        public ContactRepository(ContactZoneDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactDomain>> GetContactWithAllInformation()
        {
            return await _context.Contatos
                .Include(x => x.ContactPersonalDataDomain)
                .ToListAsync();
        }

        public async Task<IEnumerable<ContactDomain>> GetContactFilteringByDDD(int ddd)
        {
            return await _context.Contatos
                .Include(x => x.ContactPersonalDataDomain)
                .Where(x => x.ContactPersonalDataDomain.DDD == ddd.ToString())
                .ToListAsync();
        }
    }
}
