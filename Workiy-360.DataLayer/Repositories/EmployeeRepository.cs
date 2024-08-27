using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Workiy360.DataLayer.Interfaces;
using Workiy_360.EntityFramework.Context;
using Workiy_360.Models;
using Workiy_360.EntityFramework;

namespace Workiy_360.DataLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Workiy360DbContext _context;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(Workiy360DbContext context, ILogger<EmployeeRepository> logger)
        {
            _context = context;
            _logger = logger;
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

        public async Task AddAsync(EmployeeInformation employee)
        {
            await _context.EmployeeInformations.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeInformation employee)
        {
            var existingEmployee = await _context.EmployeeInformations
                .Include(e => e.EmployeeAddressDetails)
                .Include(e => e.EmployeeContactDetails)
                .Include(e => e.EmployeeEducationalDetails)
                .Include(e => e.EmployeeExperienceDetails)
                .Include(e => e.EmployeeNationalityDocuments)
                .FirstOrDefaultAsync(e => e.MobileNo == employee.MobileNo);

            if (existingEmployee != null)
            {
                _logger.LogInformation($"Updating existing employee with phone number {employee.MobileNo}");

                // Update existing employee record
                _context.Entry(existingEmployee).CurrentValues.SetValues(employee);

                // Update related entities
                UpdateRelatedEntities(existingEmployee, employee);

                _context.Entry(existingEmployee).State = EntityState.Modified;
            }
            else
            {
                _logger.LogInformation($"Adding new employee with phone number {employee.MobileNo}");
                // Add new employee record
                await _context.EmployeeInformations.AddAsync(employee);
            }

            await _context.SaveChangesAsync();
        }


        private void UpdateRelatedEntities(EmployeeInformation existingEmployee, EmployeeInformation employee)
        {
            // Update or add address details
            foreach (var address in employee.EmployeeAddressDetails)
            {
                var existingAddress = existingEmployee.EmployeeAddressDetails
                    .FirstOrDefault(a => a.AddressPkId == address.AddressPkId);

                if (existingAddress != null)
                {
                    _context.Entry(existingAddress).CurrentValues.SetValues(address);
                }
                else
                {
                    existingEmployee.EmployeeAddressDetails.Add(address);
                }
            }

            // Update or add contact details
            foreach (var contact in employee.EmployeeContactDetails)
            {
                var existingContact = existingEmployee.EmployeeContactDetails
                    .FirstOrDefault(c => c.ContactPkId == contact.ContactPkId);

                if (existingContact != null)
                {
                    _context.Entry(existingContact).CurrentValues.SetValues(contact);
                }
                else
                {
                    existingEmployee.EmployeeContactDetails.Add(contact);
                }
            }

            // Update or add educational details
            foreach (var education in employee.EmployeeEducationalDetails)
            {
                var existingEducation = existingEmployee.EmployeeEducationalDetails
                    .FirstOrDefault(e => e.EducationalPkId == education.EducationalPkId);

                if (existingEducation != null)
                {
                    _context.Entry(existingEducation).CurrentValues.SetValues(education);
                }
                else
                {
                    existingEmployee.EmployeeEducationalDetails.Add(education);
                }
            }

            // Update or add experience details
            foreach (var experience in employee.EmployeeExperienceDetails)
            {
                var existingExperience = existingEmployee.EmployeeExperienceDetails
                    .FirstOrDefault(e => e.ExpId == experience.ExpId);

                if (existingExperience != null)
                {
                    _context.Entry(existingExperience).CurrentValues.SetValues(experience);
                }
                else
                {
                    existingEmployee.EmployeeExperienceDetails.Add(experience);
                }
            }

            // Update or add nationality documents
            foreach (var nationality in employee.EmployeeNationalityDocuments)
            {
                var existingNationality = existingEmployee.EmployeeNationalityDocuments
                    .FirstOrDefault(n => n.NatPkId == nationality.NatPkId);

                if (existingNationality != null)
                {
                    _context.Entry(existingNationality).CurrentValues.SetValues(nationality);
                }
                else
                {
                    existingEmployee.EmployeeNationalityDocuments.Add(nationality);
                }
            }
        }
    }
}
