using Microsoft.Extensions.Caching.Distributed;
using Shop.Application.Interfaces.Cache;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Interfaces.Cache
{
    internal class RedisCache : IDistributedCacheService
    {
        private readonly IDatabase _redis;
        public RedisCache( IDatabase redis)
        {
            _redis = redis;
          

        }

        public bool Delete(string key)
        {
            try
            {
                return _redis.KeyDelete(key);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string? Get(string key)
        {
            try
            {
                return  _redis.StringGet(key);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string?> GetAsync(string key)
        {
            try
            {
                return await  _redis.StringGetAsync(key);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Set(string key, string value)
        {
            try
            {
                 _redis.StringSet(key, value);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task SetAsync(string key, string value)
        {
            try
            {
              await  _redis.StringSetAsync(key, value);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
