using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Models.OTP
{
    public class OTPResult
    {
        public OTPResult(string message, bool success)
        {
            Message = message;
            Success = success;
        }

        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
