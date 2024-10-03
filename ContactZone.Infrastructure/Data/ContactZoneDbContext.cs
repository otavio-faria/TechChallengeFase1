using ContactZone.Domain.Domains;
using ContactZone.Infrastructure.Data.FluentMap;
using Microsoft.EntityFrameworkCore;

namespace ContactZone.Infrastructure.Data
{
    public class ContactZoneDbContext : DbContext
    {
        public DbSet<ContactDomain> Contatos { get; set; }
        public DbSet<ContactPersonalDataDomain> DadosPessoais { get; set; }

        public ContactZoneDbContext(DbContextOptions<ContactZoneDbContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMap());
            modelBuilder.ApplyConfiguration(new ContactPersonalDataMap());
        }
    }
}
