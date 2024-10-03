using ContactZone.Domain.Domains;
using ContactZone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactZone.Infrastructure.Repositories
{
    public class ContactPersonalDataRepository : GenericRepository<ContactPersonalDataDomain>, IContactPersonalDataRepository
    {
        public ContactPersonalDataRepository(ContactZoneDbContext context) : base(context)
        {
            
        }
    }
}
