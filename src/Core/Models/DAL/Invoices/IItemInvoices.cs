using Core.Models.DAL.Contracts;

namespace Core.Models.DAL.Invoices
{
    public interface IItemInvoices
    {
        EnergySourceType InvoicesType { get; set; }
        string InvoicesCode { get; set; }
        string InvoicesDate { get; set; }
        string InvoicesAmoun { get; set; }
    }
}