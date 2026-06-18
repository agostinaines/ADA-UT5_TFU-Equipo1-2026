namespace MyWebApiApp.Models;

public class Combo
{
    public int ComboId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public List<Item> Items { get; set; }
}

public class Item
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}