using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.Controllers
{
    public class Add_BookController : Controller
    {
        // GET: Add_Book
        public ActionResult Insert_Book()
        {
            return View();            
        }

        public ActionResult Add_Book(Models.Book book)
        {
            Repository.Repository Add_Book = new Repository.Repository();
            Add_Book.Add_Book(book);
            return RedirectPermanent("~/Get_Books/Get_Books");
        }
    }
}