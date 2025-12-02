using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstractionLayer;
using Shared;
using Shared.DTOS.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Authorize]

    [Route("api/[Controller]")]
    public class ProductsController(IServiceManager _serviceManager) :ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts([FromQuery] ProductQueryParams queryParams)
        { 
            var products =await _serviceManager.ProductService.GetAllProductsAsync(queryParams);
            return Ok(products);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _serviceManager.ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
        {
            var Brands = await _serviceManager.ProductService.GetAllBrandsAsync();
            return Ok(Brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllTypes()
        {
            var Types = await _serviceManager.ProductService.GetAllTypesAsync();
            return Ok(Types);
        }
    }
}
