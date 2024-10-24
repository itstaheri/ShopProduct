﻿using Shop.Application.Mapper;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public interface ICategoryService
    {
        public Task<OperationResult<List<CategoryDto>>> GetCategoryListAsync(GetCategoryRequestDto getCategory, CancellationToken cancellationToken);
        public OperationResult CreateCategory(CreateCategoryDto createCategory);
        public OperationResult UpdateCategory(UpdateCategoryDto updateCategory);
        public OperationResult DeleteCategory(long categoryId);
        public Task<OperationResult<CategoryDto>> GetCategoryAsync (long categoryId, CancellationToken cancellationToken);

    }

    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<CategoryModel> _categoryRepository;
        private readonly IGenericRepository<CategoryPropertyModel> _categoryPropertyRepository;
        private readonly IGenericRepository<ProductModel> _productRepository;

        public CategoryService(IGenericRepository<CategoryModel> categoryRepository, IGenericRepository<CategoryPropertyModel> categoryPropertyModel,
            IGenericRepository<ProductModel> productRepository)
        {
            _categoryRepository = categoryRepository;
            _categoryPropertyRepository = categoryPropertyModel;
        }

        public async Task<OperationResult<List<CategoryDto>>> GetCategoryListAsync (GetCategoryRequestDto getCategory, CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _categoryRepository.SelectAsync(x => x.IsActive || x.CategoryParentId == getCategory.CategoryParentId, cancellationToken);

                var categoryresult = new List<CategoryDto>();

                foreach (var category in categories)
                {
                    categoryresult.Add(GeneralMapper.Map<CategoryModel, CategoryDto>(category));
                }


                return new OperationResult<List<CategoryDto>>(categoryresult, true, BaseMessageResult.OperationSuccess);

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


                return new OperationResult(true, CategoryMessageResult.OperationSuccess);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public OperationResult UpdateCategory(UpdateCategoryDto updateCategory)
        {
            var checkCategory = _categoryRepository.Get(x => x.Id == updateCategory.CategoryId);
            if (checkCategory is null) return new OperationResult<CategoryDto>(null, false, CategoryMessageResult.CategoryNotFound);

            try
            {

                checkCategory.Edit(updateCategory.Name, updateCategory.Picture, updateCategory.CategoryParentId);
                _categoryRepository.Save();

                return new OperationResult(true, CategoryMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OperationResult DeleteCategory(long categoryId)
        {
            var checkDependency = _productRepository.Any(x => x.CategoryId == categoryId);
            if (!checkDependency) return new OperationResult<CategoryDto>(null, false, CategoryMessageResult.CanNotDeleteCategory);

            try
            {
                _categoryRepository.Remove(categoryId);
                return new OperationResult(true, CategoryMessageResult.OperationSuccess);

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

                
                return new OperationResult<CategoryDto>(GeneralMapper.Map<CategoryModel,CategoryDto>(category), true, BaseMessageResult.OperationSuccess);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

    }
}
