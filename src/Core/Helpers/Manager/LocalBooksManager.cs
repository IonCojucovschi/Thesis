//using System;
//using Core.Services;
//using Int.Core.Data.Repository.Akavache.Contract;
//using Int.Core.Network.Singleton;
//using Core.Models.DAL.LocalBooks;
//using System.Collections.Generic;
/////using Java.IO;
//using System.Linq;

//namespace Core.Helpers.Manager
//{
//    public class LocalBooksManager:Singleton<LocalBooksManager>
//    {
//        private IRepositoryWithId<LocalBook> _LocalBookRep =
//             Service.Instance.ServiceRepository.UnitOfWork.GetFeedRepository<LocalBook>();

//        public string parentDir = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath.ToString();//main root folder
//        public List<LocalBook> inFiles = new List<LocalBook>();
//        public LocalBook CurentBook;
//        private int BookCounter=0;
//        public List<LocalBook> GetAllBooksListFromDevidce(File parentDir, string PathToParentDir)
//        {
//            string[] fileNames = parentDir.List();
//            foreach (string fileName in fileNames)
//            {
//                if (fileName.ToLower().EndsWith(".pdf"))
//                {
//                   BookCounter++;
//                    ///with dataBase
//                    AddBook(new LocalBook
//                    { Id=BookCounter,
//                        Name = fileName,
//                        ///FileContent = new File(parentDir.Path + "/" + fileName),
//                        PathFile = parentDir.Path + "/" + fileName,
//                    });
//                }
//                else
//                {
//                    File file = new File(parentDir.Path + "/" + fileName);
//                    if (file.IsDirectory)
//                    {
//                        inFiles.Union(GetAllBooksListFromDevidce(file, PathToParentDir + "/" + fileName));
//                    }
//                }
//            }

//            return inFiles;
//        }
//        public void GetCurentBook(int id)
//        {
//            CurentBook = inFiles.Where(bk=>bk.Id==id).FirstOrDefault();
//        }

//        public void UpdateLocalBook(LocalBook book)
//        {
//            List<LocalBook> wevDb = new List<LocalBook>();
//            foreach(var itm in inFiles)
//            {
//                if(itm.Id==book.Id)
//                {
//                    wevDb.Add(book);
//                }else
//                {
//                    wevDb.Add(itm);
//                }
//            }
//            _LocalBookRep.RemoveAll();
//            _LocalBookRep.Add(wevDb);
//        }

//        public void AddBook(LocalBook bok)
//        {
//            _LocalBookRep.Add(bok);
//        }

//        public List<LocalBook> GetAllBookcsFromDB()
//        {
//            inFiles = _LocalBookRep.GetAll().ToList();
//            return inFiles;
//        }

//        public void RefreshBookDB()
//        {
//            _LocalBookRep.RemoveAll();
//            List<LocalBook> listbook=GetAllBooksListFromDevidce(new File(parentDir),parentDir);
//        }
       
//        public void RemoveLocalBoock(LocalBook book)
//        {
//            _LocalBookRep.Remove(book);
//        }
//        public void ClearAllLocalBooks()
//        {
//            _LocalBookRep.RemoveAll();
//        }
//        public LocalBook GetBookById(int id)
//        {
//            return _LocalBookRep.GetById(id);
//        }

//    }
//}
