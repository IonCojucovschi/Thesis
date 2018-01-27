using System.Collections.Generic;
using Core.Models.DAL.BE;
using Newtonsoft.Json;

namespace Core.Models.DAL.BeContractsInProgress
{
    public class BeItemContract : EntityBaseBE
    {
        [JsonProperty("contract")]
        public Contract Contract { get; set; }

        [JsonProperty("appointment_info")]
        public AppointmentInfo AppointmentInfo { get; set; }

        [JsonProperty("agent_info")]
        public AgentInfo AgentInfo { get; set; }

        [JsonProperty("client_info")]
        public ClientInfo ClientInfo { get; set; }

        [JsonProperty("personal_schedule")]
        public PersonalSchedule PersonalSchedule { get; set; }
    }

    public class Contract
    {
        [JsonProperty("contract_id")]
        public int ContractId { get; set; }

        [JsonProperty("contract_appointment_id")]
        public int ContractAppointmentId { get; set; }

        [JsonProperty("contract_gen_status")]
        public int ContractGenStatus { get; set; }

        [JsonProperty("general_status_color")]
        public string GeneralStatusColor { get; set; }

        [JsonProperty("contract_nda_number")]
        public string ContractNdaNumber { get; set; }

        [JsonProperty("contract_agent_name")]
        public string ContractAgentName { get; set; }

        [JsonProperty("contract_zip")]
        public string ContractZip { get; set; }

        [JsonProperty("contract_province")]
        public string ContractProvince { get; set; }

        [JsonProperty("contract_city")]
        public string ContractCity { get; set; }

        [JsonProperty("contract_facility_address")]
        public string ContractFacilityAddress { get; set; }

        [JsonProperty("contract_acceptance_date")]
        public int ContractAcceptanceDate { get; set; }

        [JsonProperty("contract_signature_date")]
        public int ContractSignatureDate { get; set; }

        [JsonProperty("contract_create_on")]
        public int ContractCreateOn { get; set; }

        [JsonProperty("contract_note")]
        public string ContractNote { get; set; }

        [JsonProperty("contract_product_codes")]
        public string ContractProductCodes { get; set; }

        [JsonProperty("contract_moduls")]
        public ContractModuls ContractModuls { get; set; }
    }

    public class ContractModuls
    {
        [JsonProperty("ACCETTAZIONE")]
        public ACCETTAZIONE ACCETTAZIONE { get; set; }

        [JsonProperty("AMMINISTRAZIONE")]
        public AMMINISTRAZIONE AMMINISTRAZIONE { get; set; }

        [JsonProperty("TECNICO")]
        public TECNICO TECNICO { get; set; }
    }

    public class TECNICO
    {
        [JsonProperty("modul_name")]
        public string ModulName { get; set; }

        [JsonProperty("modul_status")]
        public int ModulStatus { get; set; }

        [JsonProperty("status_color")]
        public string StatusColor { get; set; }

        [JsonProperty("sub_moduls")]
        public IList<SubModul> SubModuls { get; set; }
    }

    public class AMMINISTRAZIONE
    {
        [JsonProperty("modul_name")]
        public string ModulName { get; set; }

        [JsonProperty("modul_status")]
        public int ModulStatus { get; set; }

        [JsonProperty("status_color")]
        public string StatusColor { get; set; }

        [JsonProperty("sub_moduls")]
        public IList<SubModul> SubModuls { get; set; }
    }

    public class ACCETTAZIONE
    {
        [JsonProperty("modul_name")]
        public string ModulName { get; set; }

        [JsonProperty("modul_status")]
        public int ModulStatus { get; set; }

        [JsonProperty("status_color")]
        public string StatusColor { get; set; }

        [JsonProperty("sub_moduls")]
        public IList<SubModul> SubModuls { get; set; }
    }

    public class SubModul
    {
        [JsonProperty("submodul_name")]
        public string SubmodulName { get; set; }

        [JsonProperty("submodul_status")]
        public int SubmodulStatus { get; set; }

        [JsonProperty("status_color")]
        public string StatusColor { get; set; }

        [JsonProperty("tasks")]
        public IList<Task> Tasks { get; set; }
    }

    public class Task
    {
        [JsonProperty("task_name")]
        public string TaskName { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("status_color")]
        public string StatusColor { get; set; }
    }


    public class AppointmentInfo
    {
        [JsonProperty("appointment_id")]
        public int AppointmentId { get; set; }

        [JsonProperty("appointment_date")]
        public int AppointmentDate { get; set; }

        [JsonProperty("appointment_general_state")]
        public int AppointmentGeneralState { get; set; }

        [JsonProperty("sales_agent_result")]
        public int SalesAgentResult { get; set; }

        [JsonProperty("operators_notes")]
        public OperatorsNotes OperatorsNotes { get; set; }
    }

    public class OperatorsNotes
    {
        [JsonProperty("NoteAppuntamento")]
        public string NoteAppuntamento { get; set; }

        [JsonProperty("NoteOperatoreCC")]
        public string NoteOperatoreCC { get; set; }

        [JsonProperty("NoteCo")]
        public string NoteCo { get; set; }

        [JsonProperty("NoteCq")]
        public string NoteCq { get; set; }

        [JsonProperty("NoteRc")]
        public string NoteRc { get; set; }

        [JsonProperty("NoteToAgent")]
        public string NoteToAgent { get; set; }

        [JsonProperty("NoteFromAgent")]
        public string NoteFromAgent { get; set; }
    }

    public class AgentInfo
    {
        [JsonProperty("agent_id")]
        public int AgentId { get; set; }

        [JsonProperty("agent_name")]
        public string AgentName { get; set; }

        [JsonProperty("agent_phone")]
        public string AgentPhone { get; set; }
    }

    public class ClientInfo
    {
        [JsonProperty("client_name")]
        public string ClientName { get; set; }

        [JsonProperty("client_surname")]
        public string ClientSurname { get; set; }

        [JsonProperty("client_email")]
        public string ClientEmail { get; set; }

        [JsonProperty("client_phone")]
        public string ClientPhone { get; set; }

        [JsonProperty("client_cellphone")]
        public string ClientCellphone { get; set; }

        [JsonProperty("client_city")]
        public string ClientCity { get; set; }

        [JsonProperty("client_province")]
        public string ClientProvince { get; set; }

        [JsonProperty("client_region")]
        public string ClientRegion { get; set; }

        [JsonProperty("client_zip")]
        public string ClientZip { get; set; }

        [JsonProperty("client_address")]
        public string ClientAddress { get; set; }

        [JsonProperty("client_notes")]
        public ClientNotes ClientNotes { get; set; }
    }

    public class ClientNotes
    {
        [JsonProperty("client_family_members")]
        public string ClientFamilyMembers { get; set; }

        [JsonProperty("client_age")]
        public string ClientAge { get; set; }

        [JsonProperty("client_profession")]
        public string ClientProfession { get; set; }

        [JsonProperty("client_house")]
        public string ClientHouse { get; set; }

        [JsonProperty("client_area_products")]
        public string ClientAreaProducts { get; set; }
    }

    public class PersonalSchedule
    {
    }

    public class Payment : TemplateBE
    {
    }
}