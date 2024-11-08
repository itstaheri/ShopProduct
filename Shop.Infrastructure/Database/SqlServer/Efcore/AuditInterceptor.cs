using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shop.Application.Interfaces.Auth;
using Shop.Domain.Entities;
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
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {

            long userId = _auth.GetCurrentUserId();

            var context = eventData.Context as ShopDbContext;

            var entry = context.ChangeTracker.Entries().FirstOrDefault();


            try
            {
                InterceptionResult<int> res = new InterceptionResult<int>();

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.State == EntityState.Deleted)
                {


                    //  long recordId = (long)entry.Property("Id").CurrentValue;
                    long recordId = (long)(entry.Entity as BaseEntity).Id;

                    var log = new AuditLogModel
                    {
                        TableName = entry.Metadata.Name,
                        Operation = entry.State.ToString(),
                        UserId = userId,
                        RecordId = recordId
                    };

                    context.AuditLogs.Add(log);

                }
                res = base.SavingChanges(eventData, result);


                return res;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            long userId = _auth.GetCurrentUserId();

            var context = eventData.Context as ShopDbContext;

            var entry = context.ChangeTracker.Entries().FirstOrDefault();


            try
            {
                InterceptionResult<int> res = new InterceptionResult<int>();

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.State == EntityState.Deleted)
                {


                    long recordId = (long)(entry.Entity as BaseEntity).Id;

                    var log = new AuditLogModel
                    {
                        TableName = entry.Metadata.Name,
                        Operation = entry.State.ToString(),
                        UserId = userId,
                        RecordId = recordId
                    };

                   await context.AuditLogs.AddAsync(log);

                }
                res = base.SavingChanges(eventData, result);


                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
