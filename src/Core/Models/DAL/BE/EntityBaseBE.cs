using Newtonsoft.Json;

namespace Core.Models.DAL.BE
{
    public abstract class EntityBaseBE
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public abstract class TemplateBE : EntityBaseBE
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}