namespace GenericsExmpl
{
    internal class Storage
    {
        Dictionary<string, object> _storage;

        public Storage()
        {
            _storage = new Dictionary<string, object>();
        }

        public T? Get<T>(string key)
        {
            if (Exist(key)) return (T)_storage[key];
            return default;   
        }

        public void Set(string key, object value)
        {
            _storage[key] = value;
        }

        public bool Exist(string key)
        {
            return _storage.ContainsKey(key);
        }
    }
}
