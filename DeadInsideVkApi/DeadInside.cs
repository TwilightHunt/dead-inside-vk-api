﻿using DeadInsideVkApi.Analyser;
using DeadInsideVkApi.ConfigTypes;
using DeadInsideVkApi.Handlers;
using DeadInsideVkApi.System;
using Newtonsoft.Json;

namespace DeadInsideVkApi
{
    public class DeadInside
    {
        private AppConfig config;

        public DeadInside()
        {
            LoadConfig();
            Storage.Set("VK_HANDLER", new VkHandler(config!.Token));
            // Load Cache Method
            // Storage Set Cache Storage
        }

        private void LoadConfig()
        {
            if (File.Exists(Constants.CONFIG_NAME))
            {
                string raw = File.ReadAllText(Constants.CONFIG_NAME);
                config = JsonConvert.DeserializeObject<AppConfig>(raw)!;
                Storage.Set(Constants.SYSTEM_CONFIG, config);
            }
            else
            {
                config = new AppConfig();
                File.WriteAllText(Constants.CONFIG_NAME, JsonConvert.SerializeObject(config));
                Console.WriteLine($"'{Constants.CONFIG_NAME}' was created. Please enter the config.");

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