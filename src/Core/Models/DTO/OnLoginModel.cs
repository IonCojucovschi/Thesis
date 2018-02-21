using System;
namespace Core.Models.DTO
{
    public class OnLoginModel
    {
        public Data data { get; set; }

    }


    public class Data
    {
        
        public string name { get; set; }
        public string surname { get; set; }
        public string Email { get; set; }
        public string cellphone { get; set; }
        public string login { get; set; }
        public string pasword { get; set; }
        public string active { get; set; }
    }
}
