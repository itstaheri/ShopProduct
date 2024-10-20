using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.Entities.Property;

namespace Shop.Domain.Entities.Category
{
    public class CategoryPropertyModel : BaseEntity
    {
        
        public CategoryPropertyModel(int categoryId, int propertyId)
        {
            PropertyId = propertyId;
            CategoryId = categoryId;
        }

        public int CategoryId {  get; private set; }
        public int PropertyId { get; private set;}
        public CategoryModel Category { get; private set; }
        public PropertyModel Property { get; private set; }
    }
}
