namespace MyWebApiApp.Models;

public class PaymentMethod
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Payment
{
    public int OrderId { get; set; }
    public int MontoTotal { get; set; }
    public int PaymentMethodId { get; set; }

}

public class Payments
{
    public List<Payment> AllPayments { get; set; } = new();
}