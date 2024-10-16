using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Models.OTP
{
    public class SendOTP
    {
        public string Refrence { get; set; }
        public OTPChannel OTPChannel { get; set; }
    }
}
