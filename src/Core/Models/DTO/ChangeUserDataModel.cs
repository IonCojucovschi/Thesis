using Newtonsoft.Json;

namespace Core.Models.DTO
{
    public class ChangeUserDataModel
    {
        [JsonProperty("client_name")]
        public string Name { get; set; }

        [JsonProperty("client_surname")]
        public string Lastname { get; set; }

        [JsonProperty("client_email")]
        public string Email { get; set; }

        [JsonProperty("client_phone")]
        public string Phone { get; set; }

        [JsonProperty("client_cellphone")]
        public string Mobile { get; set; }

        [JsonProperty("client_address")]
        public string Address { get; set; }
    }
}