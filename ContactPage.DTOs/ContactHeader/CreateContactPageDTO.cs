using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.DTOs.ContactHeader
{
    public class CreateContactPageDTO
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? ActiveStatus { get; set; }
        public long? CreatedUserId { get; set; }
    }
}
