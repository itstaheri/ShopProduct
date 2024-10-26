using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.Entities.Profile;

namespace Shop.Domain.Entities.User
{
    public class UserModel : BaseEntity
    {
        public UserModel()
        {
                
        }
        public UserModel(string username, string password,
            string emaill, string phonenumber
            ) 
        {
            Username = username;
            Password = password;
            PhoneNumber = phonenumber;
            Email = emaill;
        }

        public void ChangeUsername(string username) => Username = username;

        public void ChangeEmail(string email) => Email = email;

        public void ChangePassword(string newPassword) => Password = newPassword;

        public string Username { get;private set; }
        public string Password   { get; private set; }
      
        public string PhoneNumber   { get; private set; }
        public string Email { get; private set; }

        public UserInformationModel UserInformation { get; private set; }
        public List<UserRoleModel> UserRoles { get; private set; }


    }
}
