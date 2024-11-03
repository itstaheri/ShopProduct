using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos
{
    public record PaginationRequestDto
    {
        public string  FromDate { get; set; }
        public string ToDate { get; set; } = string.Empty;
        public int Page {  get; set; }
        public int PageSize { get; set; }

    }
}
