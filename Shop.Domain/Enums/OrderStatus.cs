using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Enums
{
    public enum OrderStatus
    {
        Created = 1,
        AwaitingPayment = 2,
        Paid = 3,
        OrderProcessing = 4,
        Sending = 5,
        Delivered = 6,
    }
}
