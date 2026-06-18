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
/*
    // GET: api/products
    [HttpGet("products")]
    public ActionResult<Menu> GetProducts()
    {
        return Ok(menu.Products);
    }

    // GET: api/combos
    [HttpGet("combos")]
    public ActionResult<Menu> GetCombos()
    {
        return Ok(menu.Combos);
    }

    // GET: api/paymentMethods
    [HttpGet("paymentMethods")]
    public ActionResult<Menu> GetPaymentMethods()
    {
        return Ok(menu.PaymentMethods);
    }

    // GET: api/products/1
    [HttpGet("products/{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = menu.Products.Find(p => p.ProductId == id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }

    // GET: api/combos/1
    [HttpGet("combos/{id}")]
    public ActionResult<Product> GetCombo(int id)
    {
        var product = menu.Combos.Find(c => c.ComboId == id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public ActionResult<Product> AddProduct(Product product)
    {
        menu.menu.Add(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
    }*/
}