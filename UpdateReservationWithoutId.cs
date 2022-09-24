using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models
{
    public class UpdateReservationWithoutId
    {
        [ForeignKey("Rooms")]
        public int Room_Id { get; set; }
        public DateTime Resevation_Check_In { get; set; }
        public DateTime Resevation_Check_Out { get; set; }
        public int Reservation_No_of_Guests { get; set; }
        [ForeignKey("Guests")]
        public int Guest_Id { get; set; }
    }
}
