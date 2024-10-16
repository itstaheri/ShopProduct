using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.OTP
{
    public class SendOTPRequestDto 
    {
        public string Refrence { get; set; }
        public int Channel { get; set; }
    }
}
