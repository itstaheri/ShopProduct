using Common.Converter;
using Microsoft.Extensions.Caching.Distributed;
using Shop.Application.Mapper;
using Shop.Application.MessageResult;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.Profile;
using Shop.Domain.Entities.Profile;
using Shop.Domain.Enums;
using Shop.Domain.Repositories.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public interface IUserFavoriteService
    {
        public Task<OperationResult> AddUserFavoriteAsync(AddUserFavoriteRequestDto favorite, CancellationToken cancellationToken);
        public Task<OperationResult<List<UserFavoriteDto>>> GetUserFavoriteAsync(GetUserFavoriteFilterRequestDto favorite, CancellationToken cancellationToken);
        public Task<OperationResult> RemoveUserFavoriteAsync(long userFavoriteId, CancellationToken cancellationToken);
    }

    public class UserFavoriteService : IUserFavoriteService
    {
        private readonly IUserFavoriteRepository _userFavoriteRepository;
        private readonly IDistributedCache _cache;

        public UserFavoriteService(IUserFavoriteRepository userFavoriteRepository, IDistributedCache cache)
        {
            _userFavoriteRepository = userFavoriteRepository;
            _cache = cache;
        }

        public async Task<OperationResult> AddUserFavoriteAsync(AddUserFavoriteRequestDto favorite, CancellationToken token)
        {
            try
            {
                var userFavoriteModel = new UserFavoriteModel(favorite.UserId, favorite.ProductId);
                await _userFavoriteRepository.AddAsync(userFavoriteModel, token);
                return new OperationResult(true, ProfileMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OperationResult<List<UserFavoriteDto>>> GetUserFavoriteAsync(GetUserFavoriteFilterRequestDto userFavoriteFilter, CancellationToken cancellationToken)
        {
            try
            {
                var userFavoriteDto = new List<UserFavoriteDto>();

                if (_cache.GetAsync(Cache.UserCart.ToString()) == null)
                {
                    var userFavorites = await _userFavoriteRepository.GetAllWithPaginationAsync(new GetUserFavoriteFilterRequestDto
                    {
                        Page = 1,
                        PageSize = 10,
                        UserId = userFavoriteFilter.UserId,
                    }, cancellationToken);

                    foreach (var userFavorite in userFavorites.List)
                    {
                        userFavoriteDto.Add(GeneralMapper.Map<UserFavoriteModel, UserFavoriteDto>(userFavorite));
                    }

                    _cache.Set(Cache.UserFavorite.ToString(), BinarySerializer.SerializeToBinary<List<UserFavoriteDto>>(userFavoriteDto));

                }
                else
                {
                    userFavoriteDto = BinarySerializer.DeserializeFromBinary<List<UserFavoriteDto>>(_cache.Get(Cache.UserFavorite.ToString()));
                }
                return new OperationResult<List<UserFavoriteDto>>(userFavoriteDto, true, ProfileMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OperationResult> RemoveUserFavoriteAsync(long userFavoriteId, CancellationToken cancellation)
        {
            try
            {
                _userFavoriteRepository.Remove(userFavoriteId);
                return new OperationResult(true, ProfileMessageResult.OperationSuccess);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
