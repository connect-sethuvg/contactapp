using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.DTOs.ContactHeaderDetail
{
    public class CreateContactDetailDTO
    {
        public long Id { get; set; }
        public long hdrId { get; set; }
        public string Name { get; set; }
        public int? ActiveStatus { get; set; }
        public long ContactNumber { get; set; }
        public string? Description { get; set; }
        public long? CreatedUserId { get; set; }

    }
}
