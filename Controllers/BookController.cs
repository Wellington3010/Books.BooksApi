using AutoMapper;
using Books.BooksApi.Data;
using Books.BooksApi.Interfaces;
using Books.BooksApi.Models;
using Books.BooksApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Books.BooksApi.Controllers
{
    [Route("books")]
    [ApiController]
    [Produces("application/json")]
    public class BookController : ControllerBase
    {
        private readonly IBooksManagerService _booksManagerService;
        private readonly IMapper _mapper;

        public BookController(IBooksManagerService booksManagerService, IMapper mapper)
        {
           this._booksManagerService = booksManagerService;
           this._mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] BookViewModel model)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var book = _mapper.Map<Book>(model);

            return await _booksManagerService.Save(book);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] BookViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var book = _mapper.Map<Book>(model);

            return await _booksManagerService.Update(book);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string eanCode)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _booksManagerService.Delete(Guid.Parse(eanCode));
        }

        [HttpGet]
        public async Task<ActionResult<Book>> Find(FindBookViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _booksManagerService.Find(model.Data, model.TypeQuery);
        }
    }
}
