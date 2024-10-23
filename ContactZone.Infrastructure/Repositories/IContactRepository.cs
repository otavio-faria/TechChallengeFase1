using ContactZone.Domain.Domains;
using System.Threading.Tasks;

namespace ContactZone.Infrastructure.Repositories
{
    public interface IContactRepository : IGenericRepository<ContactDomain>
    {
        public Task<IEnumerable<ContactDomain>> GetContactWithAllInformation();
        public Task<IEnumerable<ContactDomain>> GetContactFilteringByDDD(int ddd);
    }
}
