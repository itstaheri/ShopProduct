using Shop.Application.Mapper;
using Shop.Application.MessageResult;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.Profile;
using Shop.Domain.Dtos.User;
using Shop.Domain.Entities.Profile;
using Shop.Domain.Entities.User;
using Shop.Domain.Repositories;
using Shop.Domain.Repositories.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public interface IProfileService 
    {
        public Task<OperationResult<UserInformationDto>> GetProfileInformationAsync(long userId, CancellationToken cancellationToken);
        public Task<OperationResult<List<UserAddressDto>>> GetUserAddressAsync(long userId, CancellationToken cancellationToken);
    }

    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IUserAddressRepository _userAddressRepository;

        public ProfileService(IProfileRepository profileRepository, IUserAddressRepository userAddressRepository)
        {
            _profileRepository = profileRepository;
            _userAddressRepository = userAddressRepository;
        }

        public async Task<OperationResult<List<UserAddressDto>>> GetUserAddressAsync(long userId, CancellationToken cancellationToken)
        {
            try
            {
                var userAddresses = await _userAddressRepository.SelectAsync(x => x.UserId == userId, cancellationToken);

                var userAddressesResult = new List<UserAddressDto>();
                
                foreach (var userAddress in userAddresses)
                {
                    userAddressesResult.Add(GeneralMapper.Map<UserAddressModel, UserAddressDto>(userAddress));
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
                var userProfiel = await _profileRepository.GetAsync(x=>x.UserId ==  userId, cancellationToken,true,x=>x.User);
                var userDto = GeneralMapper.Map<UserModel,UserInfoDto>(userProfiel.User);
                var userInformationDto = GeneralMapper.Map<UserInformationModel, UserInformationDto>(userProfiel);
                userInformationDto.UserInfo = userDto;


                return new OperationResult<UserInformationDto>(userInformationDto, true, ProfileMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
