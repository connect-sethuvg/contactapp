using ContactPage.Business.Contracts;
using ContactPage.Data.Contracts;
using ContactPage.frameworks.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.DataService.Contracts
{
    public interface IContactHeaderDataService
    {
        Task<ActionStatus<IContactPage>> CreateContactHeader(IContactPage result);
        Task<ActionStatus<IContactPage>> EditContactHeaderDataService(IContactPage result);
    }
}
