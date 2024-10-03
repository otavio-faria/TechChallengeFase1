using ContactZone.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactZone.Application.Services
{
    public interface IContactPersonalDataService
    {
        Task<ContactPersonalDataDomain> GetByIdAsync(int id);
        Task<IEnumerable<ContactPersonalDataDomain>> GetAllAsync();
        Task<IEnumerable<ContactPersonalDataDomain>> FindAsync(Expression<Func<ContactPersonalDataDomain, bool>> predicate);
        Task AddAsync(ContactPersonalDataDomain entity);
        Task AddRangeAsync(IEnumerable<ContactPersonalDataDomain> entities);
        Task RemoveAsync(ContactPersonalDataDomain entity);
        Task RemoveRangeAsync(IEnumerable<ContactPersonalDataDomain> entities);
        void Update(ContactPersonalDataDomain entity);
    }
}
