using Shop.Domain.Entities.Inventory;
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
        public DeliveryMethodTermModel(Weekdays weekdays, TimeOnly fromTime, TimeOnly toTime, int sendingCapasity) 
        {
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

        public Weekdays Weekdays { get; set; }
        public TimeOnly FromTime { get; set; }
        public TimeOnly ToTime { get; set; }
        public int SendingCapasity { get; set; }
    }
}
