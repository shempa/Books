using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.Controllers
{
    public class Get_BooksController : Controller
    {
        // GET: Get_Books
        public ActionResult Get_Books()
        {
            Repository.Repository Get_Books = new Repository.Repository();
            var Model = Get_Books.Get_Books();
            return View(Model);
        }
        
        public ActionResult Delete(Models.Book book)
        {
            Repository.Repository Get_Books = new Repository.Repository();
            Get_Books.Book_Removal(book);
            return RedirectPermanent("~/Get_Books/Get_Books");
        }

        public ActionResult Edit_Book(Models.Book book)  //форма редактирования записи
        {
            return View(book);            
        }

        public ActionResult New_Book(Models.Book book)    // запись измененной книги
        {
            Repository.Repository Get_Books = new Repository.Repository();
            Get_Books.Edit_Book(book);
            return RedirectPermanent("~/Get_Books/Get_Books");
        }
    }
}