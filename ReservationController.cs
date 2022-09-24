using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private readonly HMSApiDbcontext dbContext;
        public ReservationController(HMSApiDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        [HttpGet]
        public IActionResult GetReservations()
        {
            return Ok(dbContext.Room_Reservations.ToList());
        }

        [HttpPost]
        public IActionResult AddReservation(AddReservationWithoutId addReservationWithoutId)
        {
            var room_Reservation = new Room_Reservation();
            {
                room_Reservation.Resevation_Check_In = addReservationWithoutId.Resevation_Check_In;
                room_Reservation.Resevation_Check_Out = addReservationWithoutId.Resevation_Check_Out;
                room_Reservation.Reservation_No_of_Guests = addReservationWithoutId.Reservation_No_of_Guests;
                var GuestId = dbContext.Guests.Find(addReservationWithoutId.Guest_Id);
                if (GuestId == null)
                {
                    return NotFound("This Guest Id is not present");
                }
                else
                {
                    room_Reservation.Guest_Id = addReservationWithoutId.Guest_Id;
                }
                var RoomId = dbContext.Rooms.Find(addReservationWithoutId.Room_Id);
                if (RoomId == null)
                {
                    return NotFound("This Room Id is not present");
                }
                else
                {
                    room_Reservation.Room_Id = addReservationWithoutId.Room_Id;
                }
                
            }
            dbContext.Room_Reservations.Add(room_Reservation);
            dbContext.SaveChanges();

            return Ok("New Reservation Added");
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateReservation([FromRoute] int id, UpdateReservationWithoutId updateReservationWithoutId)
        {
            var result = dbContext.Room_Reservations.Find(id);

            if (result != null)
            {
                result.Resevation_Check_In = updateReservationWithoutId.Resevation_Check_In;
                result.Resevation_Check_Out = updateReservationWithoutId.Resevation_Check_Out;
                result.Reservation_No_of_Guests = updateReservationWithoutId.Reservation_No_of_Guests;
                var GuestId = dbContext.Guests.Find(updateReservationWithoutId.Guest_Id);
                if (GuestId == null)
                {
                    return NotFound("This Guest Id is not present");
                }
                else
                {
                    result.Guest_Id= updateReservationWithoutId.Guest_Id;
                }
                var RoomId = dbContext.Rooms.Find(updateReservationWithoutId.Room_Id);
                if (RoomId == null)
                {
                    return NotFound("This Room Id is not present");
                }
                else
                {
                    result.Room_Id = updateReservationWithoutId.Room_Id;
                }

                dbContext.SaveChanges();

                return Ok("Update Successfull");
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteReservation([FromRoute] int id)
        {
            var result = dbContext.Room_Reservations.Find(id);

            if (result != null)
            {
                dbContext.Room_Reservations.Remove(result);
                dbContext.SaveChanges();
                return Ok("Reservation Deleted");
            }
            return NotFound();
        }
    }
}
