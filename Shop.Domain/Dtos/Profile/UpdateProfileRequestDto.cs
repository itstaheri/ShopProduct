using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Profile
{
    public record UpdateProfileRequestDto
    {
        public long ProfileId { get; set; }
        public string NationalCode { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
    }
}
