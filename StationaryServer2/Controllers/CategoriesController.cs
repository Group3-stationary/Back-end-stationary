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
    public class CategoriesController : ControllerBase
    {
        private IStationeryRepository<Category> db_category;
        public CategoriesController(IStationeryRepository<Category> db_category)
        {
            this.db_category = db_category;
        }


        ///Category
        [HttpGet("Categories")]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await db_category.ListAll();
        }
        [HttpGet("Category")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            return await db_category.GetById(id);
        }
        [HttpPost("CreateCategory")]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] Category category)
        {
            
           await db_category.Insert(category);
            return CreatedAtAction(nameof(GetCategories), new { id = category.CategotyId }, category);
        }
        [HttpPut("UpdateCategory")]
        public async Task<ActionResult> UpdateCategory([FromBody] Category category)
        {
            var data = await db_category.GetById(category.CategotyId);
            if (data!= null)
            {
                await db_category.Update(data);
                return Ok();
            }
            return NotFound();
            
        }
        [HttpDelete("CategoryId")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var data = await db_category.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            await db_category.Delete(data);
            return NoContent();
        }
    }
}
