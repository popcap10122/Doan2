using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.ViewModels.Catalog.Products
{
    public class ProductVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public DateTime DateCreated { get; set; }
    }
}