using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<Person> people = new List<Person>()
        {
            new Person(){ Name = "Andrey", Age = 24, City = "Kyiv"},
            new Person(){ Name = "Liza", Age = 18, City = "Odesa" },
            new Person(){ Name = "Oleg", Age = 15, City = "London" },
            new Person(){ Name = "Sergey", Age = 55, City = "Kyiv" },
            new Person(){ Name = "Sergey", Age = 32, City = "Lviv" }
        };

        // 1) Select people older than 25 years.
        var olderThan25 = people.Where(p => p.Age > 25).ToList();
        Console.WriteLine("People older than 25 years:");
        olderThan25.ForEach(p => Console.WriteLine($"{p.Name}, {p.Age}, {p.City}"));

        // 2) Select people who do not live in London.
        var notInLondon = people.Where(p => p.City != "London").ToList();
        Console.WriteLine("\nPeople who do not live in London:");
        notInLondon.ForEach(p => Console.WriteLine($"{p.Name}, {p.Age}, {p.City}"));

        // 3) Select names of people who live in Kyiv.
        var namesInKyiv = people.Where(p => p.City == "Kyiv").Select(p => p.Name).ToList();
        Console.WriteLine("\nNames of people who live in Kyiv:");
        namesInKyiv.ForEach(name => Console.WriteLine(name));

        // 4) Select people older than 35 years with the name Sergey.
        var sergeysOlderThan35 = people.Where(p => p.Name == "Sergey" && p.Age > 35).ToList();
        Console.WriteLine("\nPeople older than 35 years with the name Sergey:");
        sergeysOlderThan35.ForEach(p => Console.WriteLine($"{p.Name}, {p.Age}, {p.City}"));

        // 5) Select people who live in Odesa.
        var inOdesa = people.Where(p => p.City == "Odesa").ToList();
        Console.WriteLine("\nPeople who live in Odesa:");
        inOdesa.ForEach(p => Console.WriteLine($"{p.Name}, {p.Age}, {p.City}"));
    }
}
