using DeadInsideVkApi.System;
using DeadInsideVkApi.UserInfo;
using Newtonsoft.Json;

namespace DeadInsideVkApi.ConfigTypes
{
    public class AppConfig
    {
        [JsonProperty("token")] public string Token { get; set; } = string.Empty;
        [JsonProperty("forbidden_tags")] public List<string> Tags { get; set; } = new List<string>();
        [JsonProperty("user_black_list")] public List<User> Users { get; set; } = new List<User>();

        public void UpdateUserBase(User user)
        {
            Users.Add(user);
            File.WriteAllText(Constants.CONFIG_NAME, JsonConvert.SerializeObject(this, Formatting.Indented));
        }

    }
}
