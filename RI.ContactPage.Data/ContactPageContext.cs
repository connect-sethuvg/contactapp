using ContactPage.Data.Entities;
using ContactPage.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.ContactPage.Data
{
    public class ContactPageContext : DbContext
    {
        public ContactPageContext()
        {
        }

        public ContactPageContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ContactPage;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public virtual DbSet<ContactHeader> ContactHeaders { get; set; }
        public virtual DbSet<ContactDetail> ContactDetails { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfiguration(new ContactPageMap());
            _ = modelBuilder.ApplyConfiguration(new ContactDetailMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
