using Newtonsoft.Json;

namespace DeadInsideVkApi.System
{
    public class StorageCache
    {
        [JsonProperty("cache")] private Dictionary<string, object> _cache;
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

        public void SaveToJson()
        {
            var raw = JsonConvert.SerializeObject(_cache);
            File.WriteAllText("cache.json", raw);
        }

        public static StorageCache ReadFromJson()
        {
            if (File.Exists("cache.json"))
            {
                var raw = File.ReadAllText("cache.json");
                var cache = JsonConvert.DeserializeObject<Dictionary<string, object>>(raw);
                return new StorageCache(cache);
            }
            var cache2 = JsonConvert.SerializeObject(new Dictionary<string, object>());
            File.WriteAllText("cache.json", cache2);

            return new StorageCache();
        }
    }
}
