using Doan.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doan.ViewModels.Catalog.ProductImages
{
    public class ProductImagePagingRequest : PagingRequestBase
    {
        public int KeyCaption { get; set; }
    }
}