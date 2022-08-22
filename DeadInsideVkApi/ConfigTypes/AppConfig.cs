using Newtonsoft.Json;

namespace DeadInsideVkApi.ConfigTypes
{
    public class AppConfig
    {
        [JsonProperty("token")] public string Token { get; set; } = string.Empty;
        [JsonProperty("forbidden_tags")] public List<string> Tags { get; set; } = new List<string>();
    }
}
