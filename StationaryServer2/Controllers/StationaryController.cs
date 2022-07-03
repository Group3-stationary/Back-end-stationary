using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationaryServer2.Models.Stationary;
using StationaryServer2.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StationaryServer2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationaryController : ControllerBase
    {
        private ICategoryRepository db_category;
        public StationaryController(ICategoryRepository db_category)
        {
            this.db_category = db_category;
        }

        [HttpGet("Categories")]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await db_category.GetCategories();
        }
        [HttpGet("Category")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            return await db_category.GetCategory(id);
        }
        [HttpPost("CreateCategory")]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] Category category)
        {
            var newCategory = await db_category.CreateCategory(category);
            return CreatedAtAction(nameof(GetCategories), new { id = newCategory.CategotyId }, newCategory);
        }
        [HttpPut("UpdateCategory")]
        public async Task<ActionResult> UpdateCategory([FromBody] Category category)
        {
            await db_category.UpdateCategory(category);
            return NoContent();
        }
        [HttpDelete("CategoryId")]
        public async Task<ActionResult> UpdateCategory(int id)
        {
            var data = db_category.GetCategory(id);
            if (data == null)
            {
                return NotFound();
            }
            await db_category.DeleteCategory(id);
            return NoContent();
        }

    }
}
