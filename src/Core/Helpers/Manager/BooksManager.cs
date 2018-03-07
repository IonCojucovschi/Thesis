using System;
using System.Collections.Generic;
using Core.Models.DAL.CategoryBooks;
using Core.Services.MockServices.Interfaces;
using Int.Core.Network.Singleton;
using Splat;
using System.Linq;

namespace Core.Helpers.Manager
{
    public class BooksManager : Singleton<BooksManager>
    {
        public  IList<ICategoryContent> _category_list;

        public ICategoryContent _curentCategory;

        private IList<IBooklist> _book_list;

        private static IBooksService GetCAtegoryServices =>
        Locator.Current.GetService<IBooksService>(App.Instance.IsMock
                                                  ? App.ServiceContractMock
                                                  : App.ServiceContract);




        public void GetCategoryes(Action<IList<ICategoryContent>> success, Action<string> error)
        {
            _category_list = new List<ICategoryContent>();
            GetCategoryList(
                categoryes=>
                {
                foreach(var item in categoryes)
                {
                    _category_list.Add(new CategoryContent(){category=item.category,quantity=item.quantity});
                }

                    success?.Invoke(_category_list);
                 },error);
        }


        #region services
        private void GetCategoryList(Action<IList<CategoryContent>> success, Action<string> error)
        {
            GetCAtegoryServices.GetCategoryes(success,error);
        }

       
        #endregion


        public ICategoryContent GetOneCategory(string categoryName)
        {
            _curentCategory=_category_list.ToList().Where(x => x.category == categoryName).FirstOrDefault();
            return _curentCategory;
        }



    }
}
