using BusinessLogic.Books;
using DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mappers
{
    public interface IBookMapper
    {
        public SQLBook MapBookToSQLBook(Book book);
        public Book MapSqlBookToBook(SQLBook sqlBook);
        public List<Book> MapListSqlBookToListBook(List<SQLBook> sqlBooks); 
    }
}
