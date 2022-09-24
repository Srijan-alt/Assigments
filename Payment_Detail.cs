using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models
{
    public class Payment_Detail
    {
        [Key]
        public int Payment_Id { get; set; }
        public long Payment_Card { get; set; }
        public string Payment_Card_Holder_Name { get; set; }
        
        //[ForeignKey ("Bills")]
        public int Bill_Id { get; set; }

    }
}
