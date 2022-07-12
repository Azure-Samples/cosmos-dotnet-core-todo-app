namespace todo.Models
{
    using Newtonsoft.Json;

    public class Item
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        
        [JsonProperty(PropertyName = "messageId")]
        public string messageId { get; set; }
        
        [JsonProperty(PropertyName = "deviceId")]
        public string deviceId { get; set; }

        [JsonProperty(PropertyName = "humidity")]
        public string humidity { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "isComplete")]
        public bool Completed { get; set; }
    }
}
