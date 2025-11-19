using Microsoft.EntityFrameworkCore;

namespace SalesOrderApi.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Client> Clients => Set<Client>();
    public DbSet<SalesOrder> SalesOrders => Set<SalesOrder>();
    public DbSet<SalesOrderItem> SalesOrderItems => Set<SalesOrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed sample clients (so your dropdown isn't empty!)
        modelBuilder.Entity<Client>().HasData(
            new Client {
                Id = 1,
                Name = "ABC Corporation",
                Address1 = "123 Business St",
                Address2 = "Level 5",
                Address3 = "",
                Suburb = "Sydney CBD",
                State = "NSW",
                PostCode = "2000"
            },
            new Client {
                Id = 2,
                Name = "XYZ Trading Co",
                Address1 = "456 Market Ave",
                Address2 = "",
                Address3 = "Warehouse B",
                Suburb = "Melbourne",
                State = "VIC",
                PostCode = "3000"
            }
        );
    }
}