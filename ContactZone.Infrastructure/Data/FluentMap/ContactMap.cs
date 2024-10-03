using ContactZone.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactZone.Infrastructure.Data.FluentMap
{
    public class ContactMap : IEntityTypeConfiguration<ContactDomain>
    {
        public void Configure(EntityTypeBuilder<ContactDomain> builder)
        {
            builder.ToTable("Contact");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Name)
               .IsRequired()
               .HasColumnName("Name")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(80);

            builder.HasOne(x => x.ContactPersonalDataDomain)
                   .WithOne(x => x.Contact)
                   .HasForeignKey<ContactPersonalDataDomain>(x => x.ContactId)  
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
