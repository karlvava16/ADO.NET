using System;
using System.Linq;
using CountryDBContext;
using Microsoft.EntityFrameworkCore;
using Models;

namespace CountryConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CountryDbContext())
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                while (true)
                {
                    Console.WriteLine("Country Database Management");
                    Console.WriteLine("1. Display All Countries");
                    Console.WriteLine("2. Add Country");
                    Console.WriteLine("3. Update Country");
                    Console.WriteLine("4. Delete Country");
                    Console.WriteLine("5. Exit");
                    Console.Write("Select an option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            DisplayAllCountries(context);
                            break;
                        case "2":
                            AddCountry(context);
                            break;
                        case "3":
                            UpdateCountry(context);
                            break;
                        case "4":
                            DeleteCountry(context);
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }

        static void DisplayAllCountries(CountryDbContext context)
        {
            var countries = context.Countries.Include(c => c.Continent).ToList();
            Console.WriteLine("All Countries:");
            foreach (var country in countries)
            {
                Console.WriteLine($"Name: {country.Name}, Capital: {country.Capital}, Population: {country.Population}, Area: {country.Area}, Continent: {country.Continent.Name}");
            }
            Console.WriteLine();
        }

        static void AddCountry(CountryDbContext context)
        {
            Console.Write("Enter Country Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Capital: ");
            string capital = Console.ReadLine();
            Console.Write("Enter Population: ");
            long population = long.Parse(Console.ReadLine());
            Console.Write("Enter Area: ");
            double area = double.Parse(Console.ReadLine());
            Console.Write("Enter Continent Name: ");
            string continentName = Console.ReadLine();

            var continent = context.Continents.FirstOrDefault(c => c.Name == continentName);
            if (continent == null)
            {
                Console.WriteLine($"Continent '{continentName}' not found.");
                return;
            }

            var country = new Country
            {
                Name = name,
                Capital = capital,
                Population = population,
                Area = area,
                Continent = continent
            };

            context.Countries.Add(country);
            context.SaveChanges();
            Console.WriteLine($"Country '{country.Name}' added.");
        }

        static void UpdateCountry(CountryDbContext context)
        {
            Console.Write("Enter Country Name to Update: ");
            string countryName = Console.ReadLine();

            var country = context.Countries.Include(c => c.Continent).FirstOrDefault(c => c.Name == countryName);
            if (country == null)
            {
                Console.WriteLine($"Country '{countryName}' not found.");
                return;
            }

            Console.Write("Enter New Capital: ");
            string capital = Console.ReadLine();
            Console.Write("Enter New Population: ");
            long population = long.Parse(Console.ReadLine());
            Console.Write("Enter New Area: ");
            double area = double.Parse(Console.ReadLine());
            Console.Write("Enter New Continent Name: ");
            string continentName = Console.ReadLine();

            var continent = context.Continents.FirstOrDefault(c => c.Name == continentName);
            if (continent == null)
            {
                Console.WriteLine($"Continent '{continentName}' not found.");
                return;
            }

            country.Capital = capital;
            country.Population = population;
            country.Area = area;
            country.Continent = continent;

            context.SaveChanges();
            Console.WriteLine($"Country '{country.Name}' updated.");
        }

        static void DeleteCountry(CountryDbContext context)
        {
            Console.Write("Enter Country Name to Delete: ");
            string countryName = Console.ReadLine();

            var country = context.Countries.Include(c => c.Continent).FirstOrDefault(c => c.Name == countryName);
            if (country == null)
            {
                Console.WriteLine($"Country '{countryName}' not found.");
                return;
            }

            context.Countries.Remove(country);
            context.SaveChanges();
            Console.WriteLine($"Country '{country.Name}' deleted.");
        }
    }
}
