using BusinessLogic.Books;
using WebApp.DTOs;

namespace WebAPIsNoDB.Mappers
{
    public class BookMapper
    {
        public List<BookDTO> GetBooksDTOList(List<Book> books)
        {

            List<BookDTO> booksDTO = new List<BookDTO>();
            foreach (var book in books)
            {
                var bookDTO = new BookDTO()
                {
                    ISBN = book.ISBN,
                    Title = book.Title,
                    Author = book.Author,
                    PublishedDate = book.PublishedDate, 
                    ReviewScore = book.ReviewScore
                };
                booksDTO.Add(bookDTO);
            }
            return booksDTO;
        }

        public Book MapBookDTOToBook(BookDTO book)
        {
            return new Book
            {
                ISBN = book.ISBN,
                Title = book.Title,
                Author = book.Author,
                PublishedDate = book.PublishedDate,
                ReviewScore = book.ReviewScore
            };
        }

        public Book MapUpdateBookDToBook(BookUpdateDTO book)
        {
            return new Book
            {
                Title = book.Title,
                Author = book.Author,
                PublishedDate = book.PublishedDate,
                ReviewScore = book.ReviewScore
            };
        }

        public BookDTO MapBookToBookDTO(Book book)
        {
            return new BookDTO
            {
                ISBN = book.ISBN,
                Title = book.Title,
                Author = book.Author,
                PublishedDate = book.PublishedDate,
                ReviewScore = book.ReviewScore
            };
        }

        public BookReview MapBookReviewDTOToBookReview(BookReviewDTO bookReviewDTO)
        {
            return new BookReview
            {
                ReviewScore = bookReviewDTO.ReviewScore,
                ReviewText = bookReviewDTO.ReviewText
            };
        }

        public List<ReviewReturnedDTO> ConvertBookReviewsToReviewsDTO(List<BookCompositeReview> bookReviews)
        {
            List<ReviewReturnedDTO> bookReviewsDTOs = new List<ReviewReturnedDTO>();

            foreach(BookCompositeReview br in bookReviews)
            {
                ReviewReturnedDTO brdto = new ReviewReturnedDTO
                {
                    ReviewScore = br.ReviewScore,
                    ReviewText = br.ReviewText, 
                    ISBN = br.ISBN, 
                    Title = br.Title
                }; 
                bookReviewsDTOs.Add(brdto);
            }
            return bookReviewsDTOs; 
        }
    }
}
