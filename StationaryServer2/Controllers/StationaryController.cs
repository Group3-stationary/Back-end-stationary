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
        private ICategoryRepository category;
        public StationaryController(ICategoryRepository category)
        {
            this.category = category;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await category.GetCategories();
        }
    }
}
