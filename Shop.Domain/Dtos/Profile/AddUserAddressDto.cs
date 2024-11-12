using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Profile
{
    public record AddUserAddressDto
    {
        public long CityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PostalCode { get; set; }
        public string ReciverMobile { get; set; }
        public string ReciverPhoneNumber { get; set; }

    }
}
