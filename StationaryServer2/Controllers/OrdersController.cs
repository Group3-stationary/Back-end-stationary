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
    public class OrdersController : ControllerBase
    {
        private IStationeryRepository<Order> db_Order;
        public OrdersController(IStationeryRepository<Order> db_Order)
        {
            this.db_Order = db_Order;
        }


        ///Order
        [HttpGet("Categories")]
        public async Task<IEnumerable<Order>> GetCategories()
        {
            return await db_Order.ListAll();
        }
        [HttpGet("Order")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            return await db_Order.GetById(id);
        }
        [HttpPost("CreateOrder")]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] Order Order)
        {

            await db_Order.Insert(Order);
            return CreatedAtAction(nameof(GetCategories), new { id = Order.OrderId }, Order);
        }
        [HttpPut("UpdateOrder")]
        public async Task<ActionResult<Order>> UpdateOrder([FromBody] Order Order)
        {
            var data = await db_Order.GetById(Order.OrderId);
            if (data != null)
            {
                data.Status = Order.Status;
                data.UpdatedAt = Order.UpdatedAt;
                await db_Order.Update(data);
                return Ok();
            }
            return NotFound();

        }
        [HttpDelete("OrderId")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var data = await db_Order.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            await db_Order.Delete(data);
            return NoContent();
        }
    }
}
