using System.Collections.Generic;
using Int.Core.Factories.Adapter.V2;

namespace Core.Models.DAL
{
    public class ItemProducts : IItemProducts
    {
        public bool Expanded { get; set; }
        public string LabelProduct { get; set; }
        public string ValueProduct { get; set; }

        public IList<IProduct> Products { get; set; }
        public IList<IProduct> SubExpandItems => Products;
    }

    public interface IItemProducts : IExpandableCellData<IProduct>
    {
        string LabelProduct { get; set; }
        string ValueProduct { get; set; }

        IList<IProduct> Products { get; set; }
    }

    public class Product : IProduct
    {
        public string LabelDescription { get; set; }
        public string ValueDescription { get; set; }
        public string StatusColor { get; set; }

        public int FileStatus { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }

    public interface IProduct
    {
        string LabelDescription { get; set; }
        string ValueDescription { get; set; }
        string StatusColor { get; set; }

        int FileStatus { get; set; }
        string FileName { get; set; }
        string FilePath { get; set; }
    }

}