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
    public class OrdersController : ControllerBase
    {
        private IStationeryRepository<Order> db_Order;
        private IStationeryRepository<Notification> db_Notification;
        private IStationeryRepository<Employee> db_Employee;
        public OrdersController(IStationeryRepository<Order> db_Order, IStationeryRepository<Notification> db_Notification, IStationeryRepository<Employee> db_Employee)
        {
            this.db_Order = db_Order;
            this.db_Notification = db_Notification;
            this.db_Employee = db_Employee;
        }


        ///Order
        [HttpGet("Orders")]
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
            try
            {   
                var updatePro = await db_Order.Update(Order);
                Employee employee = await db_Employee.GetById(Order.EmployeeId);
                Employee superior = await db_Employee.GetById(employee.Superiors);
                string message = "";
                if (Order.Status == "Approved")
                {
                    message = "approved";
                }else if(Order.Status == "Rejected")
                {
                    message = "rejected";
                }
                Notification notification = new Notification()
                {
                    SenderId = employee.Superiors,
                    ReceiveId = Order.EmployeeId,
                    CreatedAt = Order.UpdatedAt,
                    Status = "Unseen",
                    Message = "Superior " + superior.EmployeeName + " has just "+ message+ " your order at " + Order.UpdatedAt
                };
                string checkSuperior = superior.Superiors;
                if(checkSuperior != "" && Order.Status != "Rejected")
                {
                    Notification notificationS = new Notification()
                    {
                        SenderId = superior.EmployeeId,
                        ReceiveId = checkSuperior,
                        CreatedAt = Order.UpdatedAt,
                        Status = "Unseen",
                        Message = "Superior " + superior.EmployeeName + " has just approved new order at " + Order.UpdatedAt
                    };
                    await db_Notification.Insert(notificationS);
                }
                await db_Notification.Insert(notification);
                return Ok(updatePro);
            }
            catch (Exception)
            {
                return BadRequest();
            }

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
