using Newtonsoft.Json;

namespace MyWebApiApp.Models;

public class Menu
{
    [JsonProperty("categories")]
    public List<Category> Category { get; set; }
    public List<Product> Products { get; set; }
    public List<Combo> Combos { get; set; }
    public List<PaymentMethod> PaymentMethods { get; set; }
}