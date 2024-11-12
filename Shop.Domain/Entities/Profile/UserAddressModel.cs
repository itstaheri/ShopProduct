using Shop.Domain.Entities.BaseData;
using Shop.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Profile
{
    public class UserAddressModel : BaseEntity
    {

        public UserAddressModel()
        {
                
        }
        public UserAddressModel(long userId,  long city, string title, string description, string postalCode, string mobile, string? phone)
        {
            UserId = userId;
            CityId = city;
            Title = title;
            Description = description;
            PostalCode = postalCode;
            Mobile = mobile;
            Phone = phone;
        }

        public void Edit(long userId,  long city, string title, string description, string postalCode,string mobile,string? phone)
        {
            UserId = userId;
            CityId = city;
            Title = title;
            Description = description;
            PostalCode = postalCode;
            Mobile = mobile;
            if(!string.IsNullOrEmpty(phone)) 
                Phone = phone;
        }

        public long UserId { get; private set; }
        public long? CityId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string PostalCode { get; private set; }
        public long UserInformationId { get; private set; }
        public string Mobile {  get; private set; }
        public string? Phone { get; private set; }
        public UserInformationModel UserInformation { get; private set; }
        public CityModel City { get; private set; }

    }
}
