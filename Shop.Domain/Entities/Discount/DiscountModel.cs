using Shop.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Discount
{
    public class DiscountModel : BaseEntity
    {
        public DiscountModel(string title, decimal discountPercent, long discountPrice, long minPrice, long maxPrice, DateTime expiredDate) 
        {
            Title = title;
            DiscountPercent = discountPercent;
            DiscountPrice = discountPrice;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            ExpiredDate = expiredDate;
        }

        public void Edit(DateTime expiredDate)
        {
            ExpiredDate = expiredDate;
        }

        public string Title { get; set; }
        public decimal DiscountPercent { get; set; }
        public long DiscountPrice { get; set; }
        public long MinPrice { get; set; }
        public long MaxPrice { get; set; }
        public DateTime ExpiredDate { get; set; }
        public List<OrderModel> Orders { get; set; }
    }
}
