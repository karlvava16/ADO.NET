using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        List<Good> goods1 = new List<Good>()
        {
            new Good() { Id = 1, Title = "Nokia 1100", Price = 450.99, Category = "Mobile" },
            new Good() { Id = 2, Title = "Iphone 4", Price = 5000, Category = "Mobile" },
            new Good() { Id = 3, Title = "Refregirator 5000", Price = 2555, Category = "Kitchen" },
            new Good() { Id = 4, Title = "Mixer", Price = 150, Category = "Kitchen" },
            new Good() { Id = 5, Title = "Magnitola", Price = 1499, Category = "Car" },
            new Good() { Id = 6, Title = "Samsung Galaxy", Price = 3100, Category = "Mobile" },
            new Good() { Id = 7, Title = "Auto Cleaner", Price = 2300, Category = "Car" },
            new Good() { Id = 8, Title = "Owen", Price = 700, Category = "Kitchen" },
            new Good() { Id = 9, Title = "Siemens Turbo", Price = 3199, Category = "Mobile" },
            new Good() { Id = 10, Title = "Lighter", Price = 150, Category = "Car" }
        };

        Task1(goods1);
        Task2(goods1);
        Task3(goods1);
        Task4(goods1);
        Task5(goods1);
        Task6(goods1);
        Task7(goods1);
    }


    public class Good
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }


    // Task 1
    public static void Task1(List<Good> goods)
    {
        Console.WriteLine("Task 1:");
        var mobileGoodsOver1000 = goods.Where(g => g.Category == "Mobile" && g.Price > 1000);
        foreach (var good in mobileGoodsOver1000)
        {
            Console.WriteLine($"Id: {good.Id}, Title: {good.Title}, Price: {good.Price}, Category: {good.Category}");
        }
        Console.WriteLine();
    }

    // Task 2
    public static void Task2(List<Good> goods)
    {
        Console.WriteLine("Task 2:");
        var nonKitchenGoodsOver1000 = goods.Where(g => g.Category != "Kitchen" && g.Price > 1000);
        foreach (var good in nonKitchenGoodsOver1000)
        {
            Console.WriteLine($"Title: {good.Title}, Price: {good.Price}");
        }
        Console.WriteLine();
    }

    // Task 3
    public static void Task3(List<Good> goods)
    {
        Console.WriteLine("Task 3:");
        double averagePrice = goods.Average(g => g.Price);
        Console.WriteLine($"Average Price: {averagePrice}");
        Console.WriteLine();
    }

    // Task 4
    public static void Task4(List<Good> goods)
    {
        Console.WriteLine("Task 4:");
        var categories = goods.Select(g => g.Category).Distinct();
        foreach (var category in categories)
        {
            Console.WriteLine(category);
        }
        Console.WriteLine();
    }

    // Task 5
    public static void Task5(List<Good> goods)
    {
        Console.WriteLine("Task 5:");
        var sortedGoods = goods.OrderBy(g => g.Title);
        foreach (var good in sortedGoods)
        {
            Console.WriteLine($"Title: {good.Title}, Category: {good.Category}");
        }
        Console.WriteLine();
    }

    // Task 6
    public static void Task6(List<Good> goods)
    {
        Console.WriteLine("Task 6:");
        int totalCarAndMobileGoods = goods.Count(g => g.Category == "Car" || g.Category == "Mobile");
        Console.WriteLine($"Total Car and Mobile Goods: {totalCarAndMobileGoods}");
        Console.WriteLine();
    }

    // Task 7
    public static void Task7(List<Good> goods)
    {
        Console.WriteLine("Task 7:");
        var categoryCounts = goods.GroupBy(g => g.Category).Select(g => new { Category = g.Key, Count = g.Count() });
        foreach (var categoryCount in categoryCounts)
        {
            Console.WriteLine($"Category: {categoryCount.Category}, Count: {categoryCount.Count}");
        }
        Console.WriteLine();
    }
}
