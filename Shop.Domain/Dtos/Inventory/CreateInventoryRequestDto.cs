﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Inventory
{
    public record CreateInventoryRequestDto
    {
        public string Name { get; set; }
        public long CityId { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
    }
}
