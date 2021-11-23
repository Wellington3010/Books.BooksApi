using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.BooksApi.Models
{
    [Table("Category")]
    public class Category
    {
        public Category() { }

        [Key]
        public int CategoryId { get; set; }

        public string CategoryCode { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}