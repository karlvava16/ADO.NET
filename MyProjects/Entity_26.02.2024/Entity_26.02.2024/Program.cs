using Entity_26._02._2024;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;




try
{
    var builder = new ConfigurationBuilder();
    builder.SetBasePath(Directory.GetCurrentDirectory());
    builder.AddJsonFile("appsettings.json");
    var config = builder.Build();
    string connectionString = config.GetConnectionString("DefaultConnection");

    var optionsBuilder = new DbContextOptionsBuilder<CountryContext>();
    var options = optionsBuilder.UseSqlServer(connectionString).Options;

    using (CountryContext db = new CountryContext(options))
    {

        DisplayAllCountries(db);
        DisplayCountryNames(db);
        DisplayCapitalNames(db);
        DisplayEuropeanCountries(db);
        DisplayCountriesWithAreaGreaterThan(db, 1000000);

        DisplayCountriesWithNameContainsLetters(db, 'a', 'e');
        DisplayCountriesWithNameStartsWith(db, 'a');
        DisplayCountriesWithAreaInRange(db, 500000, 1000000);
        DisplayCountriesWithPopulationGreaterThan(db, 50000000);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

//Task_4_1
static void DisplayAllCountries(CountryContext db)
{
    Console.WriteLine("All Countries:");

    var allCountriesInfo = db.Countries
            .Select(c => new
            {
                c.CountryId,
                c.Name,
                c.Capital,
                c.Population,
                c.Area,
                Continent = c.Continent.Name
            });

    foreach (var country in allCountriesInfo)
    {
        Console.WriteLine(
            $"{country.Name} - Capital: {country.Capital}, " +
            $"Population: {country.Population}, " +
            $"Area: {country.Area}, " +
            $"Continent: {country.Continent}");
    }
    Console.WriteLine();
}

//Task_4_2
static void DisplayCountryNames(CountryContext db)
{
    Console.WriteLine("Country Names:");
    var countryNames = db.Countries.Select(c => c.Name);
    foreach (var name in countryNames)
    {
        Console.WriteLine(name);
    }
    Console.WriteLine();
}

//Task_4_3
static void DisplayCapitalNames(CountryContext db)
{
    Console.WriteLine("Capital Names:");
    var countryCapitals = db.Countries.Select(c => c.Capital);
    foreach (var capital in countryCapitals)
    {
        Console.WriteLine(capital);
    }
    Console.WriteLine();
}

//Task_4_4
static void DisplayEuropeanCountries(CountryContext db)
{
    Console.WriteLine("European Countries:");

    var europeanCountries = db.Countries.Where(c => c.Continent.Name == "Euroasia").Select(c => c.Name);

    foreach (var countryName in europeanCountries)
    {
        Console.WriteLine(countryName);
    }
    Console.WriteLine();
}

//Task_4_5
static void DisplayCountriesWithAreaGreaterThan(CountryContext db, double a)
{
    Console.WriteLine($"Countries with area more then {a} :");

    var Countries = db.Countries.Where(c => c.Area > a).Select(c => c.Name);

    foreach (var countryName in Countries)
    {
        Console.WriteLine(countryName);
    }
    Console.WriteLine();
}

//Task_5_1
static void DisplayCountriesWithNameContainsLetters(CountryContext db, params char[] characters)
{
    Console.WriteLine($"Countries that contains '{string.Join("', '", characters)}' :");

    var Countries = db.Countries.AsEnumerable().Where(c => characters.All(ch => c.Name.Contains(ch))).Select(c => c.Name);
    foreach (var countryName in Countries)
    {
        Console.WriteLine(countryName);
    }
    Console.WriteLine();
}



//Task_5_2
static void DisplayCountriesWithNameStartsWith(CountryContext db, char a)
{
    Console.WriteLine($"Countries that starts with letter '{a}' :");

    var Countries = db.Countries.AsEnumerable().Where(c => c.Name.StartsWith(a)).Select(c => c.Name);

    foreach (var countryName in Countries)
    {
        Console.WriteLine(countryName);
    }
    Console.WriteLine();
}


//Task_5_3
static void DisplayCountriesWithAreaInRange(CountryContext db, double a, double b)
{
    Console.WriteLine($"Countries with area between {a} and {b} :");

    var Countries = db.Countries.Where(c => c.Area > a && c.Area < b).Select(c => c.Name);

    foreach (var countryName in Countries)
    {
        Console.WriteLine(countryName);
    }
    Console.WriteLine();
}


//Task_5_4
static void DisplayCountriesWithPopulationGreaterThan(CountryContext db, long a)
{
    Console.WriteLine($"Countries with population more then {a} :");

    var Countries = db.Countries.Where(c => c.Population > a).Select(c => c.Name);

    foreach (var countryName in Countries)
    {
        Console.WriteLine(countryName);
    }
    Console.WriteLine();
}
