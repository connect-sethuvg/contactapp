using ContactPage.Data.Contracts;
using ContactPage.frameworks.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.Data.Entities
{
    public class ContactDetails : BaseEntity, IContactPageDetails
    {
        public long hdrId { get; set; }
        public string Name { get; set; }
        public long ContactNumber { get; set; }
        public string? Description { get; set; }
        public long? CreatedUserId { get; set; }
        public long? EditedUserId { get; set; }
        public  ContactHeader ContactHeader { get; set; }
    }
}
