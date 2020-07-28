using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doan.Application.Catalog.Products;
using Doan.ViewModels.Catalog.ProductImages;
using Doan.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doan.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        //hhtp:abc/api/products/pageIndex=1&pageSize=1&keyword=''
        public async Task<ActionResult> GetAll([FromQuery] ProductPagingRequest request)
        {
            var result = await _productService.GetAll(request);
            if (!result.IsSuccesed)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet("{productId}")]
        //hhtp:abc/api/products/1
        public async Task<ActionResult> GetId([FromQuery] string productId)
        {
            var result = await _productService.GetById(productId);
            if (!result.IsSuccesed)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.Create(request);

            if (!result.IsSuccesed)
            {
                return BadRequest();
            }
            var product = await _productService.GetById(result.ResultObj);

            return CreatedAtAction(nameof(GetId), new { id = result.ResultObj }, product);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.Update(request);
            if (!result.IsSuccesed)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete("{productId}")]
        //Exp: http:ac/api/product/1
        public async Task<ActionResult> Delete(string productId)
        {
            var result = await _productService.Delete(productId);
            if (!result.IsSuccesed)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPatch("{productId}/addview/{newView}")]
        //Exp: http:ac/api/product/1/999
        public async Task<ActionResult> AddViewCount(string productId, int newView)
        {
            var result = await _productService.AddViewCount(productId, newView);

            if (!result.IsSuccesed)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPatch("{productId}/addstock/{newStock}")]
        //Exp: http:ac/api/product/1/999
        public async Task<ActionResult> AddStock(string productId, int newStock)
        {
            var result = await _productService.UpdateStock(productId, newStock);

            if (!result.IsSuccesed)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost("{productId}/image")]
        //Exp: http:ac/api/1/image
        public async Task<ActionResult> CreateImage(string productId, [FromForm] ProductImageCreateRequest request)
        {
            var result = await _productService.AddImage(productId, request);

            if (!result.IsSuccesed)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut("{productId}/image/{imageId}")]
        //Exp: http:ac/api/1/image
        public async Task<ActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            var result = await _productService.UpdateImage(imageId, request);

            if (!result.IsSuccesed)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete("{productId}/image/{imageId}")]
        //Exp: http:ac/api/1/image
        public async Task<ActionResult> DeleteImage(int imageId)
        {
            var result = await _productService.RemoveImage(imageId);

            if (!result.IsSuccesed)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet("{productId}/image")]
        //Exp: http:ac/api/1/image
        public async Task<ActionResult> GetListImages(string productId, [FromQuery] ProductImagePagingRequest request)
        {
            var result = await _productService.GetListImage(productId, request);

            if (!result.IsSuccesed)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet("{productId}/image/{imageId}")]
        //Exp: http:ac/api/1/image/122
        public async Task<ActionResult> GetImageId(int imageId)
        {
            var result = await _productService.GetImageById(imageId);

            if (!result.IsSuccesed)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}