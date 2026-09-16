using ContactPage.Data.Contracts;
using ContactPage.DataService.Contracts;
using ContactPage.frameworks.Data;
using ContactPage.frameworks.Data.Services;
using ContactPage.frameworks.Extension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
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
    }
}
