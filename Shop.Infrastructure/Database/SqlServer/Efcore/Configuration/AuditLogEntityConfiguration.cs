using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    public class AuditLogEntityConfiguration : IEntityTypeConfiguration<AuditLogModel>
    {
        public void Configure(EntityTypeBuilder<AuditLogModel> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}
