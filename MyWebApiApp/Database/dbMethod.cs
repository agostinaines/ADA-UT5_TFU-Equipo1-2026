using Newtonsoft.Json;
using MyWebApiApp.Models;

namespace MyWebApiApp.Database;

public static class DbMethod
{
    private static Menu menu;
    private static Orders orders;

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
        PopulateNewOrder(orders);
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

    static void PopulateNewOrder(Orders orders)
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        string filePath = Path.Combine(currentDirectory, "Database/orders.json");

        string ordersToString = orders.ToString();

        File.WriteAllText(filePath, ordersToString);
    }
}