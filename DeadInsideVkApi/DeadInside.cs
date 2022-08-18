using DeadInsideVkApi.Analyser;
using DeadInsideVkApi.ConfigTypes;
using DeadInsideVkApi.System;
using DeadInsideVkApi.VK;
using Newtonsoft.Json;

namespace DeadInsideVkApi
{
    public class DeadInside
    {
        private AppConfig config;
        private VkHandler vkHandler;

        const string CONFIG_NAME = "config.json";

        public DeadInside()
        {
            LoadConfig();
            vkHandler = new VkHandler(config!.Token);
        }

        private void LoadConfig()
        {
            if (File.Exists(CONFIG_NAME))
            {
                string raw = File.ReadAllText(CONFIG_NAME);
                config = JsonConvert.DeserializeObject<AppConfig>(raw)!;
                Storage.Set(Constants.SYSTEM_CONFIG, config);
            }
            else
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
            var analyser = new AnalyserContext();
            analyser.Analyse();
        }
    }
}