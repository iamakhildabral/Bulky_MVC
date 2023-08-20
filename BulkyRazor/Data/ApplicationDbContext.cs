using BulkyRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyRazor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        //seeding data using model builder for intilization
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
                 new Category { Id = 1, Name = "SuperHero", DisplayOrder = 22 },
                 new Category { Id=2,Name="Comedy",DisplayOrder=23 },
                 new Category { Id=3,Name="Documentry",DisplayOrder=24 }
                 );   
            
        }


    }
}
