namespace Core.Models.DAL.Contacts
{
    public interface IItemContact
    {
        string Label { get; set; }
        string Value { get; set; }
        string ContactActivity { get; set; }
        ContactType ContactType { get; set; }
    }

    public enum ContactType
    {
        None,
        Phone,
        Email
    }
}