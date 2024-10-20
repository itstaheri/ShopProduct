using Shop.Domain.Entities.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Product
{
    public class ProductPropertyModel : BaseEntity
    {
        public ProductPropertyModel(long productId, int propertyId, string value) 
        {
            ProductId = productId;
            PropertyId = propertyId;
            Value = value;
        }

        public void Edit(string value)
        {
            Value = value;
        }

        public long ProductId { get; private set; }
        public int PropertyId { get; private set;}
        public string Value { get; private set; }
        public ProductModel Product { get; private set; }
        public PropertyModel Property { get; private set; }
    }
}
