using FoodInventoryManagement.Models.Dtos;
using FoodManagement_UI.Models.Dtos;
using FoodManagement_UI.Models.UIModels;
using Microsoft.EntityFrameworkCore;

namespace FoodInventoryManagement.DataAccess
{
    public class FoodManagementDB : DbContext
    {
        public FoodManagementDB(DbContextOptions<FoodManagementDB> options) : base(options)
        {
        }

        public DbSet<FoodDto> FoodDto { get; set; }
        public DbSet<FeedbackDto> FeedbackDto { get; set; }
        public DbSet<RegistrationDto> RegistrationDto { get; set; }
        public DbSet<BookDto> BookLunchDto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodDto>().ToTable("FoodItems");
            modelBuilder.Entity<FeedbackDto>().ToTable("Feedback");
            modelBuilder.Entity<RegistrationDto>().ToTable("Registration");
            modelBuilder.Entity<BookDto>().ToTable("BookLunch");
           
        }
    }
}