using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationaryServer2.Models.Stationary;
using StationaryServer2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationaryServer2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IStationeryRepository<Employee> db_employee;
        public EmployeesController(IStationeryRepository<Employee> db_employee)
        {
            this.db_employee = db_employee;
        }


        ///Employee
        [HttpGet("Categories")]
        public async Task<IEnumerable<Employee>> GetCategories()
        {
            return await db_employee.ListAll();
        }
        [HttpGet("Employee")]
        public async Task<ActionResult<Employee>> GetEmployee(string id)
        {
            return await db_employee.GetById(id);
        }
        [HttpPost("CreateEmployee")]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee Employee)
        {

            await db_employee.Insert(Employee);
            return CreatedAtAction(nameof(GetCategories), new { id = Employee.EmployeeId }, Employee);
        }
        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            var data = await db_employee.GetById(employee.EmployeeId);
            if (data != null)
            {
                await db_employee.Update(employee);
                return Ok();
            }
            return NotFound();

        }
        [HttpDelete("EmployeeId")]
        public async Task<ActionResult> DeleteEmployee(string id)
        {
            var data = await db_employee.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            await db_employee.Delete(data);
            return NoContent();
        }
    }
}
