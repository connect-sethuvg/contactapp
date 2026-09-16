using ContactPage.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.Data.Mappings
{
    public class ContactPageMap : IEntityTypeConfiguration<ContactHeader>
    {
        public void Configure(EntityTypeBuilder<ContactHeader> builder)
        {
            _ = builder.ToTable("ContactHeaders");
            _ = builder.HasKey(x => x.Id);
            _ = builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            _ = builder.Property(x=> x.Email).IsRequired().HasMaxLength(50);
            _ = builder.Property(x => x.ActiveStatus).IsRequired();
            _ = builder.Property(x => x.CreatedUserId);
            _ = builder.Property(x => x.EditedUserId);
            _ = builder.Property(x => x.CreatedDate);
            _ = builder.Property(x => x.EditedDate);

        }
    }
}
