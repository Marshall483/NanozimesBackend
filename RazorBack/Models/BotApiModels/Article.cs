namespace RazorBack.Models.BotApiModels
{
    using Newtonsoft.Json;
    using System.Text.Json;

    [JsonObject]
    public class Article
    {
        [JsonProperty("link")]
        public string Link { get; set; }
    }
}
