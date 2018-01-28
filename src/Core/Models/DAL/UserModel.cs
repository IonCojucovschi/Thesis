using Core.Models.Contract;
using Int.Core.Data.Repository.Akavache.Contract;

namespace Core.Models.DAL
{
    public class UserModel : IBaseEntity, IUserRepository
    {
        public string NewPassword { get; set; }

        public string Token { get; set; }

        public string TokenDevice { get; set; }

       // public string NameAgent => Profile.Agent;

        public string Name => Profile.Name;
        public string Surname => Profile.Surname;

       // public string Phone => Profile.Phone;
        public string Email => Profile.Email;
      //  public string VatNumber => Profile.VatNumber;
      //  public string Language => Profile.Language;
        //public string Address => Profile.Address;
        public string Mobile => Profile.Mobile;

        public string FullName => Profile.Name + " " + Profile.Surname;

        public ProfileModel Profile { get; set; } = new ProfileModel();
        public int Id { get; set; }

        public string Username
        {
            get => Profile.Username;
            set => Profile.Username = value;
        }

        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}