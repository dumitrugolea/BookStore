using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Domain;
using FakeItEasy.Sdk;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.Controllers
{
     
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        /// <summary>
        /// Am adaugat sa vad ce ese (nu stiu cum sa fac sa porneasca cu controler-ul Books?)
        /// </summary>
        /// 
        //private readonly ILogger<BooksController> _logger;
        //private readonly BookStoreDbContext _dbcontext;
        //public BooksController(BookStoreDbContext dbcontext, ILogger<BooksController> logger)
        //{
        //    _dbcontext = dbcontext;
        //    _logger = logger;

        //}



        private readonly BookStoreDbContext _dbcontext;
        public BooksController(BookStoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;

        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            IEnumerable<Book> books = _dbcontext.Books.ToList();
            return books;

            //return Enumerable.Range(1, 1).Select(index => new Book()
            //{
            //    Title = "C#",
            //    ISBN = "ABC-200"
            //}).ToList();
        }

        [HttpPost]
        [Route("add")]
        public async Task<int> Add()
        {
            _dbcontext.Publishers.AddRange(
                new Publisher 
                { 
                    Country="England",
                    Date=DateTime.Now,
                    Name="IT",
                    Books=new List<Book>
                    {
                        new Book { Title = "Authentication", ISBN = "XDF-320" },
                        new Book { Title = "WEB API", ISBN = "CVB-250" }
                    }
                 
                }
                );

         

            //_dbcontext.Books.Add(new Book
            //{
            //    Title = "Entity Framework",
            //    ISBN = "ABC-1002"

            //});

            int numberOfRows = await _dbcontext.SaveChangesAsync();
            return numberOfRows;
        }

        [HttpPut]
        [Route("edit/{id}")]
        public async void Edit(int id)
        {

            Book book = _dbcontext.Books.Find(id);  /// asta folosim in cazul aplicatiilor desktop
            book.Title = "Titlu Editat";               /// adica change traker-ul acolo ne va ajuta
            await _dbcontext.SaveChangesAsync();

            //Book book = _dbcontext.Books.Find(id);
            //using (var dbContext = new BookStoreDbContext())
            //{
            //    book.Title = "Entity Framework 1";
            //    dbContext.Books.Update(book);
            //    _dbcontext.SaveChanges();
            //}
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async void Delete(int id)
        {
            Book book = _dbcontext.Books.Find(id);
            _dbcontext.Books.Remove(book);
            await _dbcontext.SaveChangesAsync();
        }


    }

}



