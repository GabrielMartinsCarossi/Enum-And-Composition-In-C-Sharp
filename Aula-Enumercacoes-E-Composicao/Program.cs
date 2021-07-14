using System;
using Aula_Enumercacoes_E_Composicao.Entities;
using Aula.Entities.Enums;
using System.Globalization;

namespace Aula_Enumercacoes_E_Composicao
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create new employee
            Console.Write("Enter Department's Name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter employee data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior-MidLevel-Senior):");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary($):");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);
            Console.Write("How many contracts this employee will have?");
            int n = int.Parse(Console.ReadLine());

            //Create contracts
            for (int i = 0; i <n; i++)
            {
                Console.WriteLine($"Enter #{i+1} contract data: ");
                Console.Write("Date (DD/MM/YYYY):");
                DateTime dt = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour($): ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(dt, valuePerHour, hours);
                worker.AddContract(contract);
            }

            //Displays month income
            if (worker.Contracts.Count != 0)
            {
                Console.WriteLine();
                Console.Write("Enter month and year to calculate income (MM/YYYY):");
                string monthAndYear = Console.ReadLine();
                int month = int.Parse(monthAndYear.Substring(0, 2));
                int year = int.Parse(monthAndYear.Substring(3));

                Console.WriteLine("Name: " + worker.Name);
                Console.WriteLine("Department: " + worker.Department.Name);
                Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
            }  
        }
    }
}
