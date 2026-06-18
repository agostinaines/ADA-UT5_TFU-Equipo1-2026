namespace MyWebApiApp.Models;

public class Orders
{
    public List<Order> orders { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public string ClientName { get; set; }
    public decimal TotalPrice { get; set; }
    public int PaymentMethodId { get; set; }
    public List<Item> Items { get; set; }
}