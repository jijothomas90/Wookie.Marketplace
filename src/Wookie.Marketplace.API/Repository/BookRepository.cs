using System;
using System.Collections.Generic;
using System.IO;
using Wookie.Marketplace.API.Models;

namespace Wookie.Marketplace.API.Repository
{
    /// <summary>
    /// List of methods for Book Repository
    /// </summary>
    public class BookRepository : IBookRepository
    {
        //Getting image path
        private static string ImageRootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image");

        private static readonly List<Book> books = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                Title = "The Alchemist",
                Description = "The Alchemist is a novel by Brazilian author Paulo Coelho that was first published in 1988.",
                Author = "Paulo Coelho",
                CoverImage = File.ReadAllBytes(Path.Combine(ImageRootPath,"TheAlchemistCoverPage.jpg")),
                Price = 800.00m
            },
            new Book()
            {
                 Id = 2,
                Title = "Harry Potter",
                Description = "Harry Potter is a series of seven fantasy novels written by British author J. K. Rowling.",
                Author = "J. K. Rowling",
                Price = 1000.00m
            }
        };

        /// <summary>
        /// Get All books from the repository
        /// </summary>
        /// <returns>Returns all books</returns>
        public List<Book> GetAll()
        {
            return books;
        }

        /// <summary>
        /// Get book using Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Book object</returns>
        public Book GetById(long id)
        {
            return books.Find(e => e.Id.Equals(id));
        }

        /// <summary>
        /// Add new book to existing collection
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Book id</returns>
        public long Add(Book book)
        {
            book.Id = new Random().Next(1, 1000000);
            books.Add(book);
            return book.Id;
        }

        /// <summary>
        /// Delete book from the existing collection
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool Delete(Book book)
        {
            return books.Remove(book);
        }

        /// <summary>
        /// To check if book exists or not
        /// </summary>
        /// <param name="title"></param>
        /// <returns>true or False</returns>
        public bool IsExists(string title)
        {
            return books.Exists(e => e.Title.Equals(title,StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Update existing book details
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public Book Update(Book book)
        {
            var modifyBook = books.Find(e => e.Id.Equals(book.Id));
            if (modifyBook != null)
            {
                modifyBook.Title = book.Title;
                modifyBook.Description = book.Description;
                modifyBook.Author = book.Author;
                modifyBook.Price = book.Price;
            }
            return modifyBook;
        }
    }
}
