using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;
using MyWebApiApp.Database;
using Microsoft.VisualBasic;

namespace MyWebApiApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private List<Product> products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99M },
        new Product { Id = 2, Name = "Phone", Price = 699.99M }
    };

    // GET: api/products
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        return Ok(products);
    }

    // GET: api/products/1
    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = products.Find(p => p.Id == id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public ActionResult<Product> AddProduct(Product product)
    {
        products.Add(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }
}