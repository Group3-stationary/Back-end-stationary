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
    //[Authorize]
    public class EmployeesController : ControllerBase
    {
        private IStationeryRepository<Employee> db_employee;
        private IRepositoryAll repositoryAll;
        Byte[] originalBytes;
        Byte[] encodedBytes;
        public MD5 md5;
        public EmployeesController(IStationeryRepository<Employee> db_employee, IRepositoryAll repositoryAll)
        {
            this.db_employee = db_employee;
            this.repositoryAll = repositoryAll;
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
            try
            {
                var updatePro = await db_employee.Update(employee);
                return Ok(updatePro);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpDelete("EmployeeId")]
        public async Task<ActionResult> DeleteEmployee(string id)
        {
            var data = await db_employee.GetById(id);
           
            if (data != null)
            {        
                 await db_employee.Delete(data);
                 return NoContent();          
            }
            return NotFound();
        }
    }
}
