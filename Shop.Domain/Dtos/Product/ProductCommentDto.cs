using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Product
{
    public record ProductCommentDto : PaginationResponsDto<ProductCommentDto>
    {
        public long Id { get; set; }
        public long ProductCommentParentId { get; set; }
        public long ProductId { get; set; }
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public string Text { get; set; }
        public short Score { get; set; }
        public long ApprovingUserId { get; set; }
        public CommentStatus Status { get; set; }
        public bool IsQuestion { get; set; }
        public bool IsActive { get; set; }
    }
}
