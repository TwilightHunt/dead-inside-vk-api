using DeadInsideVkApi.ConfigTypes;
using Newtonsoft.Json;

namespace DeadInsideVkApi
{
    public class DeadInside
    {
        private AppConfig? config;
        const string CONFIG_NAME = "config.json";

        public DeadInside()
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            if (File.Exists(CONFIG_NAME))
            {
                string raw = File.ReadAllText(CONFIG_NAME);
                config = JsonConvert.DeserializeObject<AppConfig>(raw);
            } else
            {
                config = new AppConfig();
                File.WriteAllText(CONFIG_NAME, JsonConvert.SerializeObject(config));
                Console.WriteLine($"'{CONFIG_NAME}' was created. Please enter the config.");

                Console.ReadKey();
                Environment.Exit(0);
            }
            
        }

        public void Bootstrap()
        {
            Console.WriteLine($"Token: {config?.Token}");
        }
    }
}