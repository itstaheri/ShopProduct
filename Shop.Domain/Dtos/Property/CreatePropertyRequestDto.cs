using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Property
{
    public record CreatePropertyRequestDto
    {
        public string Name { get; set; }
        public MeasurmentsUnit MeasurmentsUnit { get; set; }
        public bool IsActive { get; set; }
    }
}
