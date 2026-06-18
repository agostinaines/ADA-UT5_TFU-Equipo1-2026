using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;
using MyWebApiApp.Database;
using Microsoft.VisualBasic;

namespace MyWebApiApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    public readonly Orders orders = DbMethod.GetOrders();

    // POST: api/order/newOrder
    [HttpPost]
    public ActionResult<Product> AddProduct(Order order)
    {
        orders.orders.Add(order);
        
        return CreatedAtAction(nameof(order), new { id = order.OrderId }, order);
    }

    // GET: api/order/orders
    [HttpGet]
    public ActionResult<Orders> GetOrders()
    {
        return Ok(orders.orders);
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