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
    public class ProductsController : ControllerBase
    {
        private IStationeryRepository<Product> db_Product;
        public ProductsController(IStationeryRepository<Product> db_Product)
        {
            this.db_Product = db_Product;
        }


        ///Product
        [HttpGet("Categories")]
        public async Task<IEnumerable<Product>> GetCategories()
        {
            return await db_Product.ListAll();
        }
        [HttpGet("Product")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await db_Product.GetById(id);
        }
        [HttpPost("CreateProduct")]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product Product)
        {

            await db_Product.Insert(Product);
            return CreatedAtAction(nameof(GetCategories), new { id = Product.ProductId }, Product);
        }
        [HttpPut("UpdateProduct")]
        public async Task<ActionResult> UpdateProduct([FromBody] Product Product)
        {
            var data = await db_Product.GetById(Product.ProductId);
            if (data != null)
            {
                await db_Product.Update(data);
                return Ok();
            }
            return NotFound();

        }
        [HttpDelete("ProductId")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var data = await db_Product.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            await db_Product.Delete(data);
            return NoContent();
        }
    }
}
