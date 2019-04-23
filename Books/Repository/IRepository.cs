using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.Repository
{
    interface IRepository
    {
        List<Models.Book> Get_Books();
        void Add_Book(Models.Book book);
        void Book_Removal(Models.Book book);
        void Edit_Book(Models.Book book);
    }
}