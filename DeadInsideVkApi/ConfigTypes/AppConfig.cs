using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DeadInsideVkApi.ConfigTypes
{
    public class AppConfig
    {
        [JsonProperty("token")] public string Token { get; set; } = string.Empty;
        [JsonProperty("forbidden_tags")] public List<string> Tags { get; set; } = new List<string>();
        [JsonProperty("user_black_list")] public List<int> Users { get; set; } = new List<int>();

        public void UpdateUserBase(int uid)
        {
            Users.Add(uid);
        }

    }
}
