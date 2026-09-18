using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.DTOs.ContactDetail
{
    public class EditContactDetailDTO
    {
        public long id { get; set; }
        public long hdrId { get; set; }
        public string? Name { get; set; }
        public int? ActiveStatus { get; set; }
        public long ContactNumber { get; set; }
        public string? Description { get; set; }
        public long? EditedUserId { get; set; }

    }
}
