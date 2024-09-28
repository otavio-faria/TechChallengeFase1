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
    public class PersonalDataContactMap : IEntityTypeConfiguration<ContactPersonalDataDomain>
    {
        public void Configure(EntityTypeBuilder<ContactPersonalDataDomain> builder)
        {
            builder.ToTable("ContactPersonalData");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.DDD)
               .IsRequired()
               .HasColumnName("DDD")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(3);

            builder.Property(x => x.Phone)
               .IsRequired()
               .HasColumnName("Phone")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(11);

            builder.Property(x => x.Email)
               .IsRequired()
               .HasColumnName("Email")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(200);
        }
    }
}
