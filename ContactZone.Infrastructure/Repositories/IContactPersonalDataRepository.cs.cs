using ContactZone.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactZone.Infrastructure.Repositories
{
    public interface IContactPersonalDataRepository : IGenericRepository<ContactPersonalDataDomain>
    {
    }
}
