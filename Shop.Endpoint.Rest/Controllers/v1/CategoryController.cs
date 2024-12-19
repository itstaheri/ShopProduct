using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Mapper;
using Shop.Application.Services;
using Shop.Domain.Dtos.Category;
using Shop.Endpoint.Rest.ActionFilters;

namespace Shop.Endpoint.Rest.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion(1)]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("GetAll")]
        public virtual async Task<IActionResult> GetAll([FromBody]GetCategoryRequestDto getCategory, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _categoryService.GetCategoryListAsync(getCategory, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetById")]
        public virtual async Task<IActionResult> GetById([FromQuery(Name = "GetById")] long categoryId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _categoryService.GetCategoryAsync(categoryId, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [JWTAuthorize]
        [HttpPost("Create")]
        public virtual IActionResult Create([FromBody] CreateCategoryDto createCategory)
        {
            try
            {
               var result =  _categoryService.CreateCategory(createCategory);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [JWTAuthorize]

        [HttpPost("Update")]
        public virtual IActionResult Update(UpdateCategoryDto updateCategory)
        {
            try
            {
               var result = _categoryService.UpdateCategory(updateCategory);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [JWTAuthorize]

        [HttpPost("Delete")]
        public virtual IActionResult Delete(DeleteCategoryRequestDto deleteCategory) 
        { 
            try
            {
              var result =   _categoryService.DeleteCategory(deleteCategory);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetMainCategoryList")]
        public async Task<IActionResult> GetMainCategoryList(CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetMainCategoryListAsync(cancellationToken);
            return Ok(result);
        }
    }
}
