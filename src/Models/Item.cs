namespace todo.Models
{
    using System.Text.Json.Serialization;

    public class Item
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("isComplete")]
        public bool Completed { get; set; }
    }
}
