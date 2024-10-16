using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces.Cache
{
    public interface IDistributedCacheService
    {
        Task SetAsync(string key, string value);
        Task<string?> GetAsync(string key);
        void Set(string key, string value);
       string? Get(string key);
    }
}
