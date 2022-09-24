using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace HotelManagementSystem.Models
{
    public class Bill
    {
        [Key]
        public int Bill_Id { get; set; }
        //[ForeignKey("Guests")]
        public int Guest_Id { get; set; }
        public float Bill_Amount { get; set; }
        public DateTime Bill_Date  { get; set; }
        //[ForeignKey ("Reservations")]
        public int Reservation_Id { get; set; }
    }
}
