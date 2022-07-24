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
    //[Authorize]
    public class RolesController : ControllerBase
    {
        private IStationeryRepository<Role> db_Role;
        public RolesController(IStationeryRepository<Role> db_Role)
        {
            this.db_Role = db_Role;
        }


        ///Role
        [HttpGet("Roles")]
        public async Task<IEnumerable<Role>> GetCategories()
        {
            return await db_Role.ListAll();
        }
        [HttpGet("Role")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            return await db_Role.GetById(id);
        }
        [HttpPost("CreateRole")]
        public async Task<ActionResult<Role>> CreateRole([FromBody] Role Role)
        {

            await db_Role.Insert(Role);
            return CreatedAtAction(nameof(GetCategories), new { id = Role.RoleId }, Role);
        }
        [HttpPut("UpdateRole")]
        public async Task<ActionResult<Role>> UpdateRole([FromBody] Role Role)
        {
            try
            {
                var updatePro = await db_Role.Update(Role);
                return Ok(updatePro);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpDelete("RoleId")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            var data = await db_Role.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            await db_Role.Delete(data);
            return NoContent();
        }
    }
}
