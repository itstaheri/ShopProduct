using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Models.Api
{
    public class ThirdPartyApiConfig
    {
        public KavenegarApiConfig Kavenegar { get; set; }
    }
    public class KavenegarApiConfig
    {
        public string BaseUrl { get; set; }
        public string SendSmsMethod { get; set; }

    }
}
