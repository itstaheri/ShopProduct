using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Models.SMS.Kavenegar
{
    public class KavenegarSendSingleSmsRequest : SendSmsBaseRequest
    {
        
    }
    public class KavenegarSendSingleSmsResponse
    {
        public int status { get; set; }
        public string? statustext { get; set; }
    }
}
