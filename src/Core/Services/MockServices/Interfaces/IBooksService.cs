using System;
using System.Collections.Generic;
using Core.Models.DAL.CategoryBooks;

namespace Core.Services.MockServices.Interfaces
{
    public interface IBooksService
    {
        void GetCategoryes(Action<IList<CategoryContent>> success, Action<string> error);
        void GetBooksFromCategory(Action<IList<Booklist>> succes, Action<string> error);
        void GetWishedBooks(Action<IList<Booklist>> succes, Action<string> error);
        void GetAddedBooks(Action<IList<Booklist>> succes, Action<string> error);
    }
}
