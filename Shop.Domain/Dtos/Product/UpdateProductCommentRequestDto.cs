using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Product
{
    public record UpdateProductCommentRequestDto
    {
        public long ProductCommentId { get; set; }
        public long ApprovingUserId { get; set; }
        public CommentStatus Status { get; set; }
        public bool IsActive { get; set; }
    }
}
