using Books.BooksApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.BooksApi.Interfaces
{
    public interface ICategoryService<T> where T : class
    {
       Task<StatusCodeResult> Save(T category);

       Task<StatusCodeResult> Update(T category);

       Task<StatusCodeResult> Delete(string categoryCode);

       Task<ActionResult<T>> FindById(string categoryCode);
       Task<ActionResult<T>> FindByName(string name);
    }
}
