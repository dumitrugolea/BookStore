using System;
using System.Collections.Generic;

namespace BookStore.Domain
{
    public class Book:BaseEntity
    {
        public string Title { get; set; }
        public string ISBN { get; set; }

        public int PublisherId { get; set; }
        


    }
}
