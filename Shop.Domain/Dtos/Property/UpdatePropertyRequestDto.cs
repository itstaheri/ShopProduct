﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Property
{
    public record UpdatePropertyRequestDto : CreatePropertyRequestDto
    {
        public long Id { get; set; }
    }
}