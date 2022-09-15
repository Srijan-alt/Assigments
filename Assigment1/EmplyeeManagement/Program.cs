using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitwareLib;

namespace EmplyeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            int ch = 0;
            do
            {
                try
                {
                    Console.WriteLine("1. Register the employees in company");
                    Console.WriteLine("2. Display employee");
                    Console.WriteLine("3. Exit\n");
                    Console.Write("Your choice: ");
                    ch = int.Parse(Console.ReadLine());
                    if (ch == 1)
                    {
                        Console.Write("Enter Employee ID: ");
                        int ID = int.Parse(Console.ReadLine());
                        Console.Write("Enter Employee Name: ");
                        string Name = Console.ReadLine();
                        Console.Write("Enter Employee Salary: ");
                        double Salary = double.Parse(Console.ReadLine());

                        EmployeeDetails employeeDetails = new EmployeeDetails();
                        employeeDetails.EnterDetails(ID, Name, Salary);
                        employee.addemployee(employeeDetails);

                    }
                    else if (ch == 2)
                    {
                        employee.displayEmployees();
                    }
                    else if (ch == 3)
                    {

                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please choose from the number given in the menu \n");
                    }
                } 
                catch (FormatException) 
                {
                    Console.WriteLine("Please enter a valid datatype");
                }


            } while (ch != 3);

        }
    }
}
