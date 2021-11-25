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
        /// Add new book to existing collection
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Book id</returns>
        long Add(Book book);

        /// <summary>
        /// Get All books from the repository
        /// </summary>
        /// <returns>Returns all books</returns>
        List<Book> GetAll();

        /// <summary>
        /// Get book using Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Book object</returns>
        Book GetById(long id);

        /// <summary>
        /// To check if book exists or not
        /// </summary>
        /// <param name="title"></param>
        /// <returns>true or False</returns>
        bool IsExists(string title);

        /// <summary>
        /// Update existing book details
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Book Update(Book book);

        /// <summary>
        /// Delete book from the existing collection
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        bool Delete(Book book);
    }
}
