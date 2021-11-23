using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.BooksApi.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel()
        {

        }

        public string Title { get; set; }

        public int VolumeNumber { get; set; }

        public string EANCode { get; set; }

        public string PublishingCompany { get; set; }

        public decimal Price { get; set; }

    }
}
