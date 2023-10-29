namespace RazorBack.Models.BotApiModels
{
    using Newtonsoft.Json;

    [JsonObject]
    public class QuestionRequstModel
    {
        [JsonProperty("article")]
        public Article Article { get; set; }

        [JsonProperty("query_text")]
        public string QueryText { get; set; }

        [JsonProperty("context")]
        public string Context { get; set; }
    }
}
