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

        public  ICategoryContent _curentCategory;

        public   IBooklist _curentBook;

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
        public void GetBooks(Action<IList<IBooklist>> success, Action<string> error)
        {
            _book_list = new List<IBooklist>();
            GetCategoryBookList(books=> {
                foreach (var item in books)
                {
                    _book_list.Add(new 
                        Booklist()
                    {
                        id=item.id,
                        title=item.title,
                        author=item.author,
                        category=item.category,
                        date=item.date,
                        description=item.description,
                        download_linq=item.download_linq,
                        downloands_number=item.downloands_number,
                        image_linq=item.image_linq,
                        rating=item.rating,
                        user_id=item.user_id,
                        publication_date=item.publication_date
                    });
                }
                success?.Invoke(_book_list);
            },error);
        }
        public void GetWishedBooksForUser(Action<IList<IBooklist>> success, Action<string> error)
        { 
            _book_list = new List<IBooklist>();
            GetWishedBooks(books => {
                foreach (var item in books)
                {
                    _book_list.Add(new
                        Booklist()
                    {
                        id = item.id,
                        title = item.title,
                        author = item.author,
                        category = item.category,
                        date = item.date,
                        description = item.description,
                        download_linq = item.download_linq,
                        downloands_number = item.downloands_number,
                        image_linq = item.image_linq,
                        rating = item.rating,
                        user_id = item.user_id,
                        publication_date = item.publication_date
                    });
                }
                success?.Invoke(_book_list);
            }, error);
        }

        #region services
        private void GetCategoryList(Action<IList<CategoryContent>> success, Action<string> error)
        {
            GetCAtegoryServices.GetCategoryes(success,error);
        }

        private void GetCategoryBookList(Action<IList<Booklist>> success, Action<string> error)
        {
            GetCAtegoryServices.GetBooksFromCategory(success, error);
        }

        private void GetWishedBooks(Action<IList<Booklist>> succes, Action<string> error)
        {
            GetCAtegoryServices.GetWishedBooks(succes,error);
        }

        #endregion


        public ICategoryContent GetOneCategory(string categoryName)
        {
            _curentCategory=_category_list.ToList().Where(x => x.category == categoryName).FirstOrDefault();
            return _curentCategory;
        }

        public IBooklist GetOneBook(int BookID)
        {
            _curentBook = _book_list.ToList().Where(x => x.id == BookID).FirstOrDefault();
            return _curentBook;
        }

    }
}
