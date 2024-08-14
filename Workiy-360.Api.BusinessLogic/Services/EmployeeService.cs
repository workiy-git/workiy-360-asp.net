using System.Threading.Tasks;
using Workiy_360.Api.BusinessLogic.Interfaces;
using Workiy360.DataLayer.Interfaces;
using Workiy_360.Models;
using Workiy_360.EntityFramework;

namespace Workiy_360.Api.BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeInformation> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _employeeRepository.GetByPhoneNumberAsync(phoneNumber);
        }

        public async Task AddOrUpdateAsync(EmployeeInformation employee)
        {
            await _employeeRepository.AddOrUpdateAsync(employee);
        }
    }
}
