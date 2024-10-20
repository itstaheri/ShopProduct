using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.MessageResult
{
    public class CategoryMessageResult : BaseMessageResult
    {
        public const string CategoryNotFound = "CategoryNotFound";
        public const string CanNotDeleteCategory = "CanNotDeleteCategory";
    }
}
