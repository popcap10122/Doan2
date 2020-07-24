using Doan.Data.EF;
using Doan.Data.Entites;
using Doan.ViewModels.Catalog.Products;
using Doan.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Doan.Application.Catalog.Products
{
    public class ProductService : IProductService
    {
        private readonly QlkhContext _context;

        public ProductService(QlkhContext qlkhContext)
        {
            _context = qlkhContext;
        }

        public async Task<ApiResult<int>> AddViewCount(string productId, int addView)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return new ApiErrorResult<int>($"Cannot find product with id {productId}");
            }
            product.ViewCount += addView;

            await _context.SaveChangesAsync();
            return new ApiSuccessResult<int>();
        }

        public async Task<ApiResult<string>> Create(ProductCreateRequest request)
        {
            var product = new Product
            {
                Name = request.Name,
                Unit = request.Unit,
                Stock = request.Stock,
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<string>(product.Id);
        }

        public async Task<ApiResult<bool>> Delete(string productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return new ApiErrorResult<bool>($"Cannot find product with id {productId}");
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<PagedResult<ProductViewModel>>> GetAll(ProductPagingRequest request)
        {
            var query = from p in _context.Products
                        select p;
            var totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Unit = x.Unit,
                    Stock = x.Stock,
                    DateCreated = x.DateCreated,
                    ViewCount = x.ViewCount
                }).ToListAsync();
            var pagedResult = new PagedResult<ProductViewModel>
            {
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRow
            };
            return new ApiSuccessResult<PagedResult<ProductViewModel>>(pagedResult);
        }

        public async Task<ApiResult<int>> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if (product == null)
            {
                return new ApiErrorResult<int>($"Cannot find product with id {request.Id}");
            }
            product.Name = request.Name;
            product.Unit = request.Unit;

            await _context.SaveChangesAsync();
            return new ApiSuccessResult<int>();
        }

        public async Task<ApiResult<int>> UpdateStock(string productId, int addQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return new ApiErrorResult<int>($"Cannot find product with id {productId}");
            }
            product.Stock += addQuantity;

            await _context.SaveChangesAsync();
            return new ApiSuccessResult<int>();
        }
    }
}