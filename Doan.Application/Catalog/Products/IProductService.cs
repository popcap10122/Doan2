using Doan.ViewModels.Catalog.ProductImages;
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

        Task<ApiResult<int>> AddImage(string producId, ProductImageCreateRequest request);

        Task<ApiResult<int>> UpdateImage(string ImageId, ProductImageUpdateRequest request);

        Task<ApiResult<int>> RemoveImage(string ImageId);

        Task<ApiResult<PagedResult<ProductImageVM>>> GetListImage(int productId, ProductImagePagingRequest request);

        Task<ApiResult<ProductImageVM>> GetImageById(int ImageId);
    }
}