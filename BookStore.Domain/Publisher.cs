using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain
{
    public class Publisher:BaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
