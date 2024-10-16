using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.CustomException.OTP
{
    public class ExpireAtNullException : Exception
    {
        public ExpireAtNullException() : base(CustomExeptionMessage.ExpireAtNullException)
        {
                
        }
    }
}
