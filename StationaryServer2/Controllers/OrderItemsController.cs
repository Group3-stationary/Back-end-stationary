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
    public class OrderItemsController : ControllerBase
    {
        private IStationeryRepository<OrderItem> db_OrderItem;
        public OrderItemsController(IStationeryRepository<OrderItem> db_OrderItem)
        {
            this.db_OrderItem = db_OrderItem;
        }


        ///OrderItem
        [HttpGet("Categories")]
        public async Task<IEnumerable<OrderItem>> GetCategories()
        {
            return await db_OrderItem.ListAll();
        }
        [HttpGet("OrderItem")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        {
            return await db_OrderItem.GetById(id);
        }
        [HttpPost("CreateOrderItem")]
        public async Task<ActionResult<OrderItem>> CreateOrderItem([FromBody] OrderItem OrderItem)
        {

            await db_OrderItem.Insert(OrderItem);
            return CreatedAtAction(nameof(GetCategories), new { id = OrderItem.OrderItemId }, OrderItem);
        }
        [HttpPut("UpdateOrderItem")]
        public async Task<ActionResult> UpdateOrderItem([FromBody] OrderItem OrderItem)
        {
            var data = await db_OrderItem.GetById(OrderItem.OrderItemId);
            if (data != null)
            {
                await db_OrderItem.Update(data);
                return Ok();
            }
            return NotFound();

        }
        [HttpDelete("OrderItemId")]
        public async Task<ActionResult> DeleteOrderItem(int id)
        {
            var data = await db_OrderItem.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            await db_OrderItem.Delete(data);
            return NoContent();
        }
    }
}
