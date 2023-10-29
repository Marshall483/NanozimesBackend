namespace RazorBack.Models.BotApiModels
{
    using Newtonsoft.Json;

    [JsonObject]
    public class AnswerModel
    {
        [JsonProperty("answer")]
        public string Answer { get; set; }

        [JsonProperty("context")]
        public string Context { get; set; }
    }
}
