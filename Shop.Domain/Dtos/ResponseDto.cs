using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos
{
    public record ResponseDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
