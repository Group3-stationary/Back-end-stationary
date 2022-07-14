using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationaryServer2.Models.Stationary;
using StationaryServer2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StationaryServer2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private IStationeryRepository<Employee> db_employee;
        Byte[] originalBytes;
        Byte[] encodedBytes;
        public MD5 md5;
        public EmployeesController(IStationeryRepository<Employee> db_employee)
        {
            this.db_employee = db_employee;
        }


        ///Employee
        [HttpGet("Employees")]
        public async Task<IEnumerable<Employee>> GetCategories()
        {
            return await db_employee.ListAll();
        }
        [HttpGet("Employee")]
        public async Task<ActionResult<Employee>> GetEmployee(string id)
        {
            return await db_employee.GetById(id);
        }
 
        string EncodePassword(string password)
        {
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(password);
            encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);
        }
        [HttpPost("CreateEmployee")]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee employee)
        {
            employee.Password = EncodePassword(employee.Password);
            await db_employee.Insert(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
        }
        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<Employee>> UpdateEmployee([FromBody] Employee employee)
        {
            var data = await db_employee.GetById(employee.EmployeeId);
            if (data != null)
            {
                data.EmployeeName = employee.EmployeeName;
                data.Email = employee.Email;
                data.Address = employee.Address;
                data.Birthday = employee.Birthday;
                data.Department = employee.Department;
                data.Password = EncodePassword(employee.Password);
                data.Phone = employee.Phone;
                data.Gender = employee.Gender;
                data.Superiors = employee.Superiors;
                data.IsAdmin = employee.IsAdmin;
                data.UpdatedAt = employee.UpdatedAt;
                await db_employee.Update(data);
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
