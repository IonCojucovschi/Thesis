namespace Core.Models.DAL.Contacts
{
    public class ItemContact : IItemContact
    {
        public string Label { get; set; }
        public string Value { get; set; }
        public string ContactActivity { get; set; }
        public ContactType ContactType { get; set; }
    }
}