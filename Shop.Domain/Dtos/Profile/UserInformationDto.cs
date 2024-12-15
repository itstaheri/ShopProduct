using Shop.Domain.Dtos.User;
using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Profile
{
    public record UserInformationDto 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public Gender Gender { get; set; }
        public string BirthDate { get; set; }
        public string PhoneNumber { get; set; }

    }
}
