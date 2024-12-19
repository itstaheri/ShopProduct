using Common;
using Shop.Application.Interfaces.Auth;
using Shop.Application.Mapper;
using Shop.Application.MessageResult;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.Profile;
using Shop.Domain.Dtos.User;
using Shop.Domain.Entities.Profile;
using Shop.Domain.Entities.User;
using Shop.Domain.Enums;
using Shop.Domain.Repositories.Profile;
namespace Shop.Application.Services
{
    public interface IUserAddressService
    {
        public Task<OperationResult> AddAddressAsync(AddUserAddressDto addAddress, CancellationToken cancellationToken);
        public Task<OperationResult<List<UserAddressDto>>> GetUserAddressAsync(long userId, CancellationToken cancellationToken);
        public OperationResult UpdateAddress(UpdateUserAddressDto updateAddress);
        public OperationResult RemoveAddress(long userAddressId);


    }

    public class UserAddressService : IUserAddressService
    {
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IJwtAuthentication _auth;

        public UserAddressService(IUserAddressRepository userAddressRepository, IJwtAuthentication auth)
        {
            _userAddressRepository = userAddressRepository;
            _auth = auth;
        }

        public async Task<OperationResult<List<UserAddressDto>>> GetUserAddressAsync(long userId, CancellationToken cancellationToken)
        {
            try
            {
                var userAddresses = await _userAddressRepository.SelectAsync(x => x.UserId == userId, cancellationToken, x => x.City);

                var userAddressesResult = new List<UserAddressDto>();

                foreach (var userAddress in userAddresses)
                {
                    var ua = GeneralMapper.Map<UserAddressModel, UserAddressDto>(userAddress);
                    ua.CityTitle = userAddress.City.Name;
                    userAddressesResult.Add(ua);
                }

                return new OperationResult<List<UserAddressDto>>(userAddressesResult, true, OperationMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public async Task<OperationResult> AddAddressAsync(AddUserAddressDto commend, CancellationToken cancellationToken)
        {
            try
            {
                long userId = _auth.GetCurrentUserId();
                long profileId = Convert.ToInt64(_auth.ReadTokenCalim("ProfileId"));
                var addresModel = new UserAddressModel(userId, commend.CityId, commend.Title, commend.Description, commend.PostalCode, commend.ReciverMobile, commend.ReciverPhoneNumber, commend.FirstName, commend.LastName, profileId);
                await _userAddressRepository.AddAsync(addresModel, cancellationToken);
                return new OperationResult(true, OperationMessageResult.OperationSuccess);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public OperationResult RemoveAddress(long userAddressId)
        {
            try
            {
                _userAddressRepository.Remove(userAddressId);

                return new OperationResult(true, OperationMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OperationResult UpdateAddress(UpdateUserAddressDto updateAddress)
        {
            var checkAddress = _userAddressRepository.Get(x => x.Id == updateAddress.UserAddressId);
            if (checkAddress == null) return new OperationResult(false, OperationMessageResult.UserAddressNotFound);

            try
            {
                checkAddress.Edit(updateAddress.CityId, updateAddress.Title, updateAddress.Description, updateAddress.PostalCode, updateAddress.ReciverMobile,
                    updateAddress.ReciverPhoneNumber, updateAddress.FirstName, updateAddress.LastName);

                _userAddressRepository.Save();

                return new OperationResult(true, OperationMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
