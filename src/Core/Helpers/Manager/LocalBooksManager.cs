using System;
using Core.Services;
using Int.Core.Data.Repository.Akavache.Contract;
using Int.Core.Network.Singleton;
using Core.Models.DAL.LocalBooks;



namespace Core.Helpers.Manager
{
    public class LocalBooksManager:Singleton<LocalBooksManager>
    {
        private readonly IRepositoryWithId<LocalBook> _LocalBookRep =
            Service.Instance.ServiceRepository.UnitOfWork.GetFeedRepository<LocalBook>();


        public void AddLocalBook(LocalBook book)
        {
            _LocalBookRep.Add(book);
        }

        public void RemoveLocalBoock(LocalBook book)
        {
            _LocalBookRep.Remove(book);
        }
        public void ClearAllLocalBooks()
        {
            _LocalBookRep.RemoveAll();
        }
        public LocalBook GetBookById(int id)
        {
            return _LocalBookRep.GetById(id);
        }

    }
}
