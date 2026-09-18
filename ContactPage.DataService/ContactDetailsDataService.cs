using Azure;
using ContactPage.Data.Contracts;
using ContactPage.DataService.Contracts;
using ContactPage.DTOs;
using ContactPage.DTOs.ContactHeaderDetail;
using ContactPage.frameworks.Data;
using ContactPage.frameworks.Data.Services;
using ContactPage.frameworks.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContactPage.DataService
{
    public class ContactDetailsDataService : BaseDataServices, IContactDetailsDataService
    {
        private readonly IRepository<IContactPageDetails> _contactDetailrepo;
        public ContactDetailsDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _contactDetailrepo = unitOfWork.Repository<IContactPageDetails>();
        }

        public async Task<ActionStatus<IContactPageDetails>> CreateContactDetail(IContactPageDetails details)
        {
            try
            {
                details.ActiveStatus = 1;
                IContactPageDetails response = _contactDetailrepo.Add(details);
                int count = await UnitOfWork.CommitAsync();

                if (response != null)
                {
                    return new ActionStatus<IContactPageDetails>(true, response, count);
                }

                return new ActionStatus<IContactPageDetails>(new ResponseVM("Error occurred on adding contact Detail"));
            }
            catch (Exception ex)
            {

                return new ActionStatus<IContactPageDetails>(new ResponseVM("Exception error: CreateContactHeaderDetail " + ex));
            }

        }

        public async Task<ActionStatus<IContactPageDetails>> DeactivateContactHeaderofId(long id)
        {
            try
            {
                IContactPageDetails data = await _contactDetailrepo.Entities.FirstOrDefaultAsync(x => x.Id == id);
                if (data != null)
                {
                    data.ActiveStatus = 0; // Inactive user
                    _contactDetailrepo.Update(data);
                    int count = await UnitOfWork.CommitAsync();

                    if (count > 0)
                    {
                        return new ActionStatus<IContactPageDetails>(true, data, count);
                    }
                }
                return new ActionStatus<IContactPageDetails>(new ResponseVM(" No Data found in Id : " + data.Id));

            }
            catch (Exception ex)
            {
                return new ActionStatus<IContactPageDetails>("Exception occurred at DeleteContactHeaderofId", ex);
            }
        }

        public async Task<ActionStatus<IContactPageDetails>> EditContactDetail(IContactPageDetails dto)
        {
            try
            {
                IContactPageDetails repo = await _contactDetailrepo.Entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.Id && x.hdrId == dto.hdrId);
                if (repo != null)
                {
                    repo.Name = dto.Name;
                    repo.Description = dto.Description;
                    repo.ActiveStatus = dto.ActiveStatus;
                    repo.ContactNumber = dto.ContactNumber;
                    repo.EditedUserId = dto.EditedUserId;

                    _contactDetailrepo.Update(repo);
                    int count = await UnitOfWork.CommitAsync();

                    if (repo != null)
                    {
                        return new ActionStatus<IContactPageDetails>(true, repo, count);
                    }
                }

                return new ActionStatus<IContactPageDetails>(new ResponseVM("Error on updating Details "));
            }
            catch (Exception ex)
            {
                return new ActionStatus<IContactPageDetails>(new ResponseVM("Exception error: EditContactDetail " + ex));
            }
        }

        public async Task<ActionStatus<List<IContactPageDetails>>> GetContactDetailPagePagination(PaginationParams paginationParams)
        {
            int count = 0;
            IQueryable<IContactPageDetails> result = _contactDetailrepo.Entities.Where(x => x.ActiveStatus == 1);

            if (!string.IsNullOrWhiteSpace(paginationParams.SearchTerm))
            {
                result = result.Where(x => x.Name.Contains(paginationParams.SearchTerm));
            }

            count = await result.CountAsync();

            if (count > 0)
            {
                if (!string.IsNullOrWhiteSpace(paginationParams.SortColumn))
                {
                    result = paginationParams.SortColumn.ToLower() switch
                    {
                        "id" => paginationParams.SortDirection == "asc" ? result.OrderBy(x => x.Id) : result.OrderByDescending(x => x.Id),
                        "hdrid" => paginationParams.SortDirection == "asc" ? result.OrderBy(x => x.hdrId) : result.OrderByDescending(x => x.hdrId),
                        "name" => paginationParams.SortDirection == "asc" ? result.OrderBy(x => x.Name) : result.OrderByDescending(x => x.Name),
                        "activestatus" => paginationParams.SortDirection == "asc" ? result.OrderBy(x => x.ActiveStatus) : result.OrderByDescending(x => x.ActiveStatus),
                        "createddate" => paginationParams.SortDirection == "asc" ? result.OrderBy(x => x.CreatedDate) : result.OrderByDescending(x => x.CreatedDate),

                        _ => result.OrderByDescending(x => x.Id)
                    };

                }
                else
                {
                    result = result.OrderByDescending(x => x.Id);
                }

                List<IContactPageDetails> res = await result.Skip((paginationParams.Page - 1) * paginationParams.PageSize).Take(paginationParams.PageSize).ToListAsync();

                return new ActionStatus<List<IContactPageDetails>>(true, res, res.Count);
            }
            return new ActionStatus<List<IContactPageDetails>>(new ResponseVM("No Data Available"));
        }
    }
}
