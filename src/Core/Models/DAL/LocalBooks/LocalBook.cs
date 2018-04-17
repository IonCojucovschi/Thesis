using System;
using Int.Core.Data.Repository.Akavache.Contract;
using Java.IO;

namespace Core.Models.DAL.LocalBooks
{
    public class LocalBook : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LastPage { get; set; }
        public File FileContent { get; set; }
        public string PathFile { get; set; }
        public string SomeInfo { get; set; }
    }

    public interface ILocalBook
    {
        string Name { get; set; }
        int LastPage { get; set; }
        File FileContent { get; set; }
        string PathFile { get; set; }
        string SomeInfo { get; set; }
    }
}
