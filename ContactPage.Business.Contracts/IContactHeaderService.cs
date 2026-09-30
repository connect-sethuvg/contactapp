using ContactPage.DTOs;
using ContactPage.DTOs.ContactHeader;
using ContactPage.frameworks.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.Business.Contracts
{
    public interface IContactHeaderService
    {
        Task<ActionStatus<ContactPageDTO>> ActivateContactHeaderofId(long id);
        Task<ActionStatus<ContactPageDTO>> CreateContactHeaderService(CreateContactPageDTO entities);
        Task<ActionStatus<ContactPageDTO>> DeactivateContactHeaderofId(long id);
        Task<ActionStatus<ContactPageDTO>> DeleteContactHeaderofId(long id);
        Task<ActionStatus<ContactPageDTO>> EditContactHeaderService(EditContactPageDTO data);
        Task<ActionStatus<ContactPageDTO>> GetContactHeaderbyid(long id);
        Task<ActionStatus<List<ContactPageDTO>>> GetContactPagePagination(PaginationParams paginationParams);
    }
}
