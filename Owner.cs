using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Owner
    {
        [Key]
        public int Owner_Id { get; set; }
        public string Owner_Password { get; set; }
    }
}
