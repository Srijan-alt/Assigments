using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestController : Controller
    {
        private readonly HMSApiDbcontext dbContext;
        public GuestController(HMSApiDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetGuest()
        {
            return Ok(dbContext.Guests.ToList());
        }

        [HttpPost]
        public IActionResult AddGuest(AddGuestWithoutId addGuestWithoutId)
        {
            var Guest = new Guest()
            {
                Guest_Aadhar_Id = addGuestWithoutId.Guest_Aadhar_Id,
                Guest_Address = addGuestWithoutId.Guest_Address,
                Guest_Age = addGuestWithoutId.Guest_Age,
                Guest_Email = addGuestWithoutId.Guest_Email,
                Guest_Name = addGuestWithoutId.Guest_Name,
                Guest_Phone_Number = addGuestWithoutId.Guest_Phone_Number,
            };
            dbContext.Guests.Add(Guest);
            dbContext.SaveChanges();

            return Ok("New Guest Added");
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateGuest([FromRoute] int id, UpdateGuestWithoutId updateGuestWithoutId)
        {
            var result = dbContext.Guests.Find(id);

            if (result != null)
            {
                result.Guest_Name = updateGuestWithoutId.Guest_Name;
                result.Guest_Phone_Number = updateGuestWithoutId.Guest_Phone_Number;
                result.Guest_Age = updateGuestWithoutId.Guest_Age;
                result.Guest_Email = updateGuestWithoutId.Guest_Email;
                result.Guest_Address = updateGuestWithoutId.Guest_Address;
                result.Guest_Aadhar_Id = updateGuestWithoutId.Guest_Aadhar_Id;

                dbContext.SaveChanges();

                return Ok("Update Successfull");
            }

            return NotFound();
        }
    }
}
