using ContactPage.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.Data.Mappings
{
    public class ContactDetailMap : IEntityTypeConfiguration<ContactDetails>
    {
        public void Configure(EntityTypeBuilder<ContactDetails> builder)
        {
            _ = builder.ToTable("ContactDetails");
            _ = builder.HasKey(x => x.Id);
            _ = builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            _ = builder.Property(x => x.ContactNumber).IsRequired().HasMaxLength(15);
            _ = builder.Property(x => x.Description).HasMaxLength(20);
            _ = builder.Property(x => x.CreatedUserId);
            _ = builder.Property(x => x.EditedUserId);
            _ = builder.Property(x => x.CreatedDate);
            _ = builder.Property(x => x.EditedDate);
            _ = builder.HasOne(x=> x.ContactHeader).WithMany(x=> x.contactDetails).HasForeignKey(x=>x.hdrId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
