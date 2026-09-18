using ContactPage.DTOs;
using ContactPage.DTOs.ContactDetail;
using ContactPage.DTOs.ContactHeaderDetail;
using ContactPage.frameworks.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.Business.Contracts
{
    public interface IContactHeaderDetailService
    {
        Task<ActionStatus<ContactDetailDTO>> CreateContactDetail(CreateContactDetailDTO dto);
        Task<ActionStatus<ContactDetailDTO>> DeleteContactDetail(long id);
        Task<ActionStatus<ContactDetailDTO>> EditContactDetail(EditContactDetailDTO dto);
        Task<ActionStatus<List<ContactDetailDTO>>> GetContactDetailPagePagination(PaginationParams paginationParams);
    }
}
