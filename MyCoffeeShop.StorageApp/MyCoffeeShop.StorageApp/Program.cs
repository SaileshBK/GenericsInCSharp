using MyCoffeeShop.StorageApp.Data;
using MyCoffeeShop.StorageApp.Entities;
using MyCoffeeShop.StorageApp.Repositories;
using System;
namespace MyCoffeeShop.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //SqlRepositories of Employee instance
            var employeeRepositories = new SqlRepositories<Employee>(new StorageAppDbContext());

            AddEmployees(employeeRepositories);
            AddManager(employeeRepositories);
            GetEmployeesById(employeeRepositories);
            WriteAlltoConsole(employeeRepositories);

            var organizationalRepositories = new ListRepositories<Organization>();
            AddOrganizations(organizationalRepositories);
            WriteAlltoConsole(organizationalRepositories);
             

            Console.ReadLine();
        }

        private static void AddManager(IWriteRepositories<Manager> managerRepositories)
        {
            managerRepositories.Add(new Manager { FirstName = "Nick" });
            managerRepositories.Add(new Manager { FirstName = "Jeanette" });
            managerRepositories.Save();

        }

        private static void WriteAlltoConsole(IReadRepositories<IEntity> repositories)
        {
            var items = repositories.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);

            }
        }

        private static void GetEmployeesById(IRepositories<Employee> employeeRepositories)
        {
            var employee = employeeRepositories.GetById(2);
            Console.WriteLine($"Employee with Id 2 is {employee.FirstName}");
        }

        private static void AddEmployees(IRepositories<Employee> employeeRepositories)
        {
            employeeRepositories.Add(new Employee { FirstName = "Sailesh" });
            employeeRepositories.Add(new Employee { FirstName = "Pratik" });
            employeeRepositories.Save();
        }

        private static void AddOrganizations(ListRepositories<Organization> organizationalRepositories)
        {
            organizationalRepositories.Add(new Organization { Name = "OnePiece" });
            organizationalRepositories.Add(new Organization { Name = "Luffy" });
            organizationalRepositories.Save();
        }
    }
}
