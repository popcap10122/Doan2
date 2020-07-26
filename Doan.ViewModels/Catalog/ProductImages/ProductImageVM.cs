using Doan.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.ViewModels.Catalog.ProductImages
{
    public class ProductImageVM
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ImagePath { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public DateTime DateCreated { get; set; }
        public int SortOrder { get; set; }
        public long FileSize { get; set; }
    }
}