using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        private readonly HMSApiDbcontext dbContext;
        public RoomController(HMSApiDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetRoom()
        {
            return Ok(dbContext.Rooms.ToList());
        }

        [HttpPost]
        public IActionResult AddRoom(AddRoomWithoutId addRoomWithoutId)
        {
            var room = new Room()
            {
                Room_Comment = addRoomWithoutId.Room_Comment,
                Room_Inventory = addRoomWithoutId.Room_Inventory,
                Room_Price = addRoomWithoutId.Room_Price,
                Room_Status = addRoomWithoutId.Room_Status,
            };
            dbContext.Rooms.Add(room);
            dbContext.SaveChanges();
            return Ok("New Room Added");
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateRoom([FromRoute] int id,UpdateRoomWithoutId updateRoomWithoutId)
        {
            var result = dbContext.Rooms.Find(id);

            if(result != null)
            {
                result.Room_Price = updateRoomWithoutId.Room_Price;
                result.Room_Comment = updateRoomWithoutId.Room_Comment;
                result.Room_Status = updateRoomWithoutId.Room_Status;
                result.Room_Inventory = updateRoomWithoutId.Room_Inventory;

                dbContext.SaveChanges();

                return Ok("Update Successfull");
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteRoom([FromRoute] int id)
        {
            var result = dbContext.Rooms.Find(id);

            if (result != null)
            {
                dbContext.Rooms.Remove(result);
                dbContext.SaveChanges();

                return Ok("Room Deleted");
            }
            return NotFound();
        }
    }
}
