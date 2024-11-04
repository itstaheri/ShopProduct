using Shop.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Category
{
    public class CategoryModel : BaseEntity
    {
        public CategoryModel(string name, string? picture, long? categoryParentId)
        {
            Name = name;
            Picture = picture;
            CategoryParentId = categoryParentId;
        }

        public void Edit(string name, string? picture, long? categoryParentId)
        {
            Name = name;
            Picture = picture;
            CategoryParentId = categoryParentId;
        }

        public string Name { get; private set; }
        public string? Picture { get;private set; }
        public long? CategoryParentId { get; private set; }   
        public List<CategoryPropertyModel> CategoryProperties { get; private set; }
        public List<ProductModel> Products { get; private set; }

        public virtual CategoryModel CategoryParent { get; private set;}
        public virtual List<CategoryModel> SubCategories { get; private set; }
        
    }
}
