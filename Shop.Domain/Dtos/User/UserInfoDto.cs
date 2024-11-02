using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.User
{
    public class UserInfoDto
    {
        public long UserId { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateAt { get; set; }
        public List<long> Roles { get; set; }
        public List<string> Permissions { get; set; }
    }
}
