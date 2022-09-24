using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : Controller
    {
        private readonly HMSApiDbcontext dbContext;

        public OwnerController(HMSApiDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        [Route("{OwnerId}/{OwnerPass}")]
        public IActionResult LoginOwner([FromRoute] int OwnerId, string OwnerPass)
        {
            Owner owner = new Owner();
            foreach (var item in dbContext.Owners)
            {
                if (item.Owner_Id == OwnerId && item.Owner_Password == OwnerPass)
                {
                    return Ok("Login of Owner is done");
                }
            }
            return NotFound("Wrong Credentials");
        }
        [HttpGet]
        [Route("/Departments")]
        public IActionResult GetEmployee()
        {
            return Ok(dbContext.Employees.ToList());
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeWithoutId addEmployeeWithoutId)
        {
            var Employee = new Employee()
            {
                Employee_Designation = addEmployeeWithoutId.Employee_Designation,
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
        public IActionResult UpdateEmployee([FromRoute] int id, UpdateEmployeeWithoutId updateEmployeeWithoutId)
        {
            var result = dbContext.Employees.Find(id);

            if (result != null)
            {
                result.Employee_Email = updateEmployeeWithoutId.Employee_Email;
                result.Employee_PhoneNo = updateEmployeeWithoutId.Employee_PhoneNo;
                result.Employee_Designation = updateEmployeeWithoutId.Employee_Designation;
                result.Employee_Name = updateEmployeeWithoutId.Employee_Name;
                result.Employee_Address = updateEmployeeWithoutId.Employee_Address;
                result.Employee_Age = updateEmployeeWithoutId.Employee_Age;
                result.Employee_Password = updateEmployeeWithoutId.Employee_Password;
                result.Employee_Salary = updateEmployeeWithoutId.Employee_Salary;

                dbContext.SaveChanges();

                return Ok("Update Successfull");
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            var result = dbContext.Employees.Find(id);

            if (result != null)
            {
                dbContext.Employees.Remove(result);
                dbContext.SaveChanges();
                return Ok("Employee Deleted");
            }
            return NotFound();
        }

        [HttpGet]
        [Route("/AllRooms")]
        public IActionResult GetRoom()
        {
            return Ok(dbContext.Rooms.ToList());
        }

        [HttpGet]
        [Route("/AllGuests")]
        public IActionResult GetGuest()
        {
            return Ok(dbContext.Guests.ToList());
        }
    }
}
