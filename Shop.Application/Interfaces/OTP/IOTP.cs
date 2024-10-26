using Shop.Domain.Models.OTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces.OTP
{
    public abstract class OTPAbstraction
    {
        public abstract OTPResult Send(SendOTP otp);
        public abstract OTPResult CheckOTPCode(CheckOTP otp);
        public abstract void DisableOTP(string key);
        public DateTime ExpireAt ;


    }
}
