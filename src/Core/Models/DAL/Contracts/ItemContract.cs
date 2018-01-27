using System;
using System.Collections.Generic;
using Core.Resources.Locales.Page;
using Core.Resources.Page;
using Int.Core.Extensions;

namespace Core.Models.DAL.Contracts
{
    public class ItemContract : IItemContract
    {
        public bool Expanded { get; set; }
        public string Value { get; set; }
        public string ActivationDate { get; set; }
        public string Address { get; set; }
        public string PDA { get; set; }
        public string Acceptance { get; set; }
        public string Tehnical { get; set; }
        public string Administration { get; set; }

        public IList<Tuple<string, string>> SubExpandItems => new List<Tuple<string, string>>
        {
            Tuple.Create(RDetailItems.ActivationDateLabelText,
                ActivationDate.IsNullOrWhiteSpace() ? RShare.NoValue?.ToUpperInvariant() : ActivationDate),
            Tuple.Create(RDetailItems.AddressLabelText,
                Address.IsNullOrWhiteSpace() ? RShare.NoValue?.ToUpperInvariant() : Address),
            Tuple.Create("PDA", PDA.IsNullOrWhiteSpace() ? "translated" : PDA),
            Tuple.Create("Acceptance", Acceptance.IsNullOrWhiteSpace() ? "translated" : Acceptance),
            Tuple.Create("Tehnical", Tehnical.IsNullOrWhiteSpace() ? "translated" : Tehnical),
            Tuple.Create("Administration", Administration.IsNullOrWhiteSpace() ? "translated" : Administration)
        };
    }
}