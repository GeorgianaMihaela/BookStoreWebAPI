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
            List<Book> books = bookService.GetBooks();

            List<BookDTO> booksDTO = bookMapper.GetBooksDTOList(books);

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
        [Route("{isbn}/review")]
        public void PostReview([FromRoute] string isbn, [FromBody] BookReviewDTO bookReviewDTO)
        {
            BookReview bookReview = bookMapper.MapBookReviewDTOToBookReview(bookReviewDTO);
            bookService.AddBookReview(isbn, bookReview);
        }

        [HttpGet]
        [Route("{isbn}/reviews")]
        public List<ReviewReturnedDTO> GetReviews([FromRoute] string isbn)
        {
           List<BookCompositeReview> bookReviews = bookService.GetReviewsByISBN(isbn);

           List<ReviewReturnedDTO> bookReviewDTOs = bookMapper.ConvertBookReviewsToReviewsDTO(bookReviews); 

            return bookReviewDTOs;
        }

    }
}
