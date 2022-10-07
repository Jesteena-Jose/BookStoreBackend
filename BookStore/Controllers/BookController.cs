using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BookStore.Models;

namespace BookStore.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class BookController : ApiController
    {
        private IBookRepository repository;
        public BookController()
        {
            repository = new BookSqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllBooks();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult GetById(int BookId)
        {
            var data = repository.GetBookById(BookId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult GetByCategory(int CategoryId)
        {
            var data = repository.GetBookByCat(CategoryId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult GetByAuthor(string Author)
        {
            var data = repository.GetBookByAuthor(Author);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult GetByISBN(string ISBN)
        {
            var data = repository.GetBookByISBN(ISBN);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult GetByName(string Title)
        {
            var data = repository.GetBookByName(Title);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Add(Book book)
        {
            var data = repository.AddBook(book);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int BookId)
        {
            repository.DeleteBook(BookId);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(int BookId,Book book)
        {
            repository.UpdateBook(BookId,book);
            return Ok();
        }
    }
}
