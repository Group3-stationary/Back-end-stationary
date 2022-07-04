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
    public class PermissionsController : ControllerBase
    {
        private IStationeryRepository<Permission> db_Permission;
        public PermissionsController(IStationeryRepository<Permission> db_Permission)
        {
            this.db_Permission = db_Permission;
        }


        ///Permission
        [HttpGet("Categories")]
        public async Task<IEnumerable<Permission>> GetCategories()
        {
            return await db_Permission.ListAll();
        }
        [HttpGet("Permission")]
        public async Task<ActionResult<Permission>> GetPermission(int id)
        {
            return await db_Permission.GetById(id);
        }
        [HttpPost("CreatePermission")]
        public async Task<ActionResult<Permission>> CreatePermission([FromBody] Permission Permission)
        {

            await db_Permission.Insert(Permission);
            return CreatedAtAction(nameof(GetCategories), new { id = Permission.PermissionsId }, Permission);
        }
        [HttpPut("UpdatePermission")]
        public async Task<ActionResult> UpdatePermission([FromBody] Permission Permission)
        {
            var data = await db_Permission.GetById(Permission.PermissionsId);
            if (data != null)
            {
                await db_Permission.Update(data);
                return Ok();
            }
            return NotFound();

        }
        [HttpDelete("PermissionId")]
        public async Task<ActionResult> DeletePermission(int id)
        {
            var data = await db_Permission.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            await db_Permission.Delete(data);
            return NoContent();
        }
    }
}
