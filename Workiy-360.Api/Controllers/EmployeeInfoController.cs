using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Workiy_360.Api.BusinessLogic.Interfaces;
using Workiy_360.EntityFramework;
using Workiy_360.Models;

namespace Workiy_360.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeInfoController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeInfoController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("addemployeeinfo")]
        public async Task<IActionResult> AddOrUpdate([FromBody] EmployeeInformation employee, [FromQuery] int flag)
        {
            if (employee == null)
            {
                return BadRequest("Employee information is required.");
            }

            try
            {
                var resultMessage = await _employeeService.AddOrUpdateAsync(employee, flag);
                if (flag == 3)
                {
                    return BadRequest(resultMessage);
                }

                return Ok(resultMessage);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getemployeeinfo/phonenumber")]
        public async Task<IActionResult> GetByPhoneNumber([FromQuery] string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return BadRequest("Phone number is required.");
            }

            try
            {
                var employee = await _employeeService.GetByPhoneNumberAsync(phoneNumber);
                if (employee == null)
                {
                    return NotFound("Employee not found.");
                }

                var welcomeMessage = string.IsNullOrWhiteSpace(employee.FirstName)
                    ? "Welcome to Workiy Preonboarding."
                    : $"Welcome {employee.FirstName} {employee.LastName}";

                return Ok(new { Message = welcomeMessage, Employee = employee });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
