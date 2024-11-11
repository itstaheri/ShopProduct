using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.OTP
{
    public record DisableOtpRequestDto
    {
        public string Key { get; set; }
    }
}
