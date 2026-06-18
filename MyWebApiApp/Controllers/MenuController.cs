using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;
using MyWebApiApp.Database;
using Microsoft.VisualBasic;

namespace MyWebApiApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenuController : ControllerBase
{
    private readonly Menu menu = DbMethod.GetMenu();

    // GET: api/menu/categories
    [HttpGet("categories")]
    public ActionResult<Menu> GetCategories()
    {
        return Ok(menu.Category);
    }

    // GET: api/menu/products
    [HttpGet("products")]
    public ActionResult<Menu> GetProducts()
    {
        return Ok(menu.Products);
    }

    // GET: api/menu/combos
    [HttpGet("combos")]
    public ActionResult<Menu> GetCombos()
    {
        return Ok(menu.Combos);
    }

    // GET: api/menu/paymentMethods
    [HttpGet("paymentMethods")]
    public ActionResult<Menu> GetPaymentMethods()
    {
        return Ok(menu.PaymentMethods);
    }

    // GET: api/menu/products/1
    [HttpGet("products/{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = menu.Products.Find(p => p.ProductId == id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }

    // GET: api/menu/products/category/1
    [HttpGet("products/category/{categoryId}")]
    public ActionResult<Product> GetProductByCategory(int categoryId)
    {
        var productsByCategory = new List<Product>();

        foreach (var product in menu.Products)
        {
            if (product.CategoryId == categoryId)
            {
                productsByCategory.Add(product);
            }
        }

        return Ok(productsByCategory);
    }

    // GET: api/menu/combos/1
    [HttpGet("combos/{id}")]
    public ActionResult<Product> GetCombo(int id)
    {
        var product = menu.Combos.Find(c => c.ComboId == id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }
}