using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Workiy_360.Api.BusinessLogic.Interfaces;
using Workiy360.DataLayer.Interfaces;
using Workiy_360.Models;
using Workiy_360.EntityFramework;

namespace Workiy_360.Api.BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository employeeRepository, ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public async Task<string> AddOrUpdateAsync(EmployeeInformation employee, int flag)
        {
            try
            {
                if (flag == 3)
                {
                    return "No operation for flag 3"; // No operation
                }

                DateTime currentTime = DateTime.UtcNow;

                if (flag == 1)
                {
                    // Handle add operation
                    employee.StatusInd = true;
                    employee.CreatedBy = $"{employee.FirstName} {employee.LastName}";
                    employee.CreatedDate = currentTime;

                    // Set creation details for nested forms
                    SetCreationDetailsForNestedForms(employee, employee.CreatedBy, currentTime);

                    await _employeeRepository.AddAsync(employee);
                    return "Employee information added successfully.";
                }
                else if (flag == 2)
                {
                    // Handle update operation by phone number
                    var existingEmployee = await _employeeRepository.GetByPhoneNumberAsync(employee.MobileNo);
                    if (existingEmployee != null)
                    {
                        // Update existing employee record
                        employee.EmployeeId = existingEmployee.EmployeeId; // Use existing employee ID
                        employee.StatusInd = existingEmployee.StatusInd; // Preserve existing status
                        employee.CreatedBy = existingEmployee.CreatedBy; // Preserve original creator
                        employee.CreatedDate = existingEmployee.CreatedDate; // Preserve original creation date

                        // Set the updated by and updated date fields
                        employee.UpdatedBy = $"{employee.FirstName} {employee.LastName}";
                        employee.UpdatedDate = currentTime;

                        // Set update details for nested forms
                        SetUpdateDetailsForNestedForms(employee, employee.UpdatedBy, currentTime);

                        await _employeeRepository.UpdateAsync(employee);
                        return "Employee information updated successfully.";
                    }
                    else
                    {
                        // Add as a new record if phone number does not exist
                        employee.StatusInd = true;
                        employee.CreatedBy = $"{employee.FirstName} {employee.LastName}";
                        employee.CreatedDate = currentTime;

                        // Set creation details for nested forms
                        SetCreationDetailsForNestedForms(employee, employee.CreatedBy, currentTime);

                        await _employeeRepository.AddAsync(employee);
                        return "Employee information added successfully.";
                    }
                }

                return "Invalid flag value.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding or updating employee information");
                return $"Internal server error: {ex.Message}";
            }
        }

        public async Task<EmployeeInformation> GetByPhoneNumberAsync(string phoneNumber)
        {
            try
            {
                return await _employeeRepository.GetByPhoneNumberAsync(phoneNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving employee by phone number.");
                throw;
            }
        }

        // New Feature: Bulk add or update employees
        public async Task<string> BulkAddOrUpdateAsync(List<EmployeeInformation> employees, int flag)
        {
            var results = new List<string>();

            foreach (var employee in employees)
            {
                var result = await AddOrUpdateAsync(employee, flag);
                results.Add(result);
            }

            return string.Join("\n", results);
        }

        private void SetCreationDetailsForNestedForms(EmployeeInformation employee, string creatorName, DateTime currentTime)
        {
            if (employee.EmployeeContactDetails != null)
            {
                foreach (var contact in employee.EmployeeContactDetails)
                {
                    contact.StatusInd = true; // Set StatusInd for nested forms
                    contact.CreatedBy = creatorName;
                    contact.CreatedDate = currentTime;
                }
            }

            if (employee.EmployeeEducationalDetails != null)
            {
                foreach (var education in employee.EmployeeEducationalDetails)
                {
                    education.StatusInd = true; // Set StatusInd for nested forms
                    education.CreatedBy = creatorName;
                    education.CreatedDate = currentTime;
                }
            }

            if (employee.EmployeeExperienceDetails != null)
            {
                foreach (var experience in employee.EmployeeExperienceDetails)
                {
                    experience.StatusInd = true; // Set StatusInd for nested forms
                    experience.CreatedBy = creatorName;
                    experience.CreatedDate = currentTime;
                }
            }

            if (employee.EmployeeNationalityDocuments != null)
            {
                foreach (var document in employee.EmployeeNationalityDocuments)
                {
                    document.StatusInd = true; // Set StatusInd for nested forms
                    document.CreatedBy = creatorName;
                    document.CreatedDate = currentTime;
                }
            }
        }

        private void SetUpdateDetailsForNestedForms(EmployeeInformation employee, string updaterName, DateTime currentTime)
        {
            if (employee.EmployeeContactDetails != null)
            {
                foreach (var contact in employee.EmployeeContactDetails)
                {
                    contact.StatusInd = true; // Ensure StatusInd is true on update
                    contact.UpdatedBy = updaterName;
                    contact.UpdatedDate = currentTime;
                }
            }

            if (employee.EmployeeEducationalDetails != null)
            {
                foreach (var education in employee.EmployeeEducationalDetails)
                {
                    education.StatusInd = true; // Ensure StatusInd is true on update
                    education.UpdatedBy = updaterName;
                    education.UpdatedDate = currentTime;
                }
            }

            if (employee.EmployeeExperienceDetails != null)
            {
                foreach (var experience in employee.EmployeeExperienceDetails)
                {
                    experience.StatusInd = true; // Ensure StatusInd is true on update
                    experience.UpdatedBy = updaterName;
                    experience.UpdatedDate = currentTime;
                }
            }

            if (employee.EmployeeNationalityDocuments != null)
            {
                foreach (var document in employee.EmployeeNationalityDocuments)
                {
                    document.StatusInd = true; // Ensure StatusInd is true on update
                    document.UpdatedBy = updaterName;
                    document.UpdatedDate = currentTime;
                }
            }
        }
    }
}
