using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryRental.ViewModels
{
    public class CustomerRentalsViewModel
    {
        public int RentalId { get; set; }
        public DateTime DateRented { get; set; }
        public string CustomerName { get; set; }
    }
}