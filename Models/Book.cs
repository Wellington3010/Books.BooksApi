using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Books.BooksApi.Models
{
    [Table("Book")]
    public class Book
    {
        public Book() { }

        [Key]
        public int BookId { get; set; }

        [Required]
        [MaxLength(60, ErrorMessage = "Maximum numbers of characters from title reached")]
        public string Title { get; set; }
    
        public int VolumeNumber { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Maximum numbers of characters from publishingcompany reached")]
        public string PublishingCompany { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string EANCode { get; set; }

        public Author Author { get; set; }

        [Required]
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }

        public Category Category { get; set; }
        
        [Required]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

    }
}
