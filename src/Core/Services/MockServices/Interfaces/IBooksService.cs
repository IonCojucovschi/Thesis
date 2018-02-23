using System;
using System.Collections.Generic;
using Core.Models.DAL.CategoryBooks;

namespace Core.Services.MockServices.Interfaces
{
    public interface IBooksService
    {
        void GetCategoryes(Action<IList<ICategoryContent>> success, Action<string> error);
    }
}