using Core.Models.Contract;
using Int.Core.Data.Repository.Akavache.Contract;
using Newtonsoft.Json;

namespace Core.Models.DAL
{
    public class UserModel : IBaseEntity, IUserRepository
    {
        public string NewPassword { get; set; }

        public string Token { get; set; }

        public string TokenDevice { get; set; }

       // public string NameAgent => Profile.Agent;
        [JsonProperty("name")]
        public string Name => Profile.Name;
        [JsonProperty("surname")]
        public string Surname => Profile.Surname;
       // public string Phone => Profile.Phone;
        [JsonProperty("Email")]
        public string Email => Profile.Email;
        //  public string VatNumber => Profile.VatNumber;
        //  public string Language => Profile.Language;
        //public string Address => Profile.Address;

        [JsonProperty("cellphone")]
        public string Mobile { get => Profile.Mobile; }

        public string FullName => Profile.Name + " " + Profile.Surname;

        public ProfileModel Profile { get; set; } = new ProfileModel();
        public int Id { get; set; }
        [JsonProperty("login")]
        public string Username
        {
            get => Profile.Username;
            set => Profile.Username = value;
        }
        [JsonProperty("pasword")]
        public string Password { get; set; }
        [JsonProperty("active")]
        public int active => Profile.active;
        public bool Remember { get; set; }
    }
}