# BookStoreWebAPI
BookStoreWebAPI

This is a BookStore project build on layered architecture: 
1. WebAPIsNoDB - web layer - contains the BookController, a mapper and 3 DTOs: 
- BookDTO used to POST book data from the web layer (Controller) to the service layer
- BookReviewDTO to send review data from the web layer (Controller) to the service layer, when doing POST /books/isbn/review
- BookUpdateDTO used to update the book resource (PUT request for /api/books
- ReviewReturnedDTO used to receive the reviews from the service layer to the web app layer when getting all the reviews for a certain book with a particular ISBN. 

This layer also contains exception handler and a swagger. 

2. Business Logic - service layer - also has its own DTOs and mappers. Used to send the data from the web layer 

