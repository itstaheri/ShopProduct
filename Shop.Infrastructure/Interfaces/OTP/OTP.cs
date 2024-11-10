using Common.Generator;
using Newtonsoft.Json;
using Shop.Application.Interfaces.Cache;
using Shop.Application.Interfaces.Email;
using Shop.Application.Interfaces.OTP;
using Shop.Application.Interfaces.Sms;
using Shop.Application.MessageResult;
using Shop.Domain.CustomException.OTP;
using Shop.Domain.Enums;
using Shop.Domain.Models.OTP;
using Shop.Domain.Models.SMS.Kavenegar;
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
        private readonly ISMS _sms;
        private readonly IEmail _email;
        public OTP(IDistributedCacheService cache, ISMS sms, IEmail email)
        {
            _cache = cache;
            if (ExpireAt == null)
                throw new ExpireAtNullException();
            _sms = sms;
            _email = email;
        }

        private OTPResult CheckOtpRequestAccess(string key)
        {
            var otpValue = _cache.Get(key);
            if (otpValue == null) return new OTPResult(OTPMessageResult.OperationSuccess, true);
            OTPInfo otpInfo = JsonConvert.DeserializeObject<OTPInfo>(otpValue);

            if (otpInfo.IsActive)
            {
                if (otpInfo.ExpireDate > DateTime.Now)
                {
                    return new OTPResult(OTPMessageResult.ActiveOtpExist, false);
                }

            }


            return new OTPResult(OTPMessageResult.OperationSuccess, true);


        }
        public override OTPResult CheckOTPCode(CheckOTP otp)
        {
            var otpValue = _cache.Get(otp.Refrence);
            if (otpValue == null)
            {
                return new OTPResult(OTPMessageResult.OTPNotExistForThisKey, false);
            }
            else
            {
                OTPInfo otpInfo = JsonConvert.DeserializeObject<OTPInfo>(otpValue);
                if (otp.Code != otpInfo.Code)
                {
                    return new OTPResult(OTPMessageResult.OTPWrong, false);
                }
                else if (!otpInfo.IsActive)
                {
                    return new OTPResult(OTPMessageResult.OTPNotActive, false);

                }
                else if (otpInfo.ExpireDate < DateTime.Now)
                {
                    return new OTPResult(OTPMessageResult.OTPExpierd, false);
                }

            }
            DisableOTP(otp.Refrence);
            return new OTPResult(OTPMessageResult.OperationSuccess, true);

        }

        public override void DisableOTP(string key)
        {
            var otpValue = _cache.Get(key);
            if (otpValue != null)
            {
                OTPInfo otpInfo = JsonConvert.DeserializeObject<OTPInfo>(otpValue);
                otpInfo.IsActive = false;

                _cache.Set(key, JsonConvert.SerializeObject(otpInfo));
            }

        }

        public override OTPResult Send(SendOTP otp)
        {
            var check = CheckOtpRequestAccess(otp.Refrence);
            if (!check.Success) return check;

            string Key = otp.Refrence;
            OTPInfo otpInfo = new OTPInfo
            {
                CreateDate = DateTime.Now,
                ExpireDate = ExpireAt,
                Code = RandomTextGenerator.OTPCode(),
                IsActive = true,
                Refrence = otp.Refrence,
                OTPAction = Domain.Enums.OTPAction.SignUpLogin,
            };

            try
            {

                Console.WriteLine("code : " + otpInfo.Code);
                if (OTPChannel.SMS == otp.OTPChannel)
                {
                    //var sendSmsResult = _sms.Send<KavenegarSendSingleSmsRequest>(new KavenegarSendSingleSmsRequest
                    //{
                    //    Message = $"یکبار رمز : {otpInfo.Code}",
                    //    Receptor = Key
                    //});
                    //if (sendSmsResult.Status is 1)
                    //    _cache.Set(Key, JsonConvert.SerializeObject(otpInfo));
                    //else
                    //    return new OTPResult(OTPMessageResult.ErrorOnCallSmsApi, false);
                    _cache.Set(Key, JsonConvert.SerializeObject(otpInfo));

                }
                else if (OTPChannel.Email == OTPChannel.Email)
                {
                    _email.Send(new Domain.Models.Email.SendEmail
                    {
                        Body = $"یکبار رمز : {otpInfo.Code}",
                        Subject = "یکبار رمز",
                        To = otp.Refrence
                    });
                }
                else
                {
                    return new OTPResult(OTPMessageResult.ErrorOnCallSmsApi, false);

                }

                return new OTPResult(OTPMessageResult.OperationSuccess, true);


            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
