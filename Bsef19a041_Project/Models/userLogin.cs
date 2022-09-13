using System.ComponentModel.DataAnnotations;
namespace Bsef19a041_Project.Models
{
    public class userLogin
    {
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
    }
}
