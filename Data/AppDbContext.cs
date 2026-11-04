using Microsoft.EntityFrameworkCore;
using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Dish> Dishes => Set<Dish>();
    public DbSet<Courier> Couriers => Set<Courier>();
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();
    public DbSet<Order> Orders => Set<Order>();

    public DbSet<User> Users => Set<User>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Это заставит EF Core всегда использовать UTC для дат
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}