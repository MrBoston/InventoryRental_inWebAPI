using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryRental.ViewModels
{
    public class CustomerToolsViewModel
    {
        public int RentalId { get; set; }
        public int RentalItemId { get; set; }
        public string ToolName { get; set; }
    }
}