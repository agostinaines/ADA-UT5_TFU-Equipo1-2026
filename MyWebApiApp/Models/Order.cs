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
    public List<OrderItem> Items { get; set; }
}

public class OrderItem
{
    public int ItemId { get; set; }
    public int Quantity { get; set; }
}