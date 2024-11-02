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

        ReadProduct,
        WriteProduct,
        EditProduct,
        DeleteProduct,

        ReadInventory,
        WriteInventory,
        EditInventory,
        DeleteInventory,

        ReadCategory,
        WriteCategory,
        EditCategory,
        DeleteCategory,

        ReadPropery,
        WritePropery,
        EditPropery,
        DeletePropery,

        ReadUser,
        WriteUser,
        EditUser,
        DeleteUser,

       
    }
}
