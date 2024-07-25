using BusinessLogic.Books;
using WebApp.DTOs;

namespace WebApp.Mappers
{
    public interface IBookMapper
    {
        public List<BookDTO> GetBooksDTOList(List<Book> books);
        public Book MapBookDTOToBook(BookDTO book);
        public Book MapUpdateBookDToBook(BookUpdateDTO book);
        public BookDTO MapBookToBookDTO(Book book);
        public BookReview MapBookReviewDTOToBookReview(BookReviewDTO bookReviewDTO);
        public List<ReviewReturnedDTO> ConvertBookReviewsToReviewsDTO(List<BookCompositeReview> bookReviews); 



    }
}
