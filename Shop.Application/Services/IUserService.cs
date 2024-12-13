using Shop.Domain.Dtos;
using Shop.Domain.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Cryptography;
using Shop.Domain.Repositories;
using Shop.Domain.Enums;
using Shop.Domain.Entities.User;
using Shop.Application.Mapper;
using Shop.Application.MessageResult;
using System.Threading;
using Shop.Domain.Entities.Profile;
using Common.Generator;
using Shop.Domain.Dtos.User.Permission;
using Shop.Application.Interfaces.Dapper;
using Dapper;
using Shop.Domain.Repositories.User;
using Shop.Application.Interfaces.Sms;
using Shop.Domain.Models.SMS.Kavenegar;

namespace Shop.Application.Services
{
    public interface IUserService
    {
        public OperationResult<UserInfoDto> Login(LoginDto login);
        public Task<OperationResult<UserInfoDto>> SignupWithDetailAsync(CreateUserDto createUser, CancellationToken cancellationToken);
        public Task<OperationResult<UserInfoDto>> LoginOrSignupWithPhoneAsync(string phoneNumber, CancellationToken cancellationToken);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IPermissionRepository _permission;
        private readonly IGenericRepository<UserInformationModel> _userInformationRepository;
        private readonly IDapperContext _dapper;
        private readonly ISMS _sms;
        public UserService(IUserRepository userRepository, IUserRoleRepository userRoleRepository, IPermissionRepository permission, IGenericRepository<UserInformationModel> userInformationRepository, IDapperContext dapper, ISMS sms)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _permission = permission;
            _userInformationRepository = userInformationRepository;
            _dapper = dapper;
            _sms = sms;
        }

        public OperationResult<UserInfoDto> Login(LoginDto login)
        {
            try
            {
                var user = _userRepository.Get(x => x.Username == login.Username && x.Password == login.Password.ToSha256());


                if (user is null) return new OperationResult<UserInfoDto>(null, false, UserMessageResult.UserInvalid);
                if (!user.IsActive) return new OperationResult<UserInfoDto>(null, false, UserMessageResult.UserIsDeActive);

                var result = GeneralMapper.Map<UserModel, UserInfoDto>(user);
                result.CreateAtShamsi = user.CreatedAt.ToFarsi();
                var permissions =  GetUserPermissions(user.Id).Result;
                result.Permissions = permissions.Select(x => (Permission)x.PermissionId).ToList();
                result.ProfileId = user.UserInformation.Id;
                return new OperationResult<UserInfoDto>(result, true, BaseMessageResult.OperationSuccess);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async Task<List<UserPermisionResultDto>> GetUserPermissions(long userId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserId", userId);
                var permissions = await _dapper.CallSPAsync<UserPermisionResultDto>("SP_ReturnUserPermissions", parameters);

                return permissions.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<OperationResult<UserInfoDto>> LoginOrSignupWithPhoneAsync(string phoneNumber, CancellationToken cancellationToken)
        {
            try
            {
                var userInfo = new UserInfoDto();
                var userExist = await _userRepository.GetAsync(x => x.PhoneNumber == phoneNumber, cancellationToken, true, x => x.UserInformation, x => x.UserRoles);



                if (userExist is not null)
                {
                    var permissions = await GetUserPermissions(userExist.Id);
                    userInfo = GeneralMapper.Map<UserModel, UserInfoDto>(userExist);
                    userInfo.Permissions = permissions.Select(x => (Permission)x.PermissionId).ToList();
                    userInfo.ProfileId = userExist.UserInformation.Id;
                    //await _sms.SendAsync<KavenegarSendSingleSmsRequest>(new KavenegarSendSingleSmsRequest
                    //{
                    //    Message = $"ورود موفق {DateTime.Now.ToFarsi() + " " + DateTime.Now.ToFarsiHoure()}",
                    //    Receptor = phoneNumber
                    //});
                }
                else
                {
                    try
                    {
                        string randomPassword = RandomTextGenerator.GenerateStrongPassword();
                        var signupResult = await SignupWithDetailAsync(new CreateUserDto
                        {
                            PhoneNumber = phoneNumber,
                            Password = randomPassword,
                            RePassword = randomPassword,
                            Username = $"Guest{phoneNumber}"

                        }, cancellationToken);
                      
                        userInfo = signupResult.Result;
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }

                }

                return new OperationResult<UserInfoDto>(userInfo, true, UserMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<OperationResult<UserInfoDto>> SignupWithDetailAsync(CreateUserDto createUser, CancellationToken cancellationToken)
        {
            var checkUser = await _userRepository.AnyAsync(x => x.Username == createUser.Username, cancellationToken);
            if (checkUser is true) return new OperationResult<UserInfoDto>(null,false, UserMessageResult.UsernameExist);
            checkUser = await _userRepository.AnyAsync(x => x.PhoneNumber == createUser.PhoneNumber, cancellationToken);
            if (checkUser is true) return new OperationResult<UserInfoDto>(null, false, UserMessageResult.PhonenumbeerExist);

            var transaction = _userRepository.OpenTransaction();


            try
            {
                //add user
                var userModel = new UserModel(createUser.Username, createUser.Password.ToSha256(), createUser.Email, createUser.PhoneNumber);
                var user = await _userRepository.AddAsync(userModel, cancellationToken);

                //add member role for user
                var userRoleModel = new UserRoleModel((int)Role.Member, user.Id);
                await _userRoleRepository.AddAsync(userRoleModel, cancellationToken);

                //initial user information
                var userInformationModel = new UserInformationModel(userModel.Id);
                await _userInformationRepository.AddAsync(userInformationModel, cancellationToken);

                await _userRepository.SaveAsync(cancellationToken);

                await transaction.CommitAsync();

                var permissions = await GetUserPermissions(user.Id);

                return new OperationResult<UserInfoDto>(new UserInfoDto
                {
                    CreateAt = user.CreatedAt,
                    CreateAtShamsi = user.CreatedAt.ToFarsi(),
                    Id = user.Id,
                    IsActive = user.IsActive,
                    Permissions = permissions.Select(x => (Permission)x.PermissionId).ToList()
                }, true, UserMessageResult.OperationSuccess);

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message, ex.InnerException);
            }



        }
    }
}
