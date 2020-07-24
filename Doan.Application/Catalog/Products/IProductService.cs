using Doan.ViewModels.Catalog.Products;
using Doan.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Doan.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<ApiResult<string>> Create(ProductCreateRequest request);

        Task<ApiResult<int>> Update(ProductUpdateRequest request);

        Task<ApiResult<bool>> Delete(string productId);

        Task<ApiResult<int>> AddViewCount(string productId, int addView);

        Task<ApiResult<int>> UpdateStock(string productId, int addQuantity);

        Task<ApiResult<PagedResult<ProductViewModel>>> GetAll(ProductPagingRequest request);
    }
}