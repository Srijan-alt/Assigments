using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models
{
    public class AddBillWithoutId
    {
        //[ForeignKey("Guests")]
        public int Guest_Id { get; set; }
        public float Bill_Amount { get; set; }
        public DateTime Bill_Date { get; set; }

        //[ForeignKey("Reservations")]
        public int Reservation_Id { get; set; }
    }
}
