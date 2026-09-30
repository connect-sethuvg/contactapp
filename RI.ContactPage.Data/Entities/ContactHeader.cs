using ContactPage.Data.Contracts;
using ContactPage.frameworks.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.Data.Entities
{
    public class ContactHeader : BaseEntity, IContactPage
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int? ActiveStatus { get; set; }
        public long? CreatedUserId { get; set; }
        public long? EditedUserId { get; set; }
        public virtual ICollection<ContactDetail>? contactDetails { get; set; } 
    }
}
