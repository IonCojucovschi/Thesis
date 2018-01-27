using System;
using Int.Core.Factories.Adapter.V2;

namespace Core.Models.DAL.Contracts
{
    public interface IItemContract : IExpandableCellData<Tuple<string, string>>
    {
        string Value { get; set; }
        string ActivationDate { get; set; }
        string Address { get; set; }
        string PDA { get; set; }
        string Acceptance { get; set; }
        string Tehnical { get; set; }
        string Administration { get; set; }
    }
}