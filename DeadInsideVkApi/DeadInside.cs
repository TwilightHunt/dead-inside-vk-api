using DeadInsideVkApi.ConfigTypes;
using Newtonsoft.Json;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace DeadInsideVkApi
{
    public class DeadInside
    {
        private AppConfig? config;
        private VkApi api;

        const string CONFIG_NAME = "config.json";

        public DeadInside()
        {
            LoadConfig();
            Auth();
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

        private void Auth()
        {
            api = new VkApi();

            api.Authorize(new ApiAuthParams
            {
                AccessToken = config.Token,
            });
        }

        private void GetUserInfo()
        {
            var ids = new long[] { 249764138, 522339419 };
           
            var users = api.Users.Get(ids);

            foreach(var u in users)
            {
                if (u.Domain != null)
                {
                    Console.WriteLine($"User domain is {u.Domain}");
                }
                else
                {
                    Console.WriteLine("User name not found");
                }
            }
        }

        private void GetGroups()
        {

        }

        public void Bootstrap()
        {
            GetUserInfo();
        }
    }
}