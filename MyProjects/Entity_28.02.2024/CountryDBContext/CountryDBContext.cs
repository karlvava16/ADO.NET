using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Models;
using System;
using System.IO;

namespace CountryDBContext
{
    public class CountryDbContext : DbContext
    {
        static DbContextOptions<CountryDbContext> _options;

        public DbSet<Country> Countries { get; set; }
        public DbSet<Continent> Continents { get; set; }

        static CountryDbContext()
        {
            try
            {
                string connectionString = LoadConnectionString();
                var optionsBuilder = new DbContextOptionsBuilder<CountryDbContext>();
                _options = optionsBuilder.UseSqlServer(connectionString).Options;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing CountryDbContext: {ex.Message}");
                throw;
            }
        }

        private static string LoadConnectionString()
        {
            try
            {
                string jsonFilePath = "appsettings.json";

                if (File.Exists(jsonFilePath))
                {
                    string jsonContent = File.ReadAllText(jsonFilePath);
                    JObject jsonObject = JObject.Parse(jsonContent);
                    return jsonObject["ConnectionStrings"]["DefaultConnection"].ToString();
                }
                else
                {
                    throw new FileNotFoundException("JSON file not found or invalid.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading connection string: {ex.Message}");
                throw;
            }
        }

        public CountryDbContext() : base(_options)
        {
            if (Database.EnsureCreated())
            {
                Continent[] continents = new Continent[]
                {
                    new Continent() { Name = "Euroasia" },
                    new Continent() { Name = "North America" },
                    new Continent() { Name = "South America" },
                    new Continent() { Name = "Africa" },
                    new Continent() { Name = "Oceania" },
                    new Continent() { Name = "Antarctica" },
                };
                Continents.AddRange(continents);

                // Add countries
                Country[] countries = new Country[]
                {
                    new Country() { Name = "France", Capital = "Paris", Population = 67886000, Area = 551695, Continent = continents[0] },
                    new Country() { Name = "China", Capital = "Beijing", Population = 1444216107, Area = 9596961, Continent = continents[0] },
                    new Country() { Name = "United States", Capital = "Washington D.C.", Population = 331002651, Area = 9833520, Continent = continents[1] },
                    new Country() { Name = "Brazil", Capital = "Brasilia", Population = 212559417, Area = 8515767, Continent = continents[2] },
                    new Country() { Name = "Nigeria", Capital = "Abuja", Population = 206139587, Area = 923768, Continent = continents[3] },
                    new Country() { Name = "Australia", Capital = "Canberra", Population = 25499884, Area = 7692024, Continent = continents[4] },
                    new Country() { Name = "Germany", Capital = "Berlin", Population = 83783942, Area = 357022, Continent = continents[0] },
                    new Country() { Name = "India", Capital = "New Delhi", Population = 1380004385, Area = 3287263, Continent = continents[0] },
                };
                Countries.AddRange(countries);

                SaveChanges();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
