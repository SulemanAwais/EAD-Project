using System.ComponentModel.DataAnnotations;
namespace Bsef19a041_Project.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        [Required(ErrorMessage ="Enter valid Admin email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter valid passowrd")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
