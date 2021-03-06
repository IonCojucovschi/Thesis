﻿using Newtonsoft.Json;

namespace Core.Models.DAL
{
    public class ProfileModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        //[JsonProperty("phone")]/////delete 
        //public string Phone { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("login")]
        public string Username { get; set; }

        //[JsonProperty("vat_number")]////delete
        //public string VatNumber { get; set; }

        //[JsonProperty("language")]///delete
        //public string Language { get; set; }

        [JsonProperty("cellphone")]
        public string Mobile { get; set; }

        //[JsonProperty("address")]///delete
        //public string Address { get; set; }

        //[JsonProperty("agent")]///delete
        //public string Agent { get; set; }
    }
}