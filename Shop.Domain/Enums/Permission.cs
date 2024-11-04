using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Enums
{
    public enum Permission
    {
        All = 1,

        ReadProduct = 2,
        WriteProduct = 3,
        EditProduct = 4,
        DeleteProduct = 5,

        ReadInventory = 6,
        WriteInventory = 7,
        EditInventory = 8,
        DeleteInventory = 9,

        ReadCategory = 10,
        WriteCategory = 11,
        EditCategory = 12,
        DeleteCategory = 13,

        ReadPropery = 14,
        WritePropery = 15,
        EditPropery = 16,
        DeletePropery = 17,

        ReadUser = 18,
        WriteUser = 19,
        EditUser = 20,
        DeleteUser = 21,
    }
}
