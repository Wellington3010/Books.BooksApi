using Books.BooksApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.BooksApi.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
