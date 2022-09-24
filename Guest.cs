using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Guest
    {
        [Key]
        public int Guest_Id { get; set; }
        public string Guest_Name { get; set; }
        public string Guest_Email { get; set; }
        public int Guest_Age { get; set; }
        public long Guest_Phone_Number { get; set; }
        public long Guest_Aadhar_Id { get; set; }
        public string Guest_Address { get; set; }
    }
}
