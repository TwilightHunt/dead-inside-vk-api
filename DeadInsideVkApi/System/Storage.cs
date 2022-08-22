namespace DeadInsideVkApi.System
{
    public static class Storage
    {
        private static Dictionary<string, object> _storage = new Dictionary<string, object>();

        public static T? Get<T>(string key)
        {
            if (_storage.TryGetValue(key, out var value)) return (T)value;
            return default;
        }

        public static T? Get<T>()
        {
            return (T?)_storage.Values.FirstOrDefault(v =>
                v.GetType().Equals(typeof(T))
            );
            //foreach(var value in _storage.Values)
            //{
            //    if(value.GetType() == typeof(T))
            //    {
            //        return (T?)value;
            //    }
            //}
            //return default;
        }

        public static void Set(string key, object value)
        {
            _storage[key] = value;
        }

        public static bool Exist(string key)
        {
            return _storage.ContainsKey(key);
        }
    }
}
