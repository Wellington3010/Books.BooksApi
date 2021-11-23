using Books.BooksApi.Data;
using Books.BooksApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.BooksApi.Interfaces
{
    public interface IBooksManagerService
    {
       Task<StatusCodeResult> Save(Book book);

       Task<StatusCodeResult> Update(Book book);

       Task<StatusCodeResult> Delete(Guid eanCode);

       Task<ActionResult<Book>> FindById(int bookId);
       Task<ActionResult<Book>> FindByTitle(string title);
       Task<ActionResult<Book>> FindByEanCode(string eanCode);
       Task<ActionResult<Book>> Find(string data, int typeQuery);
    }
}
