using Doan.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.ViewModels.Catalog.Products
{
    public class ProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}