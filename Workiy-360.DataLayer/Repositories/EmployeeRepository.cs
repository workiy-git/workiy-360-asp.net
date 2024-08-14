using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Workiy_360.EntityFramework;
using Workiy_360.EntityFramework.Context;
using Workiy_360.Models;
using Workiy360.DataLayer.Interfaces;

namespace Workiy360.DataLayer
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Workiy360DbContext _context;

        public EmployeeRepository(Workiy360DbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeInformation> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.EmployeeInformations
                .Include(e => e.EmployeeAddressDetails)
                .Include(e => e.EmployeeContactDetails)
                .Include(e => e.EmployeeEducationalDetails)
                .Include(e => e.EmployeeExperienceDetails)
                .Include(e => e.EmployeeNationalityDocuments)
                .FirstOrDefaultAsync(e => e.MobileNo == phoneNumber);
        }

        public async Task AddOrUpdateAsync(EmployeeInformation employee)
        {
            var existingEmployee = await _context.EmployeeInformations
                .FindAsync(employee.EmployeeId);

            if (existingEmployee != null)
            {
                _context.Entry(existingEmployee).CurrentValues.SetValues(employee);
            }
            else
            {
                await _context.EmployeeInformations.AddAsync(employee);
            }

            await _context.SaveChangesAsync();
        }
    }
}
