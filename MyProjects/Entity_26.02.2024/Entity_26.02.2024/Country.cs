using Microsoft.EntityFrameworkCore;

namespace Entity_26._02._2024
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public long Population { get; set; }
        public double Area { get; set; }
        public virtual Continent Continent { get; set; } // Making Continent virtual

    }

    public class Continent
    {
        public int ContinentId { get; set; }
        public string Name { get; set; }
    }


    public class CountryContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Continent> Continents { get; set; }

        public CountryContext(DbContextOptions<CountryContext> options) : base(options)
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
                new Country() { Name = "United States", Capital = "Washington D.C.", Population = 331002651, Area = 9833520, Continent = continents[2] },
                new Country() { Name = "Brazil", Capital = "Brasilia", Population = 212559417, Area = 8515767, Continent = continents[3] },
                new Country() { Name = "Nigeria", Capital = "Abuja", Population = 206139587, Area = 923768, Continent = continents[4] },
                new Country() { Name = "Australia", Capital = "Canberra", Population = 25499884, Area = 7692024, Continent = continents[5] },
                new Country() { Name = "Germany", Capital = "Berlin", Population = 83783942, Area = 357022, Continent = continents[0] },
                new Country() { Name = "India", Capital = "New Delhi", Population = 1380004385, Area = 3287263, Continent = continents[0] },
                };
                Countries.AddRange(countries);

                SaveChanges();
            }
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=DESKTOP-UIJQEL8\SQLEXPRESS;Database=Countries;Integrated Security=SSPI;TrustServerCertificate=true");
        }
    }
}

