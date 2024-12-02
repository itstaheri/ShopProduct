using Shop.Domain.Dtos.Profile;
using Shop.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.Repositories.Profile;
using Shop.Domain.Entities.Profile;
using Shop.Application.MessageResult;
using Shop.Application.Mapper;
using Shop.Domain.Entities.Product;
using Shop.Domain.Dtos.Product;
using Shop.Application.Interfaces.Cache;
using Common.Converter;
using Shop.Domain.Enums;
using Shop.Domain.Repositories.Product;
using System.Xml.Linq;

namespace Shop.Application.Services
{
    public interface IUserCartService
    {
        public Task<OperationResult> AddUserCartAsync(AddUserCartRequestDto Cart, CancellationToken cancellationToken);
        public Task<OperationResult<List<UserCartDto>>> GetUserCartAsync(GetUserCartFilterRequestDto userCartFilter, CancellationToken cancellationToken);
        public Task<OperationResult> RemoveUserCartAsync(long userCartId, CancellationToken cancellationToken);
    }

    public class UserCartService : IUserCartService
    {
        private readonly IUserCartRepository _userCartRepository;

        public UserCartService(IUserCartRepository userCartRepository)
        {
            _userCartRepository = userCartRepository;
        }

        public async Task<OperationResult> AddUserCartAsync(AddUserCartRequestDto Cart, CancellationToken cancellationToken)
        {
            try
            {
                var userCartModel = new UserCartModel(Cart.UserId, Cart.ProductId, Cart.ColorId, Cart.Quantity);
                await _userCartRepository.AddAsync(userCartModel, cancellationToken);
                return new OperationResult(true, ProfileMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OperationResult<List<UserCartDto>>> GetUserCartAsync(GetUserCartFilterRequestDto userCartFilter, CancellationToken cancellationToken)
        {
            try
            {
                //var userCart = await _userCartRepository.GetAsync(x => x.UserId == userId, cancellationToken, true, x => x.Product);
                //var product = GeneralMapper.Map<ProductModel, ProductDto>(userCart.Product);
                //var userCartDto = GeneralMapper.Map<UserCartModel, UserCartDto>(userCart);
                //userCartDto.Product = product;

                //return new OperationResult<List<UserCartDto>>(userCartDto, true, ProfileMessageResult.OperationSuccess);
                var userCartDto = new List<UserCartDto>();


                var userCarts = await _userCartRepository.GetAllWithPaginationAsync(new GetUserCartFilterRequestDto
                    {
                        Page = userCartFilter.Page,
                        PageSize = userCartFilter.PageSize,
                        UserId = userCartFilter.UserId,
                    }, cancellationToken);

                foreach (var userCart in userCarts.List)
                {
                    userCartDto.Add(GeneralMapper.Map<UserCartModel, UserCartDto>(userCart));
                }

                return new OperationResult<List<UserCartDto>>(userCartDto, true, ProfileMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OperationResult> RemoveUserCartAsync(long userCartId, CancellationToken cancellation)
        {
            try
            {
                _userCartRepository.Remove(userCartId);
                return new OperationResult(true, ProfileMessageResult.OperationSuccess);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
