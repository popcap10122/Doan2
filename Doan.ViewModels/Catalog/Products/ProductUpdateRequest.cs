using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.ViewModels.Catalog.Products
{
    public class ProductUpdateRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
    }
}