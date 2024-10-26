using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.MessageResult
{
    public class OTPMessageResult : BaseMessageResult
    {
        public const string OTPExpierd = "OTPExpierd";
        public const string OTPWrong = "OTPWrong";
        public const string OTPNotExistForThisKey = "OTPNotExistForThisKey";
        public const string OTPNotActive = "OTPNotActive";
        public const string OTPIsActive = "OTPIsActive";
        public const string ChannelIsNotDefiend = "ChannelIsNotDefiend";
        public const string ActiveOtpExist = "ActiveOtpExist";
    }
}
