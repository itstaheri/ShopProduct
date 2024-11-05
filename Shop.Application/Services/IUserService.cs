﻿using Shop.Domain.Dtos;
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

namespace Shop.Application.Services
{
    public interface IUserService
    {
        public OperationResult<UserInfoDto> Login(LoginDto login);
        public Task<OperationResult> SignupWithDetailAsync(CreateUserDto createUser, CancellationToken cancellationToken);
        public Task<OperationResult> LoginOrSignupWithPhoneAsync(string phoneNumber, CancellationToken cancellationToken);
    }
    public class UserService : IUserService
    {
        private readonly IGenericRepository<UserModel> _userRepository;
        private readonly IGenericRepository<UserRoleModel> _userRoleRepository;
        private readonly IGenericRepository<PermissionModel> _permission;
        private readonly IGenericRepository<UserInformationModel> _userInformationRepository;
        private readonly IDapperContext _dapper;
        public UserService(IGenericRepository<UserModel> userRepository, IGenericRepository<UserRoleModel> userRoleRepository, IGenericRepository<PermissionModel> permission, IGenericRepository<UserInformationModel> userInformationRepository, IDapperContext dapper)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _permission = permission;
            _userInformationRepository = userInformationRepository;
            _dapper = dapper;
        }

        public OperationResult<UserInfoDto> Login(LoginDto login)
        {
            try
            {
                var user = _userRepository.Get(x => x.Username == login.Username && x.Password == login.Password.ToSha256());


                if (user is null) return new OperationResult<UserInfoDto>(null, false, UserMessageResult.UserInvalid);
                if (!user.IsActive) return new OperationResult<UserInfoDto>(null, false, UserMessageResult.UserIsDeActive);

                var result = GeneralMapper.Map<UserModel, UserInfoDto>(user);
                var permissions =  GetUserPermissions(user.Id).Result;
                result.Permissions = permissions.Select(x => (Permission)x.PermissionId).ToList();

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
        public async Task<OperationResult> LoginOrSignupWithPhoneAsync(string phoneNumber, CancellationToken cancellationToken)
        {
            try
            {
                var userInfo = new UserInfoDto();
                var userExist = await _userRepository.GetAsync(x => x.PhoneNumber == phoneNumber, cancellationToken, true, x => x.UserInformation, x => x.UserRoles);

                if (userExist is not null)
                {
                    var permissions = await GetUserPermissions(userInfo.Id);
                    userInfo = GeneralMapper.Map<UserModel, UserInfoDto>(userExist);
                    userInfo.Roles = userExist.UserRoles.Select(x => x.RoleId).ToList();
                    userInfo.Permissions = permissions.Select(x => (Permission)x.PermissionId).ToList();
                }
                else
                {
                    try
                    {
                        string randomPassword = RandomTextGenerator.GenerateStrongPassword();
                        var result = await SignupWithDetailAsync(new CreateUserDto
                        {
                            PhoneNumber = phoneNumber,
                            Password = randomPassword,
                            RePassword = randomPassword,
                            Username = $"Guest{phoneNumber}"

                        }, cancellationToken);
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

        public async Task<OperationResult> SignupWithDetailAsync(CreateUserDto createUser, CancellationToken cancellationToken)
        {
            var checkUser = await _userRepository.AnyAsync(x => x.Username == createUser.Username, cancellationToken);
            if (checkUser is true) return new OperationResult(false, UserMessageResult.UsernameExist);
            checkUser = await _userRepository.AnyAsync(x => x.PhoneNumber == createUser.PhoneNumber, cancellationToken);
            if (checkUser is true) return new OperationResult(false, UserMessageResult.PhonenumbeerExist);

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

                return new OperationResult(true, UserMessageResult.OperationSuccess);

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message, ex.InnerException);
            }



        }
    }
}
