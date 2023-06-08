using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]//user can not see password when typing
        public string Password { get; set; }
        public string ReturnURL { get; set; }
    }
}