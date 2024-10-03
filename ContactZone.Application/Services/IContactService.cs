using ContactZone.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactZone.Application.Services
{
    public interface IContactService
    {
        Task<ContactDomain> GetByIdAsync(int id);
        Task<IEnumerable<ContactDomain>> GetAllAsync();
        Task<IEnumerable<ContactDomain>> FindAsync(Expression<Func<ContactDomain, bool>> predicate);
        Task AddAsync(ContactDomain entity);
        Task AddRangeAsync(IEnumerable<ContactDomain> entities);
        Task RemoveAsync(ContactDomain entity);
        Task RemoveRangeAsync(IEnumerable<ContactDomain> entities);
        void Update(ContactDomain entity);
    }
}
