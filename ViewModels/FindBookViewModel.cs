using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.BooksApi.ViewModels
{
    public class FindBookViewModel
    {
        public FindBookViewModel()
        {

        }

        public string Data { get; set; }

        public int TypeQuery { get; set; }
    }
}
