using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            IsActive = true;
        }

        protected void Active()=>IsActive = true;
        protected void DeActive()=> IsActive = false;

        public long Id { get;private set; }
        public DateTime CreatedAt { get;private set; }
        public DateTime UpdatedAt { get;private set; }
        public bool IsActive { get; private set; }
    }
}
