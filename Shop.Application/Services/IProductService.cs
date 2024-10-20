using Shop.Application.Mapper;
using Shop.Application.MessageResult;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.Category;
using Shop.Domain.Dtos.Product;
using Shop.Domain.Entities.Category;
using Shop.Domain.Entities.Product;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public interface IProductService
    {
        public Task<OperationResult<List<ProductDto>>> GetAllProductAsync(GetAllProductFilterRequestDto getAllProduct, CancellationToken cancellationToken);
        public Task<OperationResult<ProductDto>> GetProductAsync(long productId, CancellationToken cancellationToken);
        public OperationResult CreateProduct(CreateProductDto createProduct);
        public OperationResult UpdateProduct(UpdateProductDto updateProduct);
        public OperationResult DeleteProduct(long productId);

    }
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<ProductModel> _productRepository;
        private readonly IGenericRepository<ProductPictureModel> _productPictureRepository;
        private readonly IGenericRepository<ProductCommentModel> _productCommentRepository;
        private readonly IGenericRepository<ProductPropertyModel> _productPropertyRepository;

        public ProductService(IGenericRepository<ProductModel> productRepository, IGenericRepository<ProductPictureModel> productPictureRepository, IGenericRepository<ProductCommentModel> productCommentRepository, IGenericRepository<ProductPropertyModel> productPropertyRepository)
        {
            _productRepository = productRepository;
            _productPictureRepository = productPictureRepository;
            _productCommentRepository = productCommentRepository;
            _productPropertyRepository = productPropertyRepository;
        }

        public async Task<OperationResult<List<ProductDto>>> GetAllProductAsync(GetAllProductFilterRequestDto getAllProduct, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _productRepository.GetAllAsync(cancellationToken);

                if (!string.IsNullOrEmpty(getAllProduct.Name))
                    products = products.Where(x => x.Name == getAllProduct.Name);
                if (getAllProduct.CategoryId > 0)
                    products = products.Where(x => x.Equals(getAllProduct.CategoryId));

                var productResultDto = new List<ProductDto>();
                foreach (var product in products)
                {
                    productResultDto.Add(GeneralMapper.Map<ProductModel, ProductDto>(product));

                }

                return new OperationResult<List<ProductDto>>(productResultDto, true, ProductMessageResult.OperationSuccess);
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
                var product = await _productRepository.GetAsync(x => x.Id == productId, cancellationToken,true);


                return new OperationResult<ProductDto>(GeneralMapper.Map<ProductModel, ProductDto>(product), true, ProductMessageResult.OperationSuccess);
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
        } 

        public OperationResult CreateProduct(CreateProductDto createProduct) 
        {
            
            try
            {
                var productModel = new ProductModel(createProduct.Name, createProduct.CategoryId, createProduct.Description, createProduct.ExteraDescription, createProduct.MainPicture);
                
                _productRepository.Add(productModel);

                _productRepository.Save();

                return new OperationResult(true, ProductMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OperationResult DeleteProduct(long productId)
        {
        
            try
            {
                _productRepository.Remove(productId);
                    
                return new OperationResult(true, ProductMessageResult.OperationSuccess);

            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public OperationResult UpdateProduct(UpdateProductDto updateProduct)
        {
            var checkProduct = _productRepository.Get(x => x.Id == updateProduct.Id);
            if (checkProduct is null) return new OperationResult<ProductDto>(null, false, ProductMessageResult.ProductNotFound);

            try
            {

                checkProduct.Edit(updateProduct.Name, updateProduct.CategoryId, updateProduct.Description, updateProduct.ExteraDescription, updateProduct.MainPicture);
                _productRepository.Save();

                return new OperationResult(true, ProductMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
