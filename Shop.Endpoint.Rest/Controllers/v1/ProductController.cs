using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Mapper;
using Shop.Application.Services;
using Shop.Domain.Dtos.Product;
using Shop.Endpoint.Rest.ActionFilters;

namespace Shop.Endpoint.Rest.Controllers.v1
{
    [ApiController]
    [Route("api/v{vesion:apiVersion}/[controller]")]
    [ApiVersion(1)]
    [JWTAuthorize]
    [CheckPermision(Domain.Enums.Permission.All)]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("GetAll")]
        public virtual async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _productService.GetAllProductsAsync( cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Filter")]
        public virtual async Task<IActionResult> Filter([FromBody] GetAllProductFilterRequestDto getAllProduct, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _productService.FilterAllProductAsync(getAllProduct, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetById")]
        public virtual async Task<IActionResult> GetById([FromQuery(Name = "ProductId")] long productId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _productService.GetProductAsync(productId, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Create")]
        public virtual async Task<IActionResult> Create([FromBody] CreateProductDto createProduct,CancellationToken cancellationToken)
        {
            try
            {
              var result =  await _productService.CreateProductAsync(createProduct, cancellationToken);

                return Ok(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Update")]
        public virtual IActionResult Update(UpdateProductDto updateProduct)
        {
            try
            {
                _productService.UpdateProduct(updateProduct);

                return Ok();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Delete")]
        public virtual IActionResult Delete(DeleteProductDto deleteProduct)
        {
            try
            {
                _productService.DeleteProduct(deleteProduct);

                return Ok();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
