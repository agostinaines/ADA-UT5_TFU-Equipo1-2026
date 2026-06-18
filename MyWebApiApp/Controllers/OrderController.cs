using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;
using MyWebApiApp.Database;

namespace MyWebApiApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    // POST: api/orders
    [HttpPost("newOrder")]
    public ActionResult<Order> AddOrder([FromBody] Order order)
    {
        var currentOrders = DbMethod.GetOrders();
        currentOrders.orders.Add(order);
        DbMethod.PostNewOrder(currentOrders);

        return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
    }

    // GET: api/orders
    [HttpGet]
    public ActionResult<Orders> GetOrders()
    {
        var currentOrders = DbMethod.GetOrders();
        return Ok(currentOrders.orders);
    }

    // GET: api/orders/1
    [HttpGet("{id}")]
    public ActionResult<Order> GetOrder(int id)
    {
        var currentOrders = DbMethod.GetOrders();
        var order = currentOrders.orders.Find(o => o.OrderId == id);
        if (order == null)
            return NotFound();

        return Ok(order);
    }

    // PUT: api/orders/1
    [HttpPut("{id}")]
    public ActionResult<Order> UpdateOrder(int id, Order updatedOrder)
    {
        var currentOrders = DbMethod.GetOrders();
        var orderIndex = currentOrders.orders.FindIndex(o => o.OrderId == id);
        if (orderIndex < 0)
            return NotFound();

        DeleteOrder(id);
        currentOrders.orders[orderIndex] = updatedOrder;
        DbMethod.UpdateOrdersFile(currentOrders);

        return Ok(updatedOrder);
    }

    // DELETE: api/orders/1
    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(int id)
    {
        var currentOrders = DbMethod.GetOrders();
        var orderIndex = currentOrders.orders.FindIndex(o => o.OrderId == id);
        if (orderIndex < 0)
            return NotFound();

        currentOrders.orders.RemoveAt(orderIndex);
        DbMethod.UpdateOrdersFile(currentOrders);

        return NoContent();
    }

    // GET: api/payments
    [HttpGet("payments")]
    public ActionResult<Payment> GetPayments()
    {
        var currentPayments = DbMethod.GetPayments();
        return Ok(currentPayments.AllPayments);
    }

    // POST: api/orders/pay
    [HttpPost("pay")]
    public IActionResult PayOrder(Payment payment)
    {
        var currentPayments = DbMethod.GetPayments();
        currentPayments.AllPayments.Add(payment);
        DbMethod.UpdatePaymentsFile(currentPayments);

        return CreatedAtAction(nameof(PayOrder), new { id = payment.OrderId }, payment);
    }
}