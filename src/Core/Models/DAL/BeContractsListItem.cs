using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.DAL
{
    public class ContractProduct
    {
        public int product_id { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public string product_description { get; set; }
        public int product_quantity { get; set; }
        public int product_price { get; set; }
        public int product_status { get; set; }
        public int product_create_on { get; set; }
        public int product_update_on { get; set; }
    }

    public class ContractDocument
    {
        public string document_path { get; set; }
        public string document_icon { get; set; }
        public string document_type { get; set; }
        public int document_appointment_id { get; set; }
        public int document_contract_id { get; set; }
        public int document_status { get; set; }
        public int document_create_on { get; set; }
    }

    public class Task
    {
        public string task_name { get; set; }
        public string alias { get; set; }
        public int status { get; set; }
        public string status_color { get; set; }
    }

    public class SubModul
    {
        public string submodul_name { get; set; }
        public int submodul_status { get; set; }
        public string status_color { get; set; }
        public IList<Task> tasks { get; set; }
    }

    public class ACCETTAZIONE
    {
        public string modul_name { get; set; }
        public int modul_status { get; set; }
        public string status_color { get; set; }
        public IList<SubModul> sub_moduls { get; set; }
    }

    public class AMMINISTRAZIONE
    {
        public string modul_name { get; set; }
        public int modul_status { get; set; }
        public string status_color { get; set; }
        public IList<SubModul> sub_moduls { get; set; }
    }

    public class TECNICO
    {
        public string modul_name { get; set; }
        public int modul_status { get; set; }
        public string status_color { get; set; }
        public IList<object> sub_moduls { get; set; }
    }

    public class SERVIZIOCLIENTI
    {
        public IList<SubModul> sub_moduls { get; set; }
    }

    public class ContractModuls
    {
        public ACCETTAZIONE ACCETTAZIONE { get; set; }
        public AMMINISTRAZIONE AMMINISTRAZIONE { get; set; }
        public TECNICO TECNICO { get; set; }
        public SERVIZIOCLIENTI SERVIZIO_CLIENTI { get; set; }
    }

    public class Contract
    {
        public int contract_id { get; set; }
        public int contract_appointment_id { get; set; }
        public int contract_gen_status { get; set; }
        public string general_status_color { get; set; }
        public string contract_nda_number { get; set; }
        public string contract_agent_name { get; set; }
        public string contract_zip { get; set; }
        public string contract_province { get; set; }
        public string contract_city { get; set; }
        public string contract_facility_address { get; set; }
        public int contract_acceptance_date { get; set; }
        public int contract_signature_date { get; set; }
        public int contract_create_on { get; set; }
        public string contract_note { get; set; }
        public IList<ContractProduct> contract_product { get; set; }
        public IList<ContractDocument> contract_document { get; set; }
        public ContractModuls contract_moduls { get; set; }
    }

    public class OperatorsNotes
    {
        public string NoteAppuntamento { get; set; }
        public string NoteOperatoreCC { get; set; }
        public string NoteCo { get; set; }
        public string NoteCq { get; set; }
        public string NoteRc { get; set; }
        public string NoteToAgent { get; set; }
        public string NoteFromAgent { get; set; }
    }

    public class AppointmentInfo
    {
        public int appointment_id { get; set; }
        public int appointment_date { get; set; }
        public int appointment_general_state { get; set; }
        public int sales_agent_result { get; set; }
        public OperatorsNotes operators_notes { get; set; }
    }

    public class AgentInfo
    {
        public int agent_id { get; set; }
        public string agent_name { get; set; }
        public string agent_phone { get; set; }
    }

    public class ClientNotes
    {
        public string client_family_members { get; set; }
        public string client_age { get; set; }
        public string client_profession { get; set; }
        public string client_house { get; set; }
        public string client_area_products { get; set; }
    }

    public class ClientInfo
    {
        public string client_name { get; set; }
        public string client_surname { get; set; }
        public string client_email { get; set; }
        public string client_phone { get; set; }
        public string client_cellphone { get; set; }
        public string client_city { get; set; }
        public string client_province { get; set; }
        public string client_region { get; set; }
        public string client_zip { get; set; }
        public string client_address { get; set; }
        public ClientNotes client_notes { get; set; }
    }

    public class PersonalSchedule
    {
    }

    public class Datum
    {
        public Contract contract { get; set; }
        public AppointmentInfo appointment_info { get; set; }
        public AgentInfo agent_info { get; set; }
        public ClientInfo client_info { get; set; }
        public PersonalSchedule personal_schedule { get; set; }
    }

    public class Example
    {
        public IList<Datum> data { get; set; }
    }
}
