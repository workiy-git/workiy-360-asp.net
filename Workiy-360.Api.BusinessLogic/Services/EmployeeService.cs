using System.Threading.Tasks;
using Workiy_360.Api.BusinessLogic.Interfaces;
using Workiy_360.EntityFramework;
using Workiy_360.Models;
using Workiy360.DataLayer.Interfaces;

namespace Workiy_360.Api.BusinessLogic
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task AddOrUpdateAsync(EmployeeInformation employee, int flag)
        {
            if (flag == 1)
            {
                await _employeeRepository.AddAsync(employee);
            }
            else
            {
                await _employeeRepository.AddOrUpdateAsync(employee);
            }
        }

        public async Task<EmployeeInformation> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _employeeRepository.GetByPhoneNumberAsync(phoneNumber);
        }
    }
}
