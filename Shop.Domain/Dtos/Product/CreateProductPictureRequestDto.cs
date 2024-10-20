using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Product
{
    public record CreateProductPictureRequestDto
    {
        public long ProductId { get; set; }
        public long ProductCommentId { get; set; }
        public string FilePicture { get; set; }
    }
}
