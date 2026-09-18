using ContactPage.Data.Contracts;
using ContactPage.DTOs;
using ContactPage.DTOs.ContactHeaderDetail;
using ContactPage.frameworks.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.DataService.Contracts
{
    public interface IContactDetailsDataService
    {
        Task<ActionStatus<IContactPageDetails>> CreateContactDetail(IContactPageDetails details);
        Task<ActionStatus<IContactPageDetails>> DeactivateContactHeaderofId(long id);
        Task<ActionStatus<IContactPageDetails>> EditContactDetail(IContactPageDetails details);
        Task<ActionStatus<List<IContactPageDetails>>> GetContactDetailPagePagination(PaginationParams paginationParams);
    }
}
