using System.Collections.Generic;

namespace Core.Models.DAL.Documents
{
    public class ItemDocument : IItemDocument
    {
        public bool Expanded { get; set; }
        public string Value { get; set; }
        public string Label { get; set; }
        public IList<IDocument> Documents { get; set; }
        public IList<IDocument> SubExpandItems => Documents;
    }

    public class Document : IDocument
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public SourceType FileType { get; set; }
    }
}