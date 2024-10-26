using Shop.Domain.Entities.User;
using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Product
{
    public class ProductCommentModel : BaseEntity
    {

        public ProductCommentModel()
        {
                
        }
        public ProductCommentModel(long? productCommentParentId, long productId, long userId, string? userFullName,string? userPhoneNumber, string? userEmail, string text, short score,
            long? approvingUserId, CommentStatus status, bool isQuestion)
        {
            ProductCommentParentId = productCommentParentId;
            ProductId = productId;
            UserId = userId;
            UserFullName = userFullName;
            UserPhoneNumber = userPhoneNumber;
            UserEmail = userEmail;
            Text = text;
            Score = score;
            ApprovingUserId = approvingUserId;
            Status = status;
            IsQuestion = isQuestion;
        }

        public long? ProductCommentParentId { get; private set; }
        public long ProductId { get; private set; }
        public long? UserId { get; private set; }
        public string? UserFullName { get; private set; }
        public string? UserPhoneNumber { get; private set; }
        public string? UserEmail { get; private set; }
        public string Text { get; private set; }
        public short Score { get; private set; }
        public long? ApprovingUserId { get; private set; }
        public CommentStatus Status { get; private set;}
        public bool IsQuestion { get; private set;}
        public ProductModel Product { get; private set;}
        public List<UserModel> Users { get; private set;}
        public List<UserModel> ApprovingUsers { get; private set;}

    }
}
