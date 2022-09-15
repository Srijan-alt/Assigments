using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitwareLib
{
    
    public class EmployeeDetails
    {
        public int EmpNo;
        public string EmpName;
        public double Salary;
        public double HRA;
        public double TA;
        public double DA;
        public double PF;
        public double TDS;
        public double NetSalary;
        public double GrossSalary;

        public void EnterDetails(int EmpNo, string EmpName, double Salary)
        {
            this.EmpNo = EmpNo;
            this.EmpName = EmpName;
            this.Salary = Salary;

            if (Salary < 5000)
            {
                HRA = Salary * 0.1;
                TA = Salary * 0.05;
                DA = Salary * 0.15;
            }
            else if (Salary < 10000)
            {
                HRA = Salary * 0.15;
                TA = Salary * 0.10;
                DA = Salary * 0.2;
            }

            
            else if (Salary < 15000)
            {
                HRA = Salary * 0.2;
                TA = Salary * 0.15;
                DA = Salary * 0.25;
            }
            else if (Salary < 20000)
            {
                HRA = Salary * 0.25;
                TA = Salary * 0.20;
                DA = Salary * 0.30;
            }

            else if (Salary >= 20000)
            {
                HRA = Salary * 0.30;
                TA = Salary * 0.25;
                DA = Salary * 0.35;
            }

            this.GrossSalary = Salary + HRA + TA + DA;
            this.NetSalary = GrossSalary - (CalculateSalary());
        }

        public double CalculateSalary()
        {
            PF = GrossSalary * 0.1;
            TDS = GrossSalary * 0.18;

            return PF + TDS;
        }

    }

    public class Employee
    {
        List<EmployeeDetails> emp = new List<EmployeeDetails>();

        public void addemployee(EmployeeDetails employee)
        {
            this.emp.Add(employee);
        }
        public void displayEmployees()
        {
            for (int i = 0; i < emp.Count; i++)
            {
                Console.WriteLine("ID: {0}", emp[i].EmpNo);
                Console.WriteLine("Name: {0}", emp[i].EmpName);
                Console.WriteLine("Salary: {0}", emp[i].Salary);
                Console.WriteLine("HRA: {0}", emp[i].HRA);
                Console.WriteLine("TA: {0}", emp[i].TA);
                Console.WriteLine("DA: {0}", emp[i].DA);
                Console.WriteLine("PF: {0}", emp[i].PF);
                Console.WriteLine("TDS: {0}", emp[i].TDS);
                Console.WriteLine("Net Salary: {0}", emp[i].NetSalary);
                Console.WriteLine("Gross Salary: {0}", emp[i].GrossSalary);
                Console.WriteLine("****************************");


            }
        }
    }
}
