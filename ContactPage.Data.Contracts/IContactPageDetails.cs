using ContactPage.frameworks.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.Data.Contracts
{
    public interface IContactPageDetails : IEntity, IAuditable
    {
        long hdrId {  get; set; }
        string Name {  get; set; }
        long ContactNumber { get; set; }
        string? Description { get; set; }
        public int ActiveStatus { get; set; }


    }
}
