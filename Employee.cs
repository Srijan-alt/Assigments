using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }
        public string Employee_Password { get; set; }
        public string Employee_Designation { get; set; }
        public float Employee_Salary { get; set; }
        public string Employee_Email { get; set; }
        public int Employee_Age { get; set; }
        public long Employee_PhoneNo { get; set; }
        public string Employee_Address { get; set; }
    }
}
