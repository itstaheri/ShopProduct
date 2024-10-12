using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.User
{
    public class UserRoleModel : BaseEntity
    {
        public UserRoleModel(int roleId, long userId)
        {
            RoleId = roleId;
            UserId = userId;
        }

        public int RoleId { get;private set; }
        public long UserId { get;private set; }
        public RoleModel Role { get; private set; }
        public UserModel User { get; private set; }
    }
}
