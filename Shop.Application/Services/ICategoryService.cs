using Shop.Application.Mapper;
using Shop.Application.MessageResult;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.Category;
using Shop.Domain.Dtos.User;
using Shop.Domain.Entities.Category;
using Shop.Domain.Entities.Product;
using Shop.Domain.Entities.Profile;
using Shop.Domain.Entities.User;
using Shop.Domain.Enums;
using Shop.Domain.Repositories;
using Shop.Domain.Repositories.Category;
using Shop.Domain.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public interface ICategoryService
    {
        public Task<OperationResult<PaginationResponsDto<CategoryDto>>> GetCategoryListAsync(GetCategoryRequestDto getCategory, CancellationToken cancellationToken);
        public OperationResult CreateCategory(CreateCategoryDto createCategory);
        public OperationResult UpdateCategory(UpdateCategoryDto updateCategory);
        public OperationResult DeleteCategory(DeleteCategoryRequestDto deleteCategory);
        public Task<OperationResult<CategoryDto>> GetCategoryAsync (long categoryId, CancellationToken cancellationToken);
        public Task<OperationResult<List<CategoryDto>>> GetMainCategoryListAsync(CancellationToken cancellationToken);

    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryPropertyRepository _categoryPropertyRepository;
        private readonly IProductRepository _productRepository;

        public CategoryService(ICategoryRepository categoryRepository, ICategoryPropertyRepository categoryPropertyModel,
            IGenericRepository<ProductModel> productRepository)
        {
            _categoryRepository = categoryRepository;
            _categoryPropertyRepository = categoryPropertyModel;
        }

        public async Task<OperationResult<PaginationResponsDto<CategoryDto>>> GetCategoryListAsync(GetCategoryRequestDto getCategory, CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _categoryRepository.SelectAsync(x => x.IsActive && x.CategoryParentId == getCategory.CategoryParentId, cancellationToken);

                var categoryresult = new List<CategoryDto>();

                foreach (var category in categories)
                {
                    categoryresult.Add(GeneralMapper.Map<CategoryModel, CategoryDto>(category));
                }


                return new OperationResult<PaginationResponsDto<CategoryDto>>(new PaginationResponsDto<CategoryDto>
                {
                    List = categoryresult,
                    TotalCount = categoryresult.Count
                }, true, OperationMessageResult.OperationSuccess);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public OperationResult CreateCategory(CreateCategoryDto createCategory)
        {

            try
            {
                var categoryModel = new CategoryModel(createCategory.Name, createCategory.Picture, createCategory.CategoryParentId);
                _categoryRepository.Add(categoryModel);

                _categoryRepository.Save();


                return new OperationResult(true, OperationMessageResult.OperationSuccess);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public OperationResult UpdateCategory(UpdateCategoryDto updateCategory)
        {
            var checkCategory = _categoryRepository.Get(x => x.Id == updateCategory.CategoryId);
            if (checkCategory is null) return new OperationResult<CategoryDto>(null, false, OperationMessageResult.CategoryNotFound);

            try
            {

                checkCategory.Edit(updateCategory.Name, updateCategory.Picture, updateCategory.CategoryParentId);
                _categoryRepository.Save();

                return new OperationResult(true, OperationMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OperationResult DeleteCategory(DeleteCategoryRequestDto deleteCategory)
        {
            var checkDependency = _productRepository.Any(x => x.CategoryId == deleteCategory.CategoryId);
            if (!checkDependency) return new OperationResult<CategoryDto>(null, false, OperationMessageResult.CanNotDeleteCategory);

            try
            {
                _categoryRepository.Remove(deleteCategory.CategoryId);
                return new OperationResult(true, OperationMessageResult.OperationSuccess);

            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public async Task<OperationResult<CategoryDto>> GetCategoryAsync(long categoryId, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _categoryRepository.GetAsync(x => x.Id == categoryId, cancellationToken);

                
                return new OperationResult<CategoryDto>(GeneralMapper.Map<CategoryModel,CategoryDto>(category), true, OperationMessageResult.OperationSuccess);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<OperationResult<List<CategoryDto>>> GetMainCategoryListAsync(CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _categoryRepository.GetMainCategoryListAsync(cancellationToken);
                var categoryresult = new List<CategoryDto>();

                foreach (var category in categories)
                {
                    categoryresult.Add(GeneralMapper.Map<CategoryModel, CategoryDto>(category));
                }


                return new OperationResult<List<CategoryDto>>(categoryresult, true, OperationMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
