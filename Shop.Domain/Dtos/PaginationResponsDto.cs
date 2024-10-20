using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos
{
    public record PaginationResponsDto<T>
    {
        public List<T> Result { get; set; }
        public long TotalCount { get; set; }
    }
}
