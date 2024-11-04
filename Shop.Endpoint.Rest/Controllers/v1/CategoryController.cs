using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Services;
using Shop.Domain.Dtos.Category;
using Shop.Endpoint.Rest.ActionFilters;

namespace Shop.Endpoint.Rest.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion(1)]
    [JWTAuthorize]
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

                return Ok(result.Success);
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

                return Ok(result.Success);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Create")]
        public virtual IActionResult Create([FromBody] CreateCategoryDto createCategory)
        {
            try
            {
                _categoryService.CreateCategory(createCategory);

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Update")]
        public virtual IActionResult Update(UpdateCategoryDto updateCategory)
        {
            try
            {
                _categoryService.UpdateCategory(updateCategory);

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Delete")]
        public virtual IActionResult Delete(DeleteCategoryRequestDto deleteCategory) 
        { 
            try
            {
                _categoryService.DeleteCategory(deleteCategory);

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
