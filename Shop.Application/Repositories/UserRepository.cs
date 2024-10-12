using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Database;
using Shop.Application.Mapper;
using Shop.Application.MessageResult;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.User;
using Shop.Domain.Entities.Profile;
using Shop.Domain.Entities.User;
using Shop.Domain.Enums;
using Shop.Domain.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationEfCoreContext _context;

        public UserRepository(IApplicationEfCoreContext context)
        {
            _context = context;
        }

        public OperationResult<UserInfoDto> CheckUserValid(string username, string password)
        {
            try
            {
                var user = _context.Users.AsNoTracking()
                    .FirstOrDefault(x => x.Username == username && x.Password == password);
                if (user is null) return new OperationResult<UserInfoDto>(null, false, UserMessageResult.UserInvalid);
                if (!user.IsActive) return new OperationResult<UserInfoDto>(null, false, UserMessageResult.UserIsDeActive);

                var result = GeneralMapper.Map<UserModel, UserInfoDto>(user);

                return new OperationResult<UserInfoDto>(result, true, BaseMessageResult.OperationSuccess);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<OperationResult> CreateUserAsync(CreateUserDto createUser, CancellationToken cancellationToken)
        {
            try
            {
                var checkUser = await _context.Users.AsNoTracking().AnyAsync(x => x.Username == createUser.Username, cancellationToken);
                if (checkUser is true) return new OperationResult(false, UserMessageResult.UsernameExist);
                checkUser = await _context.Users.AsNoTracking().AnyAsync(x => x.PhoneNumber == createUser.PhoneNumber, cancellationToken);
                if (checkUser is true) return new OperationResult(false, UserMessageResult.PhonenumbeerExist);

                var transaction = _context.Database.BeginTransaction();

                try
                {
                    //add user
                    var userModel = new UserModel(createUser.Username, createUser.Password, createUser.Email, createUser.PhoneNumber);
                    var user = await _context.Users.AddAsync(userModel, cancellationToken);

                    //add member role for user
                    var userRoleModel = new UserRoleModel((int)Role.Member, user.Entity.Id);
                    await _context.UserRoles.AddAsync(userRoleModel, cancellationToken);

                    //initial user information
                    var userInformationModel = new UserInformationModel(userModel.Id);
                    await _context.UsersInformations.AddAsync(userInformationModel, cancellationToken);

                    await _context.SaveChangesAsync(cancellationToken);

                    await transaction.CommitAsync();

                    return new OperationResult(true, UserMessageResult.OperationSuccess);

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message, ex.InnerException);
                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
