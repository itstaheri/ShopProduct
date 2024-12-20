using Common.Converter;
using Shop.Application.Interfaces.Cache;
using Shop.Application.Mapper;
using Shop.Application.MessageResult;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.Category;
using Shop.Domain.Dtos.Product;
using Shop.Domain.Entities.Category;
using Shop.Domain.Entities.Inventory;
using Shop.Domain.Entities.Product;
using Shop.Domain.Enums;
using Shop.Domain.Repositories;
using Shop.Domain.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Application.Services
{
    public interface IProductService
    {
        public Task<OperationResult<PaginationResponsDto<ProductDto>>> FilterAllProductAsync(GetAllProductFilterRequestDto getAllProduct, CancellationToken cancellationToken);
        public Task<OperationResult<List<ProductDto>>> GetAllProductsAsync(CancellationToken cancellationToken);
        public Task<OperationResult<ProductDto>> GetProductAsync(long productId, CancellationToken cancellationToken);
        public Task<OperationResult> CreateProductAsync(CreateProductDto createProduct, CancellationToken cancellationToken);
        public OperationResult UpdateProduct(UpdateProductDto updateProduct);
        public OperationResult DeleteProduct(DeleteProductDto deleteProduct);

    }
    public class ProductService : IProductService
    {
        private readonly IProductPictureRepository _productPictureRepository;
        private readonly IProductCommentRepository _productCommentRepository;
        private readonly IProductPropertyRepository _productPropertyRepository;
        private readonly IProductInventoryRepository _productInventory;
        private readonly IProductRepository _productRepository;
        private readonly IDistributedCacheService _cache;

        public ProductService(IProductRepository productRepository, IProductPictureRepository productPictureRepository, IProductCommentRepository productCommentRepository, IProductPropertyRepository productPropertyRepository, IDistributedCacheService cache, IProductInventoryRepository productInventory)
        {
            _productRepository = productRepository;
            _productPictureRepository = productPictureRepository;
            _productCommentRepository = productCommentRepository;
            _productPropertyRepository = productPropertyRepository;
            _cache = cache;
            _productInventory = productInventory;
        }

        public async Task<OperationResult<PaginationResponsDto<ProductDto>>> FilterAllProductAsync(GetAllProductFilterRequestDto getAllProduct, CancellationToken cancellationToken)
        {
            try
            {
                var productResultDto = new List<ProductDto>();

                var products = await _productRepository.GetAllWithPaginationAsync(getAllProduct, cancellationToken);

                foreach (var product in products.List)
                {
                    productResultDto.Add(GeneralMapper.Map<ProductModel, ProductDto>(product));

                }
                return new OperationResult<PaginationResponsDto<ProductDto>>(new PaginationResponsDto<ProductDto>
                {
                    List = productResultDto,
                    TotalCount = productResultDto.Count
                }, true, OperationMessageResult.OperationSuccess);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OperationResult<ProductDto>> GetProductAsync(long productId, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productRepository.GetProductAsync(productId,cancellationToken);
                var prodcutDto = new ProductDto();

                prodcutDto = GeneralMapper.Map<ProductModel, ProductDto>(product);
                prodcutDto.Colors = product.InventoryItems.Select(x => new Domain.Dtos.Inventory.ColorDto
                {
                    Id = x.Color.Id,
                    Name = x.Color.Name
                }).ToList();

                return new OperationResult<ProductDto>(prodcutDto, true, OperationMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OperationResult> CreateProductAsync(CreateProductDto createProduct, CancellationToken cancellationToken)
        {
            var transaction = _productRepository.OpenTransaction();

            try
            {

                var productModel = new ProductModel(createProduct.Name, createProduct.CategoryId, createProduct.Description, createProduct.ExteraDescription, createProduct.MainPicture);


               var productRecord = await _productRepository.AddAsync(productModel, cancellationToken);

                var productInventoryModel = createProduct.ProductInventories.Select(x => new ProductInventoryModel(productRecord.Id, x.InventoryItemId));

                await _productInventory.AddRangeAsync(productInventoryModel,cancellationToken);

                transaction.Commit();


                return new OperationResult(true, OperationMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;   
            }
        }

        public OperationResult DeleteProduct(DeleteProductDto deleteProduct)
        {

            try
            {
                _productRepository.Remove(deleteProduct.ProductId);
                _cache.Delete(Cache.Product.ToString());
                return new OperationResult(true, OperationMessageResult.OperationSuccess);

            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public OperationResult UpdateProduct(UpdateProductDto updateProduct)
        {
            var checkProduct = _productRepository.Get(x => x.Id == updateProduct.Id);
            if (checkProduct is null) return new OperationResult<ProductDto>(null, false, OperationMessageResult.ProductNotFound);

            try
            {

                checkProduct.Edit(updateProduct.Name, updateProduct.CategoryId, updateProduct.Description, updateProduct.ExteraDescription, updateProduct.MainPicture);
                _productRepository.Save();

                return new OperationResult(true, OperationMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<OperationResult<List<ProductDto>>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            try
            {
                var productResultDto = new List<ProductDto>();

                if (_cache.Get(Cache.Product.ToString()) == null)
                {
                    var products = await _productRepository.GetAllWithPaginationAsync(new GetAllProductFilterRequestDto
                    {
                        Page = 1,
                        PageSize = 10,
                        CategoryId = 0,
                        Name = null
                    }, cancellationToken);



                    foreach (var product in products.List)
                    {
                        productResultDto.Add(GeneralMapper.Map<ProductModel, ProductDto>(product));

                    }

                    _cache.Set(Cache.Product.ToString(), BinarySerializer.SerializeToBinary<List<ProductDto>>(productResultDto));


                }
                else
                {
                    productResultDto = BinarySerializer.DeserializeFromBinary<List<ProductDto>>(_cache.Get(Cache.Product.ToString()));
                }
                return new OperationResult<List<ProductDto>>(productResultDto, true, OperationMessageResult.OperationSuccess);

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
