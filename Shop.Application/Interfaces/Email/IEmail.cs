using Shop.Domain.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces.Email
{
    public interface IEmail
    {
        public void Send(SendEmail email);
    }
}
