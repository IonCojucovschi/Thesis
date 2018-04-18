using System;
using Core.Services;
using Int.Core.Data.Repository.Akavache.Contract;
using Int.Core.Network.Singleton;
using Core.Models.DAL.LocalBooks;
using System.Collections.Generic;
using Java.IO;
using System.Linq;

namespace Core.Helpers.Manager
{
    public class LocalBooksManager:Singleton<LocalBooksManager>
    {
        //private readonly IRepositoryWithId<LocalBook> _LocalBookRep =
             //Service.Instance.ServiceRepository.UnitOfWork.GetFeedRepository<LocalBook>();

        //public string parentDir = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath.ToString();//main root folder
        public List<LocalBook> inFiles = new List<LocalBook>();
        public LocalBook CurentBook;
        private int BookCounter=0;
        public List<LocalBook> GetAllBooksListFromDevidce(File parentDir, string PathToParentDir)
        {
            string[] fileNames = parentDir.List();
            foreach (string fileName in fileNames)
            {
                if (fileName.ToLower().EndsWith(".pdf"))
                {
                    inFiles.Add(new LocalBook
                    { Id=BookCounter,
                        Name = fileName,
                        FileContent = new File(parentDir.Path + "/" + fileName),
                        PathFile = parentDir.Path + "/" + fileName,
                    });
                    BookCounter++;
                    ///with dataBase
                    //AddLocalBook(new LocalBook
                    //{ 
                    //    Name = fileName,
                    //    FileContent = new File(parentDir.Path + "/" + fileName),
                    //    PathFile = parentDir.Path + "/" + fileName,
                    //});
                }
                else
                {
                    File file = new File(parentDir.Path + "/" + fileName);
                    if (file.IsDirectory)
                    {
                        inFiles.Union(GetAllBooksListFromDevidce(file, PathToParentDir + "/" + fileName));
                    }
                }
            }

            return inFiles;
        }
        public void GetCurentBook(int id)
        {
            CurentBook = inFiles.Where(bk=>bk.Id==id).FirstOrDefault();
        }




        //public void AddLocalBook(LocalBook book)
        //{
        //    _LocalBookRep.Add(book);
        //}

        //public void RemoveLocalBoock(LocalBook book)
        //{
        //    _LocalBookRep.Remove(book);
        //}
        //public void ClearAllLocalBooks()
        //{
        //    _LocalBookRep.RemoveAll();
        //}
        //public LocalBook GetBookById(int id)
        //{
        //    return _LocalBookRep.GetById(id);
        //}
        //public List<LocalBook> GetAllBookcsFromDB()
        //{
        //    return _LocalBookRep.GetAll().ToList();
        //}
    }
}
