using Newtonsoft.Json;
using MyWebApiApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApiApp.Database;

public static class DbMethod
{
    private static Menu menu;
    private static Orders orders;
    private static Payments payments; 

    public static Menu GetMenu()
    {
        PopulateMenuData();
        return menu;
    }

    public static Orders GetOrders()
    {
        PopulateOrdersData();
        return orders;
    }

    public static void PostNewOrder(Orders orders)
    {
        SaveOrders(orders);
    }

    public static void UpdateOrdersFile(Orders orders)
    {
        SaveOrders(orders);
    }

    public static Payments GetPayments()
    {
        PopulatePaymentsData();
        return payments;
    }

    public static void UpdatePaymentsFile(Payments payments)
    {
        PayOrder(payments);
    }

    static void PopulateMenuData()
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        string filePath = Path.Combine(currentDirectory, "Database/db.json");

        string json = File.ReadAllText(filePath);

        menu = JsonConvert.DeserializeObject<Menu>(json);
    }

    static void PopulateOrdersData()
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        string filePath = Path.Combine(currentDirectory, "Database/orders.json");

        string json = File.ReadAllText(filePath);

        orders = JsonConvert.DeserializeObject<Orders>(json);
    }

    static void SaveOrders(Orders orders)
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        string filePath = Path.Combine(currentDirectory, "Database/orders.json");

        string ordersToString = JsonConvert.SerializeObject(orders, Formatting.Indented);

        File.WriteAllText(filePath, ordersToString);
    }

    static void PopulatePaymentsData()
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(currentDirectory, "Database/payments.json");

        string json = File.ReadAllText(filePath);

        payments = JsonConvert.DeserializeObject<Payments>(json);

        payments ??= new Payments();
    }

    static void PayOrder(Payments payments)
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        string filePath = Path.Combine(currentDirectory, "Database/payments.json");

        string paymentsToString = JsonConvert.SerializeObject(payments, Formatting.Indented);

        File.WriteAllText(filePath, paymentsToString);
    }
}