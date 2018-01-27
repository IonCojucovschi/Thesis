namespace Core.Models.DAL
{
    public class ItemComunication : IItemComunication
    {
        public string ComunicationText { get; set; }
        public string ComunicationDate { get; set; }
    }

    public interface IItemComunication
    {
        string ComunicationText { get; set; }
        string ComunicationDate { get; set; }
    }
}