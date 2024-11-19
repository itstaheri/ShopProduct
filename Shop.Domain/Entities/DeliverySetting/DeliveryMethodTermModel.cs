using Shop.Domain.Entities.Inventory;
using Shop.Domain.Entities.Order;
using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.DeliverySetting
{
    public class DeliveryMethodTermModel : BaseEntity
    {
        public DeliveryMethodTermModel(long deliveryMethodId, Weekdays weekdays, TimeOnly fromTime, TimeOnly toTime, int sendingCapasity) 
        {
            DeliveryMethodId = deliveryMethodId;
            Weekdays = weekdays;
            FromTime = fromTime;
            ToTime = toTime;
            SendingCapasity = sendingCapasity;
        }

        public void Edit(Weekdays weekdays, TimeOnly fromTime, TimeOnly toTime, int sendingCapasity)
        {
            Weekdays = weekdays;
            FromTime = fromTime;
            ToTime = toTime;
            SendingCapasity = sendingCapasity;
        }

        public long DeliveryMethodId { get; set; }
        public DeliveryMethodModel DeliveryMethod { get; set; }
        public Weekdays Weekdays { get; set; }
        public TimeOnly FromTime { get; set; }
        public TimeOnly ToTime { get; set; }
        public int SendingCapasity { get; set; }
        public List<OrderModel> Orders { get; set; }
    }
}
