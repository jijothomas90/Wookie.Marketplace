using System.Collections.Generic;
using Wookie.Marketplace.API.Models;
using System.Linq;
using System.IO;
using System;

namespace Wookie.Marketplace.API.Repository
{
    /// <summary>
    /// List of methods for Book Repository
    /// </summary>
    public class BookRepository : IBookRepository
    {
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
                Price = 280.00m
            },
            new Book()
            {
                 Id = 2,
                Title = "The Alchemist 2",
                Description = "The Alchemist is a novel by Brazilian author Paulo Coelho that was first published in 1988.",
                Author = "Paulo Coelho",
                Price = 380.00m
            }
        };

      
        /// <summary>
        /// To add new book to existing collection
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public long Add(Book book)
        {
            book.Id = new Random().Next(1, 1000000);
            books.Add(book);
            return book.Id;
        }

        public bool Delete(Book book)
        {
            return books.Remove(book);
        }
      
        public List<Book> GetAll()
        {
            return books;
        }

        public Book GetById(long id)
        {
            return books.Find(e => e.Id.Equals(id));
        }

        public bool IsExists(string title)
        {
            return books.Exists(e => e.Title.Equals(title,StringComparison.OrdinalIgnoreCase));
        }

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
