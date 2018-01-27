using Core.Models.DAL.Contracts;

namespace Core.Models.DAL.Invoices
{
    public interface IItemInvoicesDetail
    {
        EnergySourceType InvoicesDetailType { get; set; }
        string InvoicesCodeValue { get; set; }
        string ReleaseDateValue { get; set; }
        string DateExpirationValue { get; set; }
        string AmountValue { get; set; }
        string OldReadingValue { get; set; }
        string NewReadingValue { get; set; }
        string ConsumptionValue { get; set; }
    }
}