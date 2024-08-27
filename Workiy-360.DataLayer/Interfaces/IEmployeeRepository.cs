using System.Threading.Tasks;
using Workiy_360.EntityFramework;
using Workiy_360.Models;

namespace Workiy360.DataLayer.Interfaces
{
    public interface IEmployeeRepository
    {
        Task AddAsync(EmployeeInformation employee);
        Task UpdateAsync(EmployeeInformation employee); // Add this method
        Task<EmployeeInformation> GetByPhoneNumberAsync(string phoneNumber);
    }

}
