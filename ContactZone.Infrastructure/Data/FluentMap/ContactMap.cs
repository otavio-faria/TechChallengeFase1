using ContactZone.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactZone.Infrastructure.Data.FluentMap
{
    public class ContactMap : IEntityTypeConfiguration<ContactDomain>
    {
        public void Configure(EntityTypeBuilder<ContactDomain> builder)
        {

        }
    }
}
