using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using InventoryRental.Models;

namespace InventoryRental.DAL
{
    public class InventoryContext : DbContext
    {
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalItem> RentalItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}