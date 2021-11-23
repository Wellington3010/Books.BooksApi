using Books.BooksApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.BooksApi.Interfaces
{
    public interface IAuthorService<T> where T : class
    {
       Task<StatusCodeResult> Save(T author);
       Task<StatusCodeResult> Update(T author);
       Task<StatusCodeResult> Delete(string authorCode);

       Task<ActionResult<T>> FindById(string authorCode);
       Task<ActionResult<T>> FindByName(string name);
    }
}
