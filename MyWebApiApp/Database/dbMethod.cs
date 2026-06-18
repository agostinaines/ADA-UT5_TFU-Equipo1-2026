using Newtonsoft.Json;
using MyWebApiApp.Models;

namespace MyWebApiApp.Database;

public static class DbMethod
{
    private static Menu products;

    public static Menu GetMenu()
    {
        PopulateProductsData();
        return products;
    }

    static void PopulateProductsData()
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        string filePath = Path.Combine(currentDirectory, "Database/db.json");

        string json = File.ReadAllText(filePath);

        products = JsonConvert.DeserializeObject<Menu>(json);
    }
}