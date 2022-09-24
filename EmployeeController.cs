using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
        public class EmployeeController : Controller
        {
        private readonly HMSApiDbcontext dbContext;
        public EmployeeController(HMSApiDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [Route("{EmployeeId}/{EmployeePass}")]
        public IActionResult LoginOwner([FromRoute] int EmployeeId, string EmployeePass)
        {
            Employee employee = new Employee();
            foreach (var item in dbContext.Employees)
            {
                if (item.Employee_Id == EmployeeId&& item.Employee_Password== EmployeePass)
                {
                    return Ok("Login of Employee is done");
                }
            }
            return NotFound("Wrong Credentials");
        }

        [HttpGet]
        public IActionResult GetEmployee()
        {
            return Ok(dbContext.Employees.Where(x =>x.Employee_Designation == "Receptionist").ToList());
        }
        
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeWithoutId addEmployeeWithoutId)
        {
            var Employee = new Employee()
            {
                Employee_Designation = "Receptionist",
                Employee_Name = addEmployeeWithoutId.Employee_Name,
                Employee_Password = addEmployeeWithoutId.Employee_Password,
                Employee_Salary = addEmployeeWithoutId.Employee_Salary,
                Employee_Email = addEmployeeWithoutId.Employee_Email,
                Employee_Age = addEmployeeWithoutId.Employee_Age,
                Employee_PhoneNo = addEmployeeWithoutId.Employee_PhoneNo,
                Employee_Address = addEmployeeWithoutId.Employee_Address,
            };
            dbContext.Employees.Add(Employee);
            dbContext.SaveChanges();

            return Ok("New Employee Added");
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateEmployee([FromRoute] int id,UpdateEmployeeWithoutId updateEmployeeWithoutId)
        {
            var result = dbContext.Employees.Find(id);

            if(result != null)
            {
                if(result.Employee_Designation == "Receptionist")
                {
                    result.Employee_Email = updateEmployeeWithoutId.Employee_Email;
                    result.Employee_PhoneNo = updateEmployeeWithoutId.Employee_PhoneNo;
                    result.Employee_Designation = "Receptionist";
                    result.Employee_Name = updateEmployeeWithoutId.Employee_Name;
                    result.Employee_Address = updateEmployeeWithoutId.Employee_Address;
                    result.Employee_Age = updateEmployeeWithoutId.Employee_Age;
                    result.Employee_Password = updateEmployeeWithoutId.Employee_Password;
                    result.Employee_Salary = updateEmployeeWithoutId.Employee_Salary;

                    dbContext.SaveChanges();

                    return Ok("Update Successfull");
                }

                return NotFound("You are not allowed");
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            var result = dbContext.Employees.Find(id);
            
            if(result != null)
            {
                if(result.Employee_Designation == "Receptionist")
                {
                    dbContext.Employees.Remove(result);
                    dbContext.SaveChanges();
                    return Ok("Employee Deleted");

                }
                else
                {
                    return NotFound("You are not allowed");
                }
               
            }
            return NotFound();
        }
    }
}
