using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.User
{
    public class UserInfoDto
    {
        public long Id { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateAtShamsi { get; set; }
        public List<long> Roles { get; set; }
        public List<Enums.Permission> Permissions { get; set; }
    }
}
