using Shop.Domain.Entities.User;
using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Profile
{
    public class UserInformationModel : BaseEntity
    {
        public UserInformationModel()
        {
                
        }

        public UserInformationModel(long userID) => UserId = userID;
        public UserInformationModel(string? nationalCode, DateTime? birthDate, Gender? gender, bool? isMarried, string? firstname, string? lastname, long userId)
        {
            NationalCode = nationalCode;
            BirthDate = birthDate;
            Gender = gender;
            IsMarried = isMarried;
            Firstname = firstname;
            Lastname = lastname;
            UserId = userId;
        }
        public void Edit(string? nationalCode, DateTime? birthDate, Gender? gender, bool? isMarried, string? firstname, string? lastname)
        {
            NationalCode = nationalCode;
            BirthDate = birthDate;
            Gender = gender;
            IsMarried = isMarried;
            Firstname = firstname;
            Lastname = lastname;
        }

        public string? NationalCode { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public Gender? Gender { get; private set; }
        public bool? IsMarried { get; private set; }
        public string? Firstname { get; private set; }
        public string? Lastname { get; private set; }
        public long UserId { get; private set; }
        public UserModel User { get; private set; }
        public List<UserAddressModel> UserAddresses { get; private set; }


    }
}
