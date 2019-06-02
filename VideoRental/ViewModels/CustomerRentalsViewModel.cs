using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryRental.ViewModels
{
    public class CustomerRentalsViewModel
    {
        public int RentalId { get; set; }
        public DateTime CheckedOutDate { get; set; }
        public string FName { get; set; }
    }
}