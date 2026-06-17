using Newtonsoft.Json;
using MyWebApiApp.Models;

namespace MyWebApiApp.Database;

public class DbMethod
{
    private List<Product> products;
    private List<PaymentMethod> paymentMethods;

    public List<Product> GetProducts()
    {
        PopulateProductsData();
        return products;
    }

    public List<PaymentMethod> GetPaymentMethod()
    {
        PopulatePaymentsData();
        return paymentMethods;
    }

    void PopulateProductsData()
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        string filePath = Path.Combine(currentDirectory, "products.json");

        string json = File.ReadAllText(filePath);

        products = JsonConvert.DeserializeObject<List<Product>>(json);
    }

    void PopulatePaymentsData()
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        string filePath = Path.Combine(currentDirectory, "payments.json");

        string json = File.ReadAllText(filePath);

        paymentMethods = JsonConvert.DeserializeObject<List<PaymentMethod>>(json);
    }
    
}