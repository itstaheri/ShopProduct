using Shop.Domain.Models.SMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces.Sms
{
    public interface ISMS
    {
        public  Task<SendSmsResponse> SendAsync<I>(I input) where I : SendSmsBaseRequest;
        public SendSmsResponse Send<I>(I input) where I : SendSmsBaseRequest;
    }
}
