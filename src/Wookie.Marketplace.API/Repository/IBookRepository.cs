using System.Collections.Generic;
using Wookie.Marketplace.API.Models;

namespace Wookie.Marketplace.API.Repository
{
    /// <summary>
    /// List of methods for Book Repository
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Adds new books to existing collection
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Book id</returns>
        long Add(Book book);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns all books</returns>
        List<Book> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Book object</returns>
        Book GetById(long id);

        bool IsExists(string title);

        Book Update(Book book);

        bool Delete(Book book);
    }
}
