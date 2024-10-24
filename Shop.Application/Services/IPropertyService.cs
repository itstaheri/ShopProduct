﻿using Shop.Application.Mapper;
using Shop.Application.MessageResult;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.Product;
using Shop.Domain.Dtos.Property;
using Shop.Domain.Entities.Category;
using Shop.Domain.Entities.Product;
using Shop.Domain.Entities.Property;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public interface IPropertyService
    {
        public Task<OperationResult<List<PropertyDto>>> GetAllPropertyAsync(string Name, CancellationToken cancellationToken);
        public Task<OperationResult<PropertyDto>> GetPropertyAsync(long PropertyId, CancellationToken cancellationToken);
        public OperationResult CreateProperty(CreatePropertyRequestDto createProperty);
        public OperationResult UpdateProperty(UpdatePropertyRequestDto updateProperty);
        public OperationResult DeleteProperty(long PropertyId);
    }

    public class PropertyService : IPropertyService
    {
        private readonly IGenericRepository<PropertyModel> _propertyRepository;
        private readonly IGenericRepository<CategoryModel> _categoryRepository;

        public PropertyService(IGenericRepository<PropertyModel> propertyRepository, IGenericRepository<CategoryModel> categoryRepository)
        {
            _propertyRepository = propertyRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<OperationResult<List<PropertyDto>>> GetAllPropertyAsync(string Name, CancellationToken cancellationToken)
        {
            try
            {
                var properties = await _propertyRepository.GetAllAsync(cancellationToken);

                if (!string.IsNullOrEmpty(Name))
                    properties = properties.Where(x => x.Name == Name);

                var propertyResult = new List<PropertyDto>();

                foreach (var property in properties)
                    propertyResult.Add(GeneralMapper.Map<PropertyModel, PropertyDto>(property));

                return new OperationResult<List<PropertyDto>>(propertyResult, true, PropertyMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OperationResult<PropertyDto>> GetPropertyAsync(long propertyId, CancellationToken cancellationToken)
        {
            try
            {
                var property = await _propertyRepository.GetAsync(x => x.Id == propertyId, cancellationToken, true);

                return new OperationResult<PropertyDto>(GeneralMapper.Map<PropertyModel, PropertyDto>(property), true, PropertyMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OperationResult CreateProperty(CreatePropertyRequestDto createProperty)
        {
            try
            {
                var propertyModel = new PropertyModel(createProperty.Name, createProperty.MeasurmentsUnit);

                _propertyRepository.Add(propertyModel);

                _propertyRepository.Save();

                return new OperationResult(true, PropertyMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OperationResult DeleteProperty(long propertyId)
        {

            try
            {
                _propertyRepository.Remove(propertyId);

                return new OperationResult(true, PropertyMessageResult.OperationSuccess);

            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public OperationResult UpdateProperty(UpdatePropertyRequestDto updateProperty)
        {
            var checkProperty = _propertyRepository.Get(x => x.Id == updateProperty.Id);
            if (checkProperty is null) return new OperationResult<PropertyDto>(null, false, PropertyMessageResult.PropertyNotFound);

            try
            {

                checkProperty.Edit(updateProperty.Name, updateProperty.MeasurmentsUnit);
                _propertyRepository.Save();

                return new OperationResult(true, PropertyMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
