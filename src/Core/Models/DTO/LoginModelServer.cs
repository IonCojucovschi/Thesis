//
//  LoginModelServer.cs
//
//  Author:
//       Songurov <songurov@gmail.com>
//
//  Copyright (c) 2017 Songurov
//
//  This library is free software; you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as
//  published by the Free Software Foundation; either version 2.1 of the
//  License, or (at your option) any later version.
//
//  This library is distributed in the hope that it will be useful, but
//  WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

using Core.Models.DAL;
using Newtonsoft.Json;

namespace Core.Models.DTO
{
    public class LoginModelServer
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }

    public class LoginResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("exp")]
        public int Exp { get; set; }

        [JsonProperty("client")]
        public Client Client { get; set; }
    }

    public class Role
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    }

    public class ClientType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Client
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code_fiscal")]
        public string CodeFiscal { get; set; }

        [JsonProperty("birth_date")]
        public string BirthDate { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("address_number")]
        public string AddressNumber { get; set; }

        [JsonProperty("address_fraction")]
        public string AddressFraction { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("client_type")]
        public ClientType ClientType { get; set; }

        [JsonProperty("user")]
        public UserModel User { get; set; }
    }
}