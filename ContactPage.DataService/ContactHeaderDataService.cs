using ContactPage.Data.Contracts;
using ContactPage.DataService.Contracts;
using ContactPage.DTOs;
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

namespace ContactPage.DataService
{
    public class ContactHeaderDataService : BaseDataServices, IContactHeaderDataService
    {
        private readonly IRepository<IContactPage> _contactPageRepo;

        public ContactHeaderDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _contactPageRepo = unitOfWork.Repository<IContactPage>();
        }

        public async Task<ActionStatus<IContactPage>> ActivateContactHeaderofId(long id)
        {
            try
            {
                IContactPage data = await _contactPageRepo.Entities.FirstOrDefaultAsync(x => x.Id == id);
                if (data != null)
                {
                    data.ActiveStatus = 1; // Activate user
                    _contactPageRepo.Update(data);
                    int count = await UnitOfWork.CommitAsync();

                    if (count > 0)
                    {
                        return new ActionStatus<IContactPage>(true, data, count);
                    }
                }
                return new ActionStatus<IContactPage>(new ResponseVM(" No Data found in Id : " + data.Id));

            }
            catch (Exception ex)
            {
                return new ActionStatus<IContactPage>("Exception occurred at DeleteContactHeaderofId", ex);
            }
        }

        public async Task<ActionStatus<IContactPage>> CreateContactHeader(IContactPage result)
        {
            try
            {
                IContactPage data = _contactPageRepo.Add(result);
                int count = await UnitOfWork.CommitAsync();
                if (count > 0)
                {
                    return new ActionStatus<IContactPage>(true, data);
                }
                return new ActionStatus<IContactPage>(new ResponseVM("CreateContactHeader"));
            }
            catch (Exception ex)
            {
                return new ActionStatus<IContactPage>("Exception occurred at CreateContactHeader", ex);
            }
        }

        public async Task<ActionStatus<IContactPage>> DeactivateContactHeaderofId(long id)
        {
            try
            {
                IContactPage data = await _contactPageRepo.Entities.FirstOrDefaultAsync(x => x.Id == id);
                if (data != null)
                {
                    data.ActiveStatus = 0; // Inactive user
                    _contactPageRepo.Update(data);
                    int count = await UnitOfWork.CommitAsync();

                    if (count > 0)
                    {
                        return new ActionStatus<IContactPage>(true, data, count);
                    }
                }
                return new ActionStatus<IContactPage>(new ResponseVM(" No Data found in Id : " + data.Id));

            }
            catch (Exception ex)
            {
                return new ActionStatus<IContactPage>("Exception occurred at DeleteContactHeaderofId", ex);
            }
        }

        public async Task<ActionStatus<IContactPage>> DeleteContactHeaderofId(long id)
        {
            try
            {
                IContactPage data = await _contactPageRepo.Entities.FirstOrDefaultAsync(x => x.Id == id);
                if (data != null)
                {
                    data.ActiveStatus = 2; // Deactivate user
                    _contactPageRepo.Update(data);
                    int count = await UnitOfWork.CommitAsync();

                    if (count > 0)
                    {
                        return new ActionStatus<IContactPage>(true, data, count);
                    }
                }
                return new ActionStatus<IContactPage>(new ResponseVM(" No Data found in Id : " + data.Id));

            }
            catch (Exception ex)
            {
                return new ActionStatus<IContactPage>("Exception occurred at DeleteContactHeaderofId", ex);
            }
        }

        public async Task<ActionStatus<IContactPage>> EditContactHeaderDataService(IContactPage result)
        {
            try
            {
                IContactPage data = await _contactPageRepo.Entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == result.Id);
                if (data != null)
                {
                    data.Name = result.Name;
                    data.Email = result.Email;
                    data.ActiveStatus = result.ActiveStatus;
                    data.EditedUserId = result.EditedUserId;

                    _contactPageRepo.Update(data);
                    int count = await UnitOfWork.CommitAsync();

                    if (count > 0)
                    {
                        return new ActionStatus<IContactPage>(true, data, count);
                    }
                    return new ActionStatus<IContactPage>(new ResponseVM("Error occurred in Edit Header"));
                }
                return new ActionStatus<IContactPage>(new ResponseVM(" No Data found in Id : " + data.Id));
            }
            catch (Exception ex)
            {
                return new ActionStatus<IContactPage>("Exception occurred at EditContactHeaderDataService ", ex);
            }
        }

        public async Task<ActionStatus<IContactPage>> GetContactHeaderbyid(long id)
        {
            try
            {
                IContactPage data = await _contactPageRepo.Entities.FirstOrDefaultAsync(x => x.Id == id);
                if (data != null)
                {
                    return new ActionStatus<IContactPage>(true, data, 1);
                }
                return new ActionStatus<IContactPage>(new ResponseVM(" No Data found in Id : " + data.Id));
            }
            catch (Exception ex)
            {
                return new ActionStatus<IContactPage>("Exception occurred at GetContactHeaderbyid ", ex);
            }
        }

        public async Task<ActionStatus<List<IContactPage>>> GetContactPagePagination(PaginationParams paginationParams)
        {
            try
            {
                int count = 0;
                IQueryable<IContactPage> result = _contactPageRepo.Entities.Where(x => x.ActiveStatus == 1);

                if (!string.IsNullOrWhiteSpace(paginationParams.SearchTerm))
                {
                    result = result.Where(x => x.Name.Contains(paginationParams.SearchTerm) || x.Email.Contains(paginationParams.SearchTerm));
                }

                count = await result.CountAsync();

                if (count > 0)
                {
                    //result = !string.IsNullOrWhiteSpace(paginationParams.SortColumn) ? result.Where(x => x.Name.Contains(paginationParams.SearchTerm) || x.Email.Contains(paginationParams.SearchTerm)) : result.OrderByDescending(x=> x.Id);

                    if (!string.IsNullOrWhiteSpace(paginationParams.SortColumn))
                    {
                        result = paginationParams.SortColumn.ToLower() switch
                        {
                            "id" => paginationParams.SortDirection == "asc" ? result.OrderBy(x => x.Id) : result.OrderByDescending(x => x.Id),
                            "name" => paginationParams.SortDirection == "asc" ? result.OrderBy(x => x.Name) : result.OrderByDescending(x => x.Name),
                            "createddate" => paginationParams.SortDirection == "asc" ? result.OrderBy(x => x.CreatedDate) : result.OrderByDescending(x => x.CreatedDate),
                            _ => result.OrderByDescending(x => x.Id)
                        };

                    }
                    else
                    {
                        result = result.OrderByDescending(x => x.Id);
                    }

                    List<IContactPage> res = await result.Skip((paginationParams.Page - 1) * paginationParams.PageSize).Take(paginationParams.PageSize).ToListAsync();

                    return new ActionStatus<List<IContactPage>>(true, res, res.Count);
                }
                return new ActionStatus<List<IContactPage>>(new ResponseVM("No Data Available"));
            }
            catch (Exception ex)
            {
                return new ActionStatus<List<IContactPage>>("Exception occurred at GetContactHeaderbyid ", ex);
            }
        }
    }
}
