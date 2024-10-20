using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Property
{
    public record PropertyDto : PaginationResponsDto<PropertyDto>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public MeasurmentsUnit MeasurmentsUnit { get; set; }
        public bool IsActive { get; set; }
    }
}
