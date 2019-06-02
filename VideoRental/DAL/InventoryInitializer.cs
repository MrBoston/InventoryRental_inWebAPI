using System;
using System.Collections.Generic;
using InventoryRental.Models;

namespace InventoryRental.DAL
{
    public class InventoryInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<InventoryContext>
    {
        protected override void Seed(InventoryContext context)
        {
            var tools = new List<Tool>
            {
                new Tool{ToolId = 1, Name = "Drill"},
                new Tool{ToolId = 2, Name = "Axe"},
                new Tool{ToolId = 3, Name = "Hammer"},

            };

            tools.ForEach(t => context.Tools.Add(t));
            context.SaveChanges();

            var customers = new List<Customer>
            {
                new Customer{CustomerId = 1, FName = "John Smith", Phone="3390 0675"},
                new Customer{CustomerId = 2, FName = "Mary Parks", Phone="3855 1515"},
                new Customer{CustomerId = 3, FName = "Robert Boyd", Phone="3290 9090"},

            };

            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();

            var rentals = new List<Rental>
            {
                new Rental{RentalId = 1, CustomerId = 1, CheckedOutDate = DateTime.Parse("01/01/2017"), CheckedInDate = null},
                new Rental{RentalId = 2, CustomerId = 2, CheckedOutDate = DateTime.Parse("01/01/2018"), CheckedInDate = null},
                new Rental{RentalId = 3, CustomerId = 3, CheckedOutDate = DateTime.Parse("01/05/2017"), CheckedInDate = null},
            };

            rentals.ForEach(r => context.Rentals.Add(r));
            context.SaveChanges();

            var rentalItems = new List<RentalItem>
            {
                new RentalItem{RentalItemId = 1, RentalId = 1, ToolId = 1},
                new RentalItem{RentalItemId = 2, RentalId = 1, ToolId = 2},
                new RentalItem{RentalItemId = 3, RentalId = 2, ToolId = 3},
                new RentalItem{RentalItemId = 4, RentalId = 3, ToolId = 1},
                new RentalItem{RentalItemId = 5, RentalId = 3, ToolId = 2},
                new RentalItem{RentalItemId = 6, RentalId = 3, ToolId = 3},
            };
            rentalItems.ForEach(ri => context.RentalItems.Add(ri));
            context.SaveChanges();
        }
    }
}