using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library301
{
   public class Book
    {
        public int Id { get; set; }

        public string BookName { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public bool Rented { get; set; }

       



    }
}
