namespace DeadInsideVkApi.System
{
    public static class Storage
    {
        private static Dictionary<string, object> _storage = new Dictionary<string, object>();

        public static T? Get<T>(string key)
        {
            if (Exist(key)) return (T)_storage[key];
            return default;
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
