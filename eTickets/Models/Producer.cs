using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")] //This way we indicate how we want to display prop. name on the page
        public string ProfilePictureURL { get; set; }


        [Display(Name = "Full Name")]
        public string FullName { get; set; }


        [Display(Name = "Biography")]
        public string Bio { get; set; }
         
        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
