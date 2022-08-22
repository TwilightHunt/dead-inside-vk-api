namespace DeadInsideVkApi.System
{
    public class StorageCache
    {
        private Dictionary<string, object> _cache;
        public StorageCache()
        {
            _cache = new Dictionary<string, object>();
        }

        public StorageCache(Dictionary<string, object> cache)
        {
            _cache = cache;
        }

        public T? Get<T>(string key)
        {
            if (_cache.TryGetValue(key, out var value)) return (T)value;
            return default;
        }

        public T? Get<T>()
        {
            return (T?)_cache.Values.FirstOrDefault(v =>
                v.GetType().Equals(typeof(T))
            );
        }

        public void Set(string key, object value)
        {
            _cache[key] = value;
        }

        public bool Exists(string key) => _cache.ContainsKey(key);

        public bool SaveToJson()
        {
            throw new NotImplementedException();
        }

        public static StorageCache ReadFromJson()
        {
            throw new NotImplementedException();
        }
    }
}
