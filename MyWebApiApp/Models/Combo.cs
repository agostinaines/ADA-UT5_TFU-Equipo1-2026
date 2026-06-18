namespace MyWebApiApp.Models;

public class Combo
{
    public int ComboId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public List<ComboItem> Items { get; set; }
}

public class ComboItem
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}