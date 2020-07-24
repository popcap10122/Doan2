using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Stock { get; set; }
    }
}