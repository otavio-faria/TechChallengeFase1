using ContactZone.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactZone.Infrastructure.Data
{
    public class ContactZoneDbContext : DbContext
    {
        public DbSet<ContatoDomain> Contatos { get; set; }
        public DbSet<DadoPessoalContatoDomain> DadosPessoais { get; set; }
        
        public ContactZoneDbContext(DbContextOptions<ContactZoneDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  modelBuilder.ApplyConfiguration(new ContatoMap());
          //  modelBuilder.ApplyConfiguration(new DadosPessoaisContatoMap());
        }
    }
}
