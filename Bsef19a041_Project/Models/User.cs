using System.ComponentModel.DataAnnotations;
namespace Bsef19a041_Project.Models
{
    public class User:Audit
    {
        [Key]
        public int Id { get; set; } 
        [Required(ErrorMessage = "Please Enter First Name")]
        [StringLength(15)]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        [StringLength(15)]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [StringLength(50)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(50)]
        public string?   Password { get; set; }
    }
}
