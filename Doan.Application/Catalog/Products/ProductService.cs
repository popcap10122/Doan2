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
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using Doan.Application.Common;
using Doan.ViewModels.Catalog.ProductImages;

namespace Doan.Application.Catalog.Products
{
    public class ProductService : IProductService
    {
        private readonly QlkhContext _context;
        private readonly IStorageService _storageService;

        public ProductService(QlkhContext qlkhContext, IStorageService storageService)
        {
            _context = qlkhContext;
            _storageService = storageService;
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
            var idExist = await _context.Products.AnyAsync(x => x.Id == request.Id);
            if (idExist)
            {
                return new ApiErrorResult<string>($"Id  {request.Id} is exists in System");
            }
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Unit = request.Unit,
                Stock = request.Stock,
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            //save Imamge
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>
                {
                    new ProductImage()
                    {
                        Caption = "ThumbnailImage",
                        ImagePath = await this.SaveFile(request.ThumbnailImage),
                        FileSize = request.ThumbnailImage.Length,
                        SortOrder = 1,
                        IsDefault = true,
                    }
                };
            }

            return new ApiSuccessResult<string>(product.Id);
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var orginalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()} {Path.GetExtension(orginalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
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

        public async Task<ApiResult<PagedResult<ProductVM>>> GetAll(ProductPagingRequest request)
        {
            var query = from p in _context.Products
                        select p;
            var totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new ProductVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Unit = x.Unit,
                    Stock = x.Stock,
                    DateCreated = x.DateCreated,
                    ViewCount = x.ViewCount
                }).ToListAsync();
            var pagedResult = new PagedResult<ProductVM>
            {
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRow
            };
            return new ApiSuccessResult<PagedResult<ProductVM>>(pagedResult);
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

        public async Task<ApiResult<int>> AddImage(string productId, ProductImageCreateRequest request)
        {
            var image = new ProductImage()
            {
                ProductId = productId,
                Caption = request.Caption,
                DateCreated = DateTime.Now,
                IsDefault = request.IsDefault,
                SortOrder = request.SortOrder,
            };
            if (request.ImageFile != null)
            {
                image.ImagePath = await this.SaveFile(request.ImageFile);
                image.FileSize = request.ImageFile.Length;
            }
            _context.ProductImages.Add(image);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<int>();
        }

        public async Task<ApiResult<int>> UpdateImage(int ImageId, ProductImageUpdateRequest request)
        {
            var image = await _context.ProductImages.FindAsync(ImageId);
            if (image == null)
            {
                return new ApiErrorResult<int>($"Cannot find image with id {ImageId}");
            }
            image.Caption = request.Caption;
            image.DateCreated = DateTime.Now;
            image.IsDefault = request.IsDefault;
            image.SortOrder = request.SortOrder;
            if (request.ImageFile != null)
            {
                image.ImagePath = await this.SaveFile(request.ImageFile);
                image.FileSize = request.ImageFile.Length;
            }
            _context.ProductImages.Update(image);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<int>();
        }

        public async Task<ApiResult<int>> RemoveImage(int ImageId)
        {
            var image = await _context.ProductImages.FindAsync(ImageId);
            if (image == null)
            {
                return new ApiErrorResult<int>($"Cannot find image with id {ImageId}");
            }
            _context.ProductImages.Remove(image);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<int>();
        }

        public async Task<ApiResult<PagedResult<ProductImageVM>>> GetListImage(string productId, ProductImagePagingRequest request)
        {
            var query = from pi in _context.ProductImages
                        join p in _context.Products on pi.ProductId equals p.Id
                        select pi;
            var totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new ProductImageVM()
                {
                    Id = x.Id,
                    Caption = x.Caption,
                    ProductId = x.ProductId,
                    DateCreated = x.DateCreated,
                    FileSize = x.FileSize,
                    ImagePath = x.ImagePath,
                    IsDefault = x.IsDefault,
                    SortOrder = x.SortOrder
                }).ToListAsync();
            var pagedResult = new PagedResult<ProductImageVM>
            {
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRow,
            };
            return new ApiSuccessResult<PagedResult<ProductImageVM>>(pagedResult);
        }

        public async Task<ApiResult<ProductImageVM>> GetImageById(int ImageId)
        {
            var image = await _context.ProductImages.FindAsync(ImageId);
            if (image == null)
            {
                return new ApiErrorResult<ProductImageVM>($"Cannot find image with id {ImageId}");
            }
            var data = new ProductImageVM
            {
                Id = image.Id,
                Caption = image.Caption,
                ProductId = image.ProductId,
                DateCreated = image.DateCreated,
                FileSize = image.FileSize,
                ImagePath = image.ImagePath,
                IsDefault = image.IsDefault,
                SortOrder = image.SortOrder
            };

            return new ApiSuccessResult<ProductImageVM>(data);
        }

        public async Task<ApiResult<ProductVM>> GetById(string producId)
        {
            var product = await _context.Products.FindAsync(producId);
            if (product == null)
            {
                return new ApiErrorResult<ProductVM>($"Cannot find image with id {producId}");
            }
            var productvm = new ProductVM
            {
                Id = product.Id,
                Name = product.Name,
                Unit = product.Unit,
                Stock = product.Stock,
                ViewCount = product.ViewCount,
                DateCreated = product.DateCreated
            };
            return new ApiSuccessResult<ProductVM>(productvm);
        }
    }
}