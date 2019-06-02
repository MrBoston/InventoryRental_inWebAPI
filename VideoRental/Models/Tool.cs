using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryRental.Models
{
    public class Tool
    {
        public int ToolId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public bool Active { get; set; }
    }
}