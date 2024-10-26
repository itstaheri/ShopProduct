using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Product
{
    public  class ProductPictureModel : BaseEntity
    {
        public ProductPictureModel()
        {
                
        }
        public ProductPictureModel(long productId, long? productCommentId, string filePicture)
        {
            ProductId = productId;
            ProductCommentId = productCommentId;
            FilePicture = filePicture;
        }

        public long ProductId { get; private set; }
        public long? ProductCommentId { get; private set; }
        public string FilePicture { get; private set;}
        public ProductModel Product { get; private set; }
        public List<ProductCommentModel> ProductComments { get; private set; }

    }
}
