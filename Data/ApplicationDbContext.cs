using CM.Models;
using CM.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CM.Data
{
    public class ApplicationDbContext:IdentityDbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet <Category> categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shoping> Shoppings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
             new Category { Id=1,Name="myfirst",MyOrder=1},    new Category { Id=2,Name="two",MyOrder=2},    new Category { Id=3,Name="three",MyOrder=3}
                );

        }
    }
}
