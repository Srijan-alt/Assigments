using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Room
    {
        [Key]
        public int Room_Id { get; set; }
        public Boolean Room_Status { get; set; }
        public string Room_Comment { get; set; }
        public string Room_Inventory { get; set; }
        public float Room_Price { get; set; }
    }
}
