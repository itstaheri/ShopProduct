using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shop.Application.Interfaces.Auth;
using Shop.Domain.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Database.SqlServer.Efcore
{

  
    public class AuditInterceptor : SaveChangesInterceptor
    {
        private readonly IJwtAuthentication _auth;

        public AuditInterceptor(IJwtAuthentication auth)
        {
            _auth = auth;
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            long userId = _auth.GetCurrentUserId();
            var context = eventData.Context as ShopDbContext;
            int affectedRows = base.SavingChanges(eventData, result).Result;

            foreach (var entry in context.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.State == EntityState.Deleted)
                {

                    int recordId = 0;

                    if (entry.State == EntityState.Added)
                    {
                        recordId = (int)entry.Property("Id").CurrentValue;
                    }
                    else if (entry.State == EntityState.Modified || entry.State == EntityState.Deleted)
                    {
                        recordId = (int)entry.Property("Id").CurrentValue;
                    }
                    var log = new AuditLogModel
                    {
                        TableName = entry.Metadata.Name,
                        Operation = entry.State.ToString(),
                        UserId = userId,
                        ActionDate = DateTime.Now,
                        RecordId = recordId
                    };

                  await context.AuditLogs.AddAsync(log);
                }
            }

            return base.SavingChanges(eventData, result);
        }
    }
}
