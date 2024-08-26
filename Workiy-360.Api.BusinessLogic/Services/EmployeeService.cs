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
            var isUpdateOperation = flag == 2;
            var validationErrors = ValidateEmployeeInformation(employee, isUpdateOperation);

            if (validationErrors.Count > 0)
            {
                return $"Validation failed: {string.Join("; ", validationErrors)}";
            }

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

                        await _employeeRepository.UpdateAsync(employee);
                        return "Employee information updated successfully.";
                    }
                    else
                    {
                        // Add as a new record if phone number does not exist
                        employee.StatusInd = true;
                        employee.CreatedBy = $"{employee.FirstName} {employee.LastName}";
                        employee.CreatedDate = currentTime;

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

        private List<string> ValidateEmployeeInformation(EmployeeInformation employee, bool isUpdateOperation)
        {
            var errors = new List<string>();

            // Basic fields validation
            if (string.IsNullOrWhiteSpace(employee.FirstName))
                errors.Add("First name is required.");

            if (string.IsNullOrWhiteSpace(employee.LastName))
                errors.Add("Last name is required.");

            // Validate mobile number
            if (string.IsNullOrWhiteSpace(employee.MobileNo))
                errors.Add("Mobile number is required.");
            else if (employee.MobileNo.Length != 10 || !long.TryParse(employee.MobileNo, out _))
                errors.Add("A valid 10-digit mobile number is required.");

            // Validate date of birth
            if (employee.DateOfBirth == null)
                errors.Add("Date of birth is required.");
            else
            {
                var dob = employee.DateOfBirth.Value;
                var today = DateOnly.FromDateTime(DateTime.Now);
                if (dob > today)
                    errors.Add("Date of birth cannot be a future date.");
            }

            if (string.IsNullOrWhiteSpace(employee.Gender))
                errors.Add("Gender is required.");

            // Validate address details
            if (employee.EmployeeAddressDetails == null || employee.EmployeeAddressDetails.Count == 0)
                errors.Add("At least one address detail is required.");
            else
            {
                foreach (var address in employee.EmployeeAddressDetails)
                {
                    // Skip ID validation for new records
                    if (isUpdateOperation && address.AddressPkId <= 0)
                        errors.Add("Address ID is invalid.");

                    if (string.IsNullOrWhiteSpace(address.Address1))
                        errors.Add("Address1 is required.");

                    if (string.IsNullOrWhiteSpace(address.City))
                        errors.Add("City is required.");

                    if (string.IsNullOrWhiteSpace(address.State))
                        errors.Add("State is required.");

                    if (string.IsNullOrWhiteSpace(address.Country))
                        errors.Add("Country is required.");

                    if (address.Pincode <= 0 || address.Pincode.ToString().Length != 6)
                        errors.Add("A valid 5-digit pincode is required.");
                }
            }

            // Validate contact details
            if (employee.EmployeeContactDetails != null)
            {
                foreach (var contact in employee.EmployeeContactDetails)
                {
                    // Skip ID validation for new records
                    if (isUpdateOperation && contact.ContactPkId <= 0)
                        errors.Add("Contact ID is invalid.");

                    if (string.IsNullOrWhiteSpace(contact.EmergencyConName))
                        errors.Add("Emergency contact name is required.");

                    if (string.IsNullOrWhiteSpace(contact.ConNum))
                        errors.Add("Emergency contact number is required.");
                    else if (contact.ConNum.Length != 10 || !long.TryParse(contact.ConNum, out _))
                        errors.Add("A valid 10-digit emergency contact number is required.");
                }
            }

            // Validate educational details
            if (employee.EmployeeEducationalDetails != null)
            {
                foreach (var education in employee.EmployeeEducationalDetails)
                {
                    // Skip ID validation for new records
                    if (isUpdateOperation && education.EducationalPkId <= 0)
                        errors.Add("Educational ID is invalid.");

                    if (string.IsNullOrWhiteSpace(education.NameOfTheDegree))
                        errors.Add("Name of the degree is required.");

                    if (string.IsNullOrWhiteSpace(education.Institute))
                        errors.Add("Institute name is required.");

                    if (string.IsNullOrWhiteSpace(education.Major))
                        errors.Add("Major is required.");

                    if (education.YearOfCompletion == default)
                        errors.Add("Year of completion is required.");
                }
            }

            // Validate experience details
            if (employee.EmployeeExperienceDetails != null)
            {
                foreach (var experience in employee.EmployeeExperienceDetails)
                {
                    // Skip ID validation for new records
                    if (isUpdateOperation && experience.ExpId <= 0)
                        errors.Add("Experience ID is invalid.");

                    if (string.IsNullOrWhiteSpace(experience.CompanyName))
                        errors.Add("Company name is required.");

                    if (string.IsNullOrWhiteSpace(experience.Designation))
                        errors.Add("Designation is required.");

                    if (experience.StartDate == default)
                        errors.Add("Start date is required.");

                    if (experience.EndDate == default)
                        errors.Add("End date is required.");

                    if (experience.EndDate < experience.StartDate)
                        errors.Add("End date cannot be before start date.");
                }
            }

            // Validate nationality documents
            if (employee.EmployeeNationalityDocuments != null)
            {
                foreach (var document in employee.EmployeeNationalityDocuments)
                {
                    // Skip ID validation for new records
                    if (isUpdateOperation && document.NatPkId <= 0)
                        errors.Add("Nationality document ID is invalid.");

                    if (string.IsNullOrWhiteSpace(document.NationalityGpName))
                        errors.Add("Nationality document name is required.");

                    if (string.IsNullOrWhiteSpace(document.NationalityGpNumber))
                        errors.Add("Nationality document number is required.");
                }
            }

            return errors;
        }
    }
}
