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
        public UserAddressModel(long userId, int provinceId,  string title, string description, string postalCode)
        {
            UserId = userId;
            ProvinceId = provinceId;
            Title = title;
            Description = description;
            PostalCode = postalCode;
        }

        public void Edit(long userId, int provinceId,string title, string description, string postalCode)
        {
            UserId = userId;
            ProvinceId = provinceId;
            Title = title;
            Description = description;
            PostalCode = postalCode;
        }

        public long UserId { get; private set; }
        public int ProvinceId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string PostalCode { get; private set; }
        public long UserInformationId { get; private set; }
        public UserInformationModel UserInformation { get; private set; }
        public ProvinceModel Province { get; private set; }

    }
}
