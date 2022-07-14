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
    public class PermissonRolesController : ControllerBase
    {
        private IStationeryRepository<PermissionRole> db_PermissionRole;
        public PermissonRolesController(IStationeryRepository<PermissionRole> db_PermissionRole)
        {
            this.db_PermissionRole = db_PermissionRole;
        }


        ///PermissionRole
        [HttpGet("Categories")]
        public async Task<IEnumerable<PermissionRole>> GetCategories()
        {
            return await db_PermissionRole.ListAll();
        }
        [HttpGet("PermissionRole")]
        public async Task<ActionResult<PermissionRole>> GetPermissionRole(int id)
        {
            return await db_PermissionRole.GetById(id);
        }
        [HttpPost("CreatePermissionRole")]
        public async Task<ActionResult<PermissionRole>> CreatePermissionRole([FromBody] PermissionRole PermissionRole)
        {

            await db_PermissionRole.Insert(PermissionRole);
            return CreatedAtAction(nameof(GetCategories), new { id = PermissionRole.PermissionRoleId }, PermissionRole);
        }
        [HttpPut("UpdatePermissionRole")]
        public async Task<ActionResult<PermissionRole>> UpdatePermissionRole([FromBody] PermissionRole PermissionRole)
        {
            var data = await db_PermissionRole.GetById(PermissionRole.PermissionRoleId);
            if (data != null)
            {
                data.PermissionId = PermissionRole.PermissionId;
                data.RoleId = PermissionRole.RoleId;
                data.UpdatedAt = PermissionRole.UpdatedAt;
                await db_PermissionRole.Update(data);
                return Ok();
            }
            return NotFound();

        }
        [HttpDelete("PermissionRoleId")]
        public async Task<ActionResult> DeletePermissionRole(int id)
        {
            var data = await db_PermissionRole.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            await db_PermissionRole.Delete(data);
            return NoContent();
        }
    }
}
