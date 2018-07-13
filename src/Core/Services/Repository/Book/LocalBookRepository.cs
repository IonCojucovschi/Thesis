using Core.Models.DAL.LocalBooks;
using Int.Core.Data.Repository.Akavache;

namespace Core.Services.Repository.Book
{
    public class LocalBookRepository:FeedRepository<LocalBook>
    {
        public LocalBookRepository() : base(TypeRepository.UserAccount)
        {
        }
    }
}
