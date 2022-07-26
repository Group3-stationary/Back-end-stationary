using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StationaryServer2.DTO.User.Request;
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
    public class OrderItemsController : ControllerBase
    {
        private IStationeryRepository<OrderItem> db_OrderItem;
        private IStationeryRepository<Order> db_Order;
        public OrderItemsController(IStationeryRepository<OrderItem> db_OrderItem,IStationeryRepository<Order> db_Order)
        {
            this.db_OrderItem = db_OrderItem;
            this.db_Order = db_Order;
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
        
        [HttpPut("UpdateOrderItem")]
        public async Task<ActionResult<OrderItem>> UpdateOrderItem([FromBody] OrderItem OrderItem)
        {
            try
            {
                var updatePro = await db_OrderItem.Update(OrderItem);
                return Ok(updatePro);
            }
            catch (Exception)
            {
                return BadRequest();
            }

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

        [HttpPost("CreateOrderItem")]

        public async Task<ActionResult> CreateOrderItem([FromBody] OrderRequest orderRequest)
        {
            try
            {
                Order order = new Order()
                {
                    EmployeeId = orderRequest.EmployeeId
                };

                await db_Order.Insert(order);
                List<Order> orders = await db_Order.ListAll();
                int newOrderId = orders.Count - 1;
                List<OrderItemRequest> orderItems = (List<OrderItemRequest>)orderRequest.Products;
                foreach (OrderItemRequest item in orderItems)
                {
                    OrderItem orderItem = new OrderItem()
                    {
                        OrderId = newOrderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    };
                    await db_OrderItem.Insert(orderItem);
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
