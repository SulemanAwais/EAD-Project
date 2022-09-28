using Microsoft.EntityFrameworkCore;

namespace Bsef19a041_Project.Models
{
    public class ApplicationDBContext:DbContext
    {
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        //public override int SaveChanges()
        //{
        //    var tracker = ChangeTracker;
        //    foreach (var entry in tracker.Entries())
        //    {
        //        if (entry.Entity is Audit)
        //        {
        //            var referenceEntity = entry.Entity as Products;
        //            switch (entry.State)
        //            {
        //                case EntityState.Added:
        //                    referenceEntity.CreatedAt = DateTime.Now;
        //                    referenceEntity.CreatedBy = "1";//hard coded user id

        //                    break;
        //                case EntityState.Deleted:
        //                case EntityState.Modified:
        //                    referenceEntity.ModifiedAt = DateTime.Now;
        //                    referenceEntity.ModifiedBy = "1";//hard coded user id
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //    }
        //    return base.SaveChanges();
        //}
    }
}
