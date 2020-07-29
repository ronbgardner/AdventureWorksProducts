using AdventureWorksProducts.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksProducts.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductCostHistory>().HasKey(o => new { o.ProductId, o.StartDate });
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCostHistory> ProductCostHistory { get; set; }
    }
}
