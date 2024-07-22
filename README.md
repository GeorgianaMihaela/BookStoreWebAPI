# BookStoreWebAPI
BookStoreWebAPI

This is a BookStore project build on layered architecture: 

### WebAPIsNoDB (web layer) --> BusinessLogic (service layer) --> DataAccess (data access layer)

1. WebAPIsNoDB - web layer - contains the BookController, a mapper and DTOs: 
- BookDTO used to POST book data from the web layer (Controller) to the service layer
- BookReviewDTO to send review data from the web layer (Controller) to the service layer, when doing POST /books/isbn/review
- BookUpdateDTO used to update the book resource (PUT request for /api/books
- ReviewReturnedDTO used to receive the reviews from the service layer to the web app layer when getting all the reviews for a certain book with a particular ISBN. 

This layer also contains exception handler and a swagger. 
The first 3 DTOs have validation because they are used for input data into the system.
This layer is started from Web API project template. 

2. BusinessLogic - service layer - also has its own DTOs and mappers. Used to send the data from the web layer to the database layer. 
This layer is a class library referenced in the Web layer. 

3. DataAcess - layer - also class library, referenced only in BusinessLogic. 
It connects to SQL server and performs simple queries, with no ORM. So no EF yet. 

### Supported APIs 

Books

GET /api/Books

POST /api/Books

PUT /api/Books/{isbn}

GET /api/Books/{isbn}

DELETE /api/Books/{isbn}

POST /api/Books/{isbn}/review

GET /api/Books/{isbn}/reviews


