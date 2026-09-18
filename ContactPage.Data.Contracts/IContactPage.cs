using ContactPage.frameworks.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.Data.Contracts
{
    public interface IContactPage : IEntity, IAuditable
    {
        string Name { get; set; }
        string? Email { get; set; }
        int? ActiveStatus { get; set; }

    }
}
