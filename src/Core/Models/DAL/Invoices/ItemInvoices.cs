using Core.Models.DAL.Contracts;

namespace Core.Models.DAL.Invoices
{
    public class ItemInvoices : IItemInvoices
    {
        public EnergySourceType InvoicesType { get; set; }
        public string InvoicesCode { get; set; }
        public string InvoicesDate { get; set; }
        public string InvoicesAmoun { get; set; }
    }
}