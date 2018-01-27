using Newtonsoft.Json;

namespace Core.Models.DAL
{
    public class ProfileModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("vat_number")]
        public string VatNumber { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("cellphone")]
        public string Mobile { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("agent")]
        public string Agent { get; set; }
    }
}