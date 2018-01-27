using Core.Models.DAL.Contracts;

namespace Core.Models.DAL.Invoices
{
    internal class ItemInvoicesDetail : IItemInvoicesDetail
    {
        public EnergySourceType InvoicesDetailType { get; set; }
        public string InvoicesCodeValue { get; set; }
        public string ReleaseDateValue { get; set; }
        public string DateExpirationValue { get; set; }
        public string AmountValue { get; set; }
        public string OldReadingValue { get; set; }
        public string NewReadingValue { get; set; }
        public string ConsumptionValue { get; set; }
    }
}