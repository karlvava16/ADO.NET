using LINQ_21._02._2024;
using System;
using System.Collections.Generic;
using System.Linq;


List<Department> departments = new List<Department>()
        {
            new Department(){ Id = 1, Country = "Ukraine", City = "Odesa"},
            new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
            new Department(){ Id = 3, Country = "France", City = "Paris" },
            new Department(){ Id = 4, Country = " Ukraine ", City = "Lviv"}
        };

List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2
            },
            new Employee()
            {
                Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1
            },
            new Employee()
            {
                Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3
            },
            new Employee()
            {
                Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2
            },
            new Employee()
            {
                Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4
            },
            new Employee()
            {
                Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2
            },
            new Employee()
            {
                Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4
            }
        };


DisplayUkrainianEmployees(departments, employees);
DisplaySortedEmployeesByAge(employees);
DisplayAgeGroups(employees);


static void DisplayUkrainianEmployees(List<Department> departments, List<Employee> employees)
{
    var ukrainianEmployees = from emp in employees
                             join dep in departments on emp.DepId equals dep.Id
                             where dep.Country.Trim().ToLower() == "ukraine"
                             orderby emp.FirstName, emp.LastName
                             select emp;

    foreach (var employee in ukrainianEmployees)
    {
        Console.WriteLine($"{employee.FirstName} {employee.LastName}");
    }

    Console.WriteLine();
}

static void DisplaySortedEmployeesByAge(List<Employee> employees)
{
    var sortedEmployeesByAge = employees.OrderByDescending(emp => emp.Age);

    foreach (var employee in sortedEmployeesByAge)
    {
        Console.WriteLine($"Id: {employee.Id}, FirstName: {employee.FirstName}, LastName: {employee.LastName}, Age: {employee.Age}");
    }

    Console.WriteLine();

}

static void DisplayAgeGroups(List<Employee> employees)
{
    var ageGroups = from emp in employees
                    group emp by emp.Age into ageGroup
                    select new
                    {
                        Age = ageGroup.Key,
                        Count = ageGroup.Count()
                    };

    foreach (var group in ageGroups)
    {
        Console.WriteLine($"Age: {group.Age}, Count: {group.Count}");
    }

}