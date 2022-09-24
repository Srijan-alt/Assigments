using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillController : Controller
    {
        private readonly HMSApiDbcontext dbContext;

        public BillController(HMSApiDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        [HttpGet]
        public IActionResult GetBill()
        {
            return Ok(dbContext.Bills.ToList());
        }

        [HttpPost]
        public IActionResult AddBill(AddBillWithoutId addBillWithoutId)
        {
            var Bill = new Bill();
            {
                Bill.Bill_Amount = addBillWithoutId.Bill_Amount;
                Bill.Bill_Date = addBillWithoutId.Bill_Date;
                var GuestId = dbContext.Guests.Find(addBillWithoutId.Guest_Id);
                if (GuestId == null)
                {
                    return NotFound("This Guest Id is not present");
                }
                else
                {
                    Bill.Guest_Id = addBillWithoutId.Guest_Id;
                }
                
                var ReservatioId=dbContext.Room_Reservations.Find(addBillWithoutId.Reservation_Id);
                if(ReservatioId == null)
                {
                    return NotFound("This reservation Id is not present");
                }
                else
                {
                    Bill.Reservation_Id = addBillWithoutId.Reservation_Id;
                }
                
            };
            dbContext.Bills.Add(Bill);
            dbContext.SaveChanges();

            return Ok("New Bill Added");
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateBill([FromRoute] int id, UpdateBillWithoutId updateBillWithoutId)
        {
            var result = dbContext.Bills.Find(id);

            if (result != null)
            {
                result.Bill_Amount = updateBillWithoutId.Bill_Amount;
                result.Bill_Date = updateBillWithoutId.Bill_Date;
                var GuestId = dbContext.Guests.Find(updateBillWithoutId.Guest_Id);
                if (GuestId == null)
                {
                    return NotFound("This Guest Id is not present");
                }
                else
                {
                    result.Guest_Id = updateBillWithoutId.Guest_Id;
                }

                var ReservatioId = dbContext.Room_Reservations.Find(updateBillWithoutId.Reservation_Id);
                if (ReservatioId == null)
                {
                    return NotFound("This reservation Id is not present");
                }
                else
                {
                    result.Reservation_Id = updateBillWithoutId.Reservation_Id;
                }

                dbContext.SaveChanges();

                return Ok("Update Successfull");
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteBill([FromRoute] int id)
        {
            var result = dbContext.Bills.Find(id);

            if (result != null)
            {
                dbContext.Bills.Remove(result);
                dbContext.SaveChanges();
                return Ok("Bill Deleted");
            }
            return NotFound();
        }
    }
}
