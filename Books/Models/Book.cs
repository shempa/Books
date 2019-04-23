﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.Models
{
    public class Book 
    {
        public int Id { get; set; }
       public string Title { get; set; }
       public string Author { get; set; }
       public string Genre { get; set; }
       public string Language { get; set; }
    }
}