using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.User
{
    public record LoginOrSignupWithPhoneRequestDto
    {
        public string PhoneNumber { get; set; } 
    }
}
