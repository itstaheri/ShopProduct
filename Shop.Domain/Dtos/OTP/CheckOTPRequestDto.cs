﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.OTP
{
    public record CheckOTPRequestDto
    {
        public string Key { get; set; }
        public string Code { get; set; }
    }
}
