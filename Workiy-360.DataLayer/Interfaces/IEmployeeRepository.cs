using System.Threading.Tasks;
using Workiy_360.EntityFramework;
using Workiy_360.Models;

namespace Workiy360.DataLayer.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<EmployeeInformation> GetByPhoneNumberAsync(string phoneNumber);
        Task AddOrUpdateAsync(EmployeeInformation employee);
    }
}
