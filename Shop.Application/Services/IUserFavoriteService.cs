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

        public UserFavoriteService(IUserFavoriteRepository userFavoriteRepository)
        {
            _userFavoriteRepository = userFavoriteRepository;
        }

        public async Task<OperationResult> AddUserFavoriteAsync(AddUserFavoriteRequestDto favorite, CancellationToken token)
        {
            try
            {
                var userFavoriteModel = new UserFavoriteModel(favorite.UserId, favorite.ProductId);
                await _userFavoriteRepository.AddAsync(userFavoriteModel, token);
                return new OperationResult(true, OperationMessageResult.OperationSuccess);
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


                var userFavorites = await _userFavoriteRepository.GetAllWithPaginationAsync(new GetUserFavoriteFilterRequestDto
                {
                    Page = userFavoriteFilter.Page,
                    PageSize = userFavoriteFilter.PageSize,
                    UserId = userFavoriteFilter.UserId,
                }, cancellationToken);

                foreach (var userFavorite in userFavorites.List)
                {
                    userFavoriteDto.Add(GeneralMapper.Map<UserFavoriteModel, UserFavoriteDto>(userFavorite));
                }

                return new OperationResult<List<UserFavoriteDto>>(userFavoriteDto, true, OperationMessageResult.OperationSuccess);
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
                return new OperationResult(true, OperationMessageResult.OperationSuccess);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
