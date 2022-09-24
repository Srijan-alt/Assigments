using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace HotelManagementSystem.Models
{
    public class Room_Reservation
    {
        [Key]
        public int Reservation_Id { get; set; }
        [ForeignKey("Rooms")]
        public int Room_Id { get; set; }
        public DateTime Resevation_Check_In { get; set; }
        public DateTime Resevation_Check_Out { get; set; }
        public int Reservation_No_of_Guests { get; set; }
        [ForeignKey("Guests")]
        public int Guest_Id { get; set; }
    }
}
