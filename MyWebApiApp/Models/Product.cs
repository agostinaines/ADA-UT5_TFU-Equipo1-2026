namespace MyWebApiApp.Models;

public class Product
{
    public int CategoryId { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public List<Ingredient> Ingredients { get; set; }
}

public class Ingredient
{
    public int IngredientId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}