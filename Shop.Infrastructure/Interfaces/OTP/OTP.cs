using Common.Generator;
using Newtonsoft.Json;
using Shop.Application.Interfaces.Cache;
using Shop.Application.Interfaces.OTP;
using Shop.Application.MessageResult;
using Shop.Domain.CustomException.OTP;
using Shop.Domain.Models.OTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Shop.Infrastructure.Interfaces.OTP
{
    public class OTP : OTPAbstraction
    {
        private readonly IDistributedCacheService _cache;
        public OTP(IDistributedCacheService cache)
        {
            _cache = cache;
            if (ExpireAt == null)
                throw new ExpireAtNullException();

        }

        public override OTPResult CheckOTP(CheckOTP otp)
        {
            var otpValue = _cache.Get(otp.Key);
            if (otpValue == null)
            {
                return new OTPResult(OTPMessageResult.OTPNotExistForThisKey, false);
            }
            else
            {
                if (otpValue == otp.Code)
                {
                    OTPInfo otpInfo = JsonConvert.DeserializeObject<OTPInfo>(otpValue);
                    if (otp.Key != otpInfo.Refrence && otp.Code != otpInfo.Code)
                    {
                        return new OTPResult(OTPMessageResult.OTPWrong, false);
                    }
                    else if (!otpInfo.IsActive)
                    {
                        return new OTPResult(OTPMessageResult.OTPNotActive, false);

                    }
                    else if (otpInfo.ExpireDate > DateTime.Now)
                    {
                        return new OTPResult(OTPMessageResult.OTPExpierd, false);
                    }


                }
            }
            DisableOTP(otp.Key);
            return new OTPResult(OTPMessageResult.OperationSuccess, true);

        }

        public override void DisableOTP(string key)
        {
            var otpValue = _cache.Get(key);
            if(otpValue != null)
            {
                OTPInfo otpInfo = JsonConvert.DeserializeObject<OTPInfo>(otpValue);
                otpInfo.IsActive = false;

                _cache.Set(key, JsonConvert.SerializeObject(otpInfo));
            }

        }

        public override string Send(SendOTP otp)
        {
            string Key = Guid.NewGuid().ToString();
            OTPInfo otpInfo = new OTPInfo
            {
                CreateDate = DateTime.Now,
                ExpireDate = ExpireAt,
                Code = RandomTextGenerator.OTPCode(),
                IsActive = true,
                Refrence = otp.Refrence,
                OTPAction = Domain.Enums.OTPAction.SignUpLogin,
            };
            _cache.Set(Key, JsonConvert.SerializeObject(otpInfo));

            return Key;
        }
    }
}
