using Shop.Domain.Entities.Category;
using Shop.Domain.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Product
{
    public class ProductModel : BaseEntity
    {
        public ProductModel()
        {
                
        }
        public ProductModel(string name, long categoryId, string description, string exteraDescription, string mainPicture)
        {
            Name = name; 
            CategoryId = categoryId; 
            Description = description; 
            ExteraDescription = exteraDescription; 
            MainPicture = mainPicture;
        }

        public void Edit(string name, long categoryId, string description, string exteraDescription, string mainPicture)
        {
            Name = name;
            CategoryId = categoryId;
            Description = description;
            ExteraDescription = exteraDescription;
            MainPicture = mainPicture;
        }

        public string Name { get; private set; }
        public long CategoryId { get; private set;}
        public string Description { get; private set; }
        public string ExteraDescription { get; private set; }
        public string MainPicture { get; private set; }
        public CategoryModel Category { get; private set; }
        public List<ProductPropertyModel> ProductProperties { get; private set; }
        public List<ProductCommentModel> ProductComments { get; private set; }
        public List<ProductPictureModel> ProductPictures { get; private set; }
       public List<InventoryItemModel> InventoryItems { get; private set; }
    }
}
