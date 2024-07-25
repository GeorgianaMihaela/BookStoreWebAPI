using DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBStorage
{
   public interface ISQLBooksStorageService
    {
        public List<SQLBook> GetAllBooks();
        public SQLBook GetBookByISBN(string isbn);
        public void InsertBook(SQLBook sqlBook);
        public void UpdateBook(SQLBook bookToUpdate);
        public void DeleteBook(string isbn); 

    }
}
