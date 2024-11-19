using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Profile
{
    public record GetUserCartFilterRequestDto : PaginationRequestDto
    {
        public long UserId { get; set; }
    }
}
