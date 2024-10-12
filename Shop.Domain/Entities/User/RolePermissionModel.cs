using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.User
{
    public class RolePermissionModel : BaseEntity
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public RoleModel Role { get; set; }
        public PermissionModel Permission { get; set; }
    }
}
