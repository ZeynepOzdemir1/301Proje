using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library301
{
    public class Rent
    {
        public int Id { get; set;}

        public int UserId { get; set; }

        public int BookId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
    }
}
