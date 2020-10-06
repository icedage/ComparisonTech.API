using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace ComparisonTech.Persistence.Storage
{
    public interface IFakeDbContext<T>
    {
        void Insert(string key, Func<List<T>> createItem);
        IEnumerable<T> Get(string key);
    }

    public class FakeDbContext<T> : IFakeDbContext<T>
    {
        private static ConcurrentDictionary<string, List<T>> _cache;

        public FakeDbContext()
        {
            if (_cache is null)
                _cache = new ConcurrentDictionary<string, List<T>>();
        }

        public void Insert(string key, Func<List<T>> createItem)
        {
            var item = createItem();
            if (!_cache.ContainsKey(key))
                _ = _cache.TryAdd(key, createItem());
            else
            {
                var values = _cache.FirstOrDefault(x => x.Key == key).Value;
                values.AddRange(createItem());
                _cache[key] = values;
            }
        }

        public IEnumerable<T> Get(string key)
        {
            var items = _cache?.FirstOrDefault(x => x.Key == key).Value;
            return items;
        }
    }
}
