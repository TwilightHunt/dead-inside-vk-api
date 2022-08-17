using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DeadInsideVkApi.ConfigTypes
{
    public class AppConfig
    {
        [JsonProperty("token")] public string Token { get; set; } = string.Empty;
        [JsonProperty("forbidden_domains")] public string Domains { get; set; } = string.Empty;
        
    }
}
