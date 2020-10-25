using Microsoft.AspNetCore.Mvc;
using shoponline.api.Models;
using shoponline.Core.Entities;
using shoponline.Infrastructure;
using System;
using System.Linq;


namespace shoponline.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ShopOnlineDbContext _shopOnlineDbContext;

        public BookController(ShopOnlineDbContext shopOnlineDbContext)
        {
            _shopOnlineDbContext = shopOnlineDbContext;
        }

        [HttpPost]
        public Book Post([FromBody] AddBook bookItem)
        {
            try
            {
                var theAuthor = _shopOnlineDbContext.Authors.Where(author => author.Id == bookItem.AuthorId).FirstOrDefault();
                if (theAuthor == null) return null;

                var newBook = new Book
                {
                    Name = bookItem.Name,
                    PublishDate = bookItem.PublishDate,
                    AvailableCopies = bookItem.AvailableCopies,
                    AuthorId = theAuthor.Id,
                    Author = theAuthor,
                };
                _shopOnlineDbContext.Books.Add(newBook);
                _shopOnlineDbContext.SaveChanges();
                return newBook;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("{bookId}/loan")]
        public ActionResult LoanBook(int bookId)
        {
            try
            {
                var theBook = _shopOnlineDbContext.Books.Where(book => book.Id == bookId).FirstOrDefault();
                if (theBook == null) return NotFound("Book not found");

                if(theBook.AvailableCopies < 3) return NotFound("No hay suficientes copias disponibles");

                theBook.AvailableCopies--;
                _shopOnlineDbContext.Books.Update(theBook);
                _shopOnlineDbContext.SaveChanges();

                return Ok(theBook);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("{bookId}/return")]
        public ActionResult ReturnBook(int bookId)
        {
            try
            {
                var theBook = _shopOnlineDbContext.Books.Where(book => book.Id == bookId).FirstOrDefault();
                if (theBook == null) return NotFound("Book not found");

                theBook.AvailableCopies++;
                _shopOnlineDbContext.Books.Update(theBook);
                _shopOnlineDbContext.SaveChanges();

                return Ok(theBook);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
