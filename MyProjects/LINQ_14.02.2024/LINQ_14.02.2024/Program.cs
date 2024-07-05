
using System.Text;

class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int DepId { get; set; }
}

class Department
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
}

class Program
{
    static List<Department>? departments;
    static List<Employee>? employees;

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        departments = new List<Department>()
        {
            new Department(){ Id = 1, Country = "Ukraine", City = "Lviv" },
            new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
            new Department(){ Id = 3, Country = "France", City = "Paris" },
            new Department(){ Id = 4, Country = "Ukraine", City = "Odesa" }
        };

        employees = new List<Employee>()
        {
            new Employee(){ Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
            new Employee(){ Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
            new Employee(){ Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
            new Employee(){ Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
            new Employee(){ Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
            new Employee(){ Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
            new Employee(){ Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4 }
        };

        Task1();
        Task2();
        Task3();
        Task4();
    }

    static void Task1()
    {
        var employeesInUkraineNotOdesa = from e in employees
                                         join d in departments on e.DepId equals d.Id
                                         where d.Country == "Ukraine" && d.City != "Odesa"
                                         select new { e.FirstName, e.LastName };

        Console.WriteLine("1) Выбрать имена и фамилии сотрудников, работающих в Украине, но не в Одессе:");
        foreach (var employee in employeesInUkraineNotOdesa)
        {
            Console.WriteLine($"{employee.FirstName} {employee.LastName}");
        }
        Console.WriteLine();
    }

    static void Task2()
    {
        var countries = departments.Select(d => d.Country).Distinct();
        Console.WriteLine("2) Вывести список стран без повторений:");
        foreach (var country in countries)
        {
            Console.WriteLine(country);
        }
        Console.WriteLine();
    }

    static void Task3()
    {
        var firstThreeEmployeesOver25 = employees.Where(e => e.Age > 25).Take(3);
        Console.WriteLine("3) Выбрать 3-x первых сотрудников, возраст которых превышает 25 лет:");
        foreach (var employee in firstThreeEmployeesOver25)
        {
            Console.WriteLine($"{employee.FirstName} {employee.LastName}, Age: {employee.Age}");
        }
        Console.WriteLine();
    }

    static void Task4()
    {
        var employeesInKyivOver23 = from e in employees
                                    join d in departments on e.DepId equals d.Id
                                    where d.City == "Kyiv" && e.Age > 23
                                    select new { e.FirstName, e.LastName, e.Age };

        Console.WriteLine("4) Выбрать имена, фамилии и возраст студентов из Киева, возраст которых\r\nпревышает 23 года:");
        foreach (var employee in employeesInKyivOver23)
        {
            Console.WriteLine($"{employee.FirstName} {employee.LastName}, Age: {employee.Age}");
        }
        Console.WriteLine();
    }
}
