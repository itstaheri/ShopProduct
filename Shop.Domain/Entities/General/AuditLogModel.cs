using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.General
{
    public class AuditLogModel : BaseEntity
    {
       // public long Id { get; set; }
        public string TableName { get; set; }
        public string Operation { get; set; }
        public long UserId { get; set; }
        public long RecordId { get; set; }
       // public DateTime ActionDate { get; set; }
    }
}
