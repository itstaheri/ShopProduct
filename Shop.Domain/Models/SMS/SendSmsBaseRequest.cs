﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Models.SMS;
    public class SendSmsBaseRequest
    {
        public string Receptor { get; set; }
        public string Message { get; set; }
    }

