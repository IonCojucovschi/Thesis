using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Models.DAL.CategoryBooks
{

    public class Data<T> where T:class 
    {  
        ///[JsonProperty(PropertyName =nameof(T))]
        public List<T> data { get ; set ; }
    }



    /// there is model for category content returned by  api/allcategory
    public interface ICategoryContent
    {
         string category { get; set; }
         string quantity { get; set; }
    }
   
    public class CategoryContent : ICategoryContent
    {
        public string category { get  ; set  ; }
        public string quantity {   get; set  ; }
    }

    /// there is model returned by api/books/category/_name_category_
    public interface IBooklist
    {
         string id { get; set; }
         string title { get; set; }
         string author { get; set; }
         string category { get; set; }
         string date { get; set; }
         string publication_date { get; set; }
         string description { get; set; }
         string rating { get; set; }
         string user_id { get; set; }
         string downloands_number { get; set; }
         string download_linq { get; set; }
         string image_linq { get; set; }
    }
    public class Booklist:IBooklist
    {
        public string id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string category { get; set; }
        public string date { get; set; }
        public string publication_date { get; set; }
        public string description { get; set; }
        public string rating { get; set; }
        public string user_id { get; set; }
        public string downloands_number { get; set; }
        public string download_linq { get; set; }
        public string image_linq { get; set; }
    }

    //// return book by id with api/books/id/_id_number_
    ///why i comment this ,,, because this api return same data but first or default and i can 
   /* public class Book
    {
        public string id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string category { get; set; }
        public string date { get; set; }
        public string publication_date { get; set; }
        public string description { get; set; }
        public string rating { get; set; }
        public string user_id { get; set; }
        public string downloands_number { get; set; }
        public string download_linq { get; set; }
        public string image_linq { get; set; }
    }*/






}
