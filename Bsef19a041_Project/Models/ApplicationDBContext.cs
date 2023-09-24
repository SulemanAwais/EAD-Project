using Bsef19a041_Project.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bsef19a041_Project.Models
{
    public class ApplicationDBContext:DbContext
    {
        private readonly AdminRepository U=new AdminRepository();
        //public ApplicationDBContext(DbContextOptions options) : base(options)
        //{

        //}
        //public ApplicationDBContext()
        //{

        //}

        public DbSet<Products> Product { get; set; }
        public DbSet<Discount> discounts { get; set; }

        public DbSet<User> users { get; set; }
        public DbSet<Content> contents { get; set; }
        public DbSet<Admin> AdminTable { get; set; }
        public DbSet<Order> OrderTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public override int SaveChanges()
        {
            int ID = U.LoggedInUser();
            var tracker = ChangeTracker;
            foreach (var entry in tracker.Entries())
            {
                if (entry.Entity is Audit)
                {
                    var referenceentity = entry.Entity as User;
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            referenceentity.CreatedAt = DateTime.Now;
                            referenceentity.CreatedBy = ID.ToString();//hard coded user id

                            break;
                        case EntityState.Deleted:
                        case EntityState.Modified:
                            referenceentity.ModifiedAt = DateTime.Now;
                            referenceentity.ModifiedBy =  ID.ToString();//hard coded user id
                            break;
                        default:
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
