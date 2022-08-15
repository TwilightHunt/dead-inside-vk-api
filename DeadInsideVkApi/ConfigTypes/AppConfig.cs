using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DeadInsideVkApi.ConfigTypes
{
    public class AppConfig
    {
       [JsonProperty("token")] public string Token { get; set; } = string.Empty;
        
    }
}
