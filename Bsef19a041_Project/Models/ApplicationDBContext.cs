using Microsoft.EntityFrameworkCore;

namespace Bsef19a041_Project.Models
{
    public class ApplicationDBContext:DbContext
    {
        //public ApplicationDBContext( DbContextOptions options):base(options)
        //{

        //}
        //public ApplicationDBContext()
        //{

        //}

        public DbSet<Products> Product { get; set; }
        public DbSet<Discount> discounts { get; set; }

        public DbSet<User> users { get; set; }
        public DbSet<Content> contents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
