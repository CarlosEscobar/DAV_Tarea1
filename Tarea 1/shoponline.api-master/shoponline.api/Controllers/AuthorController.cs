using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shoponline.api.Models;
using shoponline.Core.Entities;
using shoponline.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace shoponline.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ShopOnlineDbContext _shopOnlineDbContext;

        public AuthorController(ShopOnlineDbContext shopOnlineDbContext)
        {
            _shopOnlineDbContext = shopOnlineDbContext;
        }

        [HttpPost]
        public Author Post([FromBody] AddAuthor authorItem)
        {
            try
            {
                var newAuthor = new Author
                {
                    Name = authorItem.Name,
                    Age = authorItem.Age
                };
                _shopOnlineDbContext.Authors.Add(newAuthor);
                _shopOnlineDbContext.SaveChanges();
                return newAuthor;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("{authorId}/books")]
        public ActionResult<IEnumerable<BookDto>> GetBooks(int authorId)
        {
            try
            {
                IEnumerable<Book> authorBooks = _shopOnlineDbContext.Books.Where(book => book.Id == authorId);
                return Ok(authorBooks.Select(book => new BookDto
                {
                    Id = book.Id,
                    Name = book.Name,
                    AuthorName = book.Author.Name,
                    PublishDate = book.PublishDate,
                    AvailableCopies = book.AvailableCopies
                }));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
