using Common;
using Shop.Application.Interfaces.Auth;
using Shop.Application.Mapper;
using Shop.Application.MessageResult;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.Profile;
using Shop.Domain.Dtos.User;
using Shop.Domain.Entities.Profile;
using Shop.Domain.Entities.User;
using Shop.Domain.Repositories.Profile;
namespace Shop.Application.Services
{
    public interface IProfileService
    {
        public Task<OperationResult<UserInformationDto>> GetProfileInformationAsync(long userId, CancellationToken cancellationToken);
        public Task<OperationResult<List<UserAddressDto>>> GetUserAddressAsync(long userId, CancellationToken cancellationToken);
        public Task<OperationResult> AddAddressAsync(AddUserAddressDto commend, CancellationToken cancellationToken);

    }

    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IJwtAuthentication _auth;

        public ProfileService(IProfileRepository profileRepository, IUserAddressRepository userAddressRepository, IJwtAuthentication auth)
        {
            _profileRepository = profileRepository;
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

                return new OperationResult<List<UserAddressDto>>(userAddressesResult, true, ProfileMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OperationResult<UserInformationDto>> GetProfileInformationAsync(long userId, CancellationToken cancellationToken)
        {
            try
            {
                var userProfiel = await _profileRepository.GetAsync(x => x.UserId == userId, cancellationToken, true, x => x.User);
                var userDto = GeneralMapper.Map<UserModel, UserInfoDto>(userProfiel.User);
                var userInformationDto = GeneralMapper.Map<UserInformationModel, UserInformationDto>(userProfiel);
                userInformationDto.UserInfo = userDto;
                userInformationDto.BirthDate = userProfiel.BirthDate.ToFarsi();


                return new OperationResult<UserInformationDto>(userInformationDto, true, ProfileMessageResult.OperationSuccess);
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
                return new OperationResult(true, ProfileMessageResult.OperationSuccess);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

}
