using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.BooksApi.Models
{
    [Table("Author")]
    public class Author
    {
        public Author() { }

        [Key]
        public int AuthorId { get; set; }

        public string AuthorCode { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "Maximum characters numbers reached")]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}