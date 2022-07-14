using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class EmployeeRolesController : ControllerBase
    {
        private IStationeryRepository<EmployeeRole> db_EmployeeRole;
        public EmployeeRolesController(IStationeryRepository<EmployeeRole> db_EmployeeRole)
        {
            this.db_EmployeeRole = db_EmployeeRole;
        }


        ///EmployeeRole
        [HttpGet("Categories")]
        public async Task<IEnumerable<EmployeeRole>> GetCategories()
        {
            return await db_EmployeeRole.ListAll();
        }
        [HttpGet("EmployeeRole")]
        public async Task<ActionResult<EmployeeRole>> GetEmployeeRole(int id)
        {
            return await db_EmployeeRole.GetById(id);
        }
        [HttpPost("CreateEmployeeRole")]
        public async Task<ActionResult<EmployeeRole>> CreateEmployeeRole([FromBody] EmployeeRole EmployeeRole)
        {

            await db_EmployeeRole.Insert(EmployeeRole);
            return CreatedAtAction(nameof(GetCategories), new { id = EmployeeRole.EmployeeRolesId }, EmployeeRole);
        }
        [HttpPut("UpdateEmployeeRole")]
        public async Task<ActionResult<EmployeeRole>> UpdateEmployeeRole([FromBody] EmployeeRole EmployeeRole)
        {
            var data = await db_EmployeeRole.GetById(EmployeeRole.EmployeeRolesId);
            if (data != null)
            {
                data.EmployeeId = EmployeeRole.EmployeeId;
                data.RoleId = EmployeeRole.RoleId;
                await db_EmployeeRole.Update(data);
                return Ok();
            }
            return NotFound();

        }
        [HttpDelete("EmployeeRoleId")]
        public async Task<ActionResult> DeleteEmployeeRole(int id)
        {
            var data = await db_EmployeeRole.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            await db_EmployeeRole.Delete(data);
            return NoContent();
        }
    }
}
