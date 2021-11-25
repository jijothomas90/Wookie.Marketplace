using System.ComponentModel.DataAnnotations;

namespace Wookie.Marketplace.API.Models
{
    /// <summary>
    /// Model for Books
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Book identification number like ISBN
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Title of the Book. Title, Author and Price are mandatory fields
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// Description of the Book
        /// </summary>
        [StringLength(250)]
        public string Description { get; set; }

        /// <summary>
        /// Name of the Author
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        /// <summary>
        /// Cover Image of the Book
        /// </summary>
        public byte[] CoverImage { get; set; }

        /// <summary>
        /// Price of the book
        /// </summary>
        [Required]
        public decimal Price { get; set; }
    }
}
