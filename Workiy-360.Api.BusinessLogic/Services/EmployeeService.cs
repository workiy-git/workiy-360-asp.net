using System;
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

        public async Task<string> AddOrUpdateAsync(EmployeeInformation employee, int flag)
        {
            try
            {
                if (flag == 3)
                {
                    return "No operation for flag 3"; // No operation
                }

                if (flag == 1)
                {
                    // Handle add operation
                    await _employeeRepository.AddAsync(employee);
                    return "Employee information added successfully.";
                }
                else if (flag == 2)
                {
                    // Handle update operation by phone number
                    var existingEmployee = await _employeeRepository.GetByPhoneNumberAsync(employee.MobileNo);
                    if (existingEmployee != null)
                    {
                        employee.EmployeeId = existingEmployee.EmployeeId; // Use existing employee ID
                        await _employeeRepository.UpdateAsync(employee);
                        return "Employee information updated successfully.";
                    }
                    else
                    {
                        // Add as a new record if phone number does not exist
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
    }
}