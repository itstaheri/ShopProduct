using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.User
{
    public class RoleModel : BaseEntity
    {
        public RoleModel(string name)
        {
            Name = name;
        }

        public string  Name { get;private set; }
        public List<UserRoleModel> UserRoles { get; private set; }
        public List<RolePermissionModel> RolePermissions { get; private set; }

    }
}
