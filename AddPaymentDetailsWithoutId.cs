using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models
{
    public class AddPaymentDetailsWithoutId
    {
        public long Payment_Card { get; set; }
        public string Payment_Card_Holder_Name { get; set; }
        
        //[ForeignKey ("Bills")]
        public int Bill_Id { get; set; }
        //public Bill bill { get; set; }
    }
}
