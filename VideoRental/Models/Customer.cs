using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryRental.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}