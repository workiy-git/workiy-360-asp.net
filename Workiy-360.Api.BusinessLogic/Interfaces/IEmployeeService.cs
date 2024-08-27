using System.Threading.Tasks;
using Workiy_360.EntityFramework;
using Workiy_360.Models;

namespace Workiy_360.Api.BusinessLogic.Interfaces
{
    public interface IEmployeeService
    {
        Task<string> AddOrUpdateAsync(EmployeeInformation employee, int flag);
        Task<EmployeeInformation> GetByPhoneNumberAsync(string phoneNumber);
    }
}
