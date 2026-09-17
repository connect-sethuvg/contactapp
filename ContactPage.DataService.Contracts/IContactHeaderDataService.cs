using ContactPage.Business.Contracts;
using ContactPage.Data.Contracts;
using ContactPage.DTOs;
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
        Task<ActionStatus<IContactPage>> ActivateContactHeaderofId(long id);
        Task<ActionStatus<IContactPage>> CreateContactHeader(IContactPage result);
        Task<ActionStatus<IContactPage>> DeactivateContactHeaderofId(long id);
        Task<ActionStatus<IContactPage>> DeleteContactHeaderofId(long id);
        Task<ActionStatus<IContactPage>> EditContactHeaderDataService(IContactPage result);
        Task<ActionStatus<IContactPage>> GetContactHeaderbyid(long id);
        Task<ActionStatus<List<IContactPage>>> GetContactPagePagination(PaginationParams paginationParams);
    }
}
