using ContactZone.Domain.Domains;
using ContactZone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactZone.Infrastructure.Repositories
{
    public class ContactRepository : GenericRepository<ContactDomain>, IContactRepository
    {
        public ContactRepository(ContactZoneDbContext context) : base(context)
        {
        }
    }
}
