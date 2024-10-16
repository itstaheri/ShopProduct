using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Models.OTP
{
    public class OTPInfo
    {
        public string Refrence { get; set; }
        public string Code { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public OTPAction OTPAction { get; set; }

    }
}
