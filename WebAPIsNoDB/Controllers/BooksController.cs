using BusinessLogic.Books;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebAPIsNoDB.Mappers;
using WebApp.DTOs;
using static System.Reflection.Metadata.BlobBuilder;


namespace WebAPIsNoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private BookService bookService = new BookService();
        private BookMapper bookMapper = new BookMapper();

        [HttpGet]
        public List<BookDTO> Get()
        {
            var books = bookService.GetBooks();

            var booksDTO = bookMapper.GetBooksDTOList(books);

            return booksDTO;
        }


        [HttpPost]
        [Consumes("application/json")]
        public BookDTO Post([FromBody] BookDTO book)
        {
            Book newBook = bookMapper.MapBookDTOToBook(book);

            Book insertedBook = bookService.InsertBook(newBook);

            var insertedBookDTO = bookMapper.MapBookToBookDTO(insertedBook);

            return insertedBookDTO;

        }

        [HttpPut]
        [Route("{isbn}")]
        [Consumes("application/json")]
        public BookDTO Put([FromRoute] string isbn, [FromBody] BookUpdateDTO book)
        {
            Book newBook = bookMapper.MapUpdateBookDToBook(book);

            Book updatedBook = bookService.UpdateBook(isbn, newBook);

            return bookMapper.MapBookToBookDTO(updatedBook);
        }

        [HttpGet]
        [Route("{isbn}")] // the name I place here in the Route must be exactly the method param
        public BookDTO Get([FromRoute] string isbn)
        {
            Book book = bookService.GetBookByISBN(isbn);

            BookDTO bookDTO = bookMapper.MapBookToBookDTO(book);

            return bookDTO;
        }

        [HttpDelete]
        [Route("{isbn}")]
        public BookDTO Delete([FromRoute] string isbn)
        {
            Book book = bookService.DeleteBook(isbn);

            // need to return the book which we just deleted
            BookDTO bookDTO = bookMapper.MapBookToBookDTO(book);

            return bookDTO;
        }


        [HttpPost]
        [Consumes("application/json")]
        [Route("review")]
        public void PostReview([FromBody] BookReviewDTO bookReviewDTO)
        {
            BookReview bookReview = bookMapper.MapBookReviewDTOToBookReview(bookReviewDTO);

            bookService.AddBookReview(bookReview);
        }


    }
}
