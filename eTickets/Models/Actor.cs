using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage ="Profile Picture is required")]
<<<<<<< HEAD

=======
>>>>>>> master
        public string ProfilePictureURL { get; set; }
		[Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="Full Name must be between 3 and 50 chars")]
<<<<<<< HEAD

        public string FullName { get; set; }
		[Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]

        public string Bio { get; set; }
        
=======
        public string FullName { get; set; }
		[Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }
        //Relationships
>>>>>>> master
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
