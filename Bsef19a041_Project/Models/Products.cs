using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bsef19a041_Project.Models
{
    public class Products
    {
        //[ForeignKey("Product"),Key]
        public int Id { get; set; }
        public string? ImageName { get; set; }
        public string? Path { get; set; }
        public string? Category { get; set; }
        public int Price { get; set; }
        //public virtual User Users { get; set; } 
    }
}

