using System.Collections.Generic;
using Int.Core.Factories.Adapter.V2;

namespace Core.Models.DAL.Documents
{
    public interface IItemDocument : IExpandableCellData<IDocument>
    {
        string Value { get; set; }
        string Label { get; set; }
        IList<IDocument> Documents { get; set; }
    }

    public interface IDocument
    {
        string Name { get; set; }
        SourceType FileType { get; set; }
    }

    public enum SourceType
    {
        Pdf,
        Image
    }
}