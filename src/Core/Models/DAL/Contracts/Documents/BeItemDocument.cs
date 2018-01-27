//
//  BeItemDocument.cs
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

using Core.Models.DAL.BE;
using Newtonsoft.Json;

namespace Core.Models.DAL.Contracts.Documents
{
    public class BeItemDocument : EntityBaseBE
    {
        [JsonProperty("document_path")]
        public string DocumentPath { get; set; }

        [JsonProperty("document_icon")]
        public string DocumentIcon { get; set; }

        [JsonProperty("document_type")]
        public int DocumentType { get; set; }

        [JsonProperty("document_appointment_id")]
        public int DocumentAppointmentId { get; set; }

        [JsonProperty("document_contract_id")]
        public int DocumentContractId { get; set; }

        [JsonProperty("document_status")]
        public int DocumentStatus { get; set; }

        [JsonProperty("document_create_on")]
        public int DocumentCreateOn { get; set; }
    }
}