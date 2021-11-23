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
    [Route("authors")]
    [ApiController]
    [Produces("application/json")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService<Author> _authorService;

        private readonly IMapper _mapper;
            
        public AuthorController(IAuthorService<Author> authorService, IMapper mapper)
        {
           this._authorService = authorService;
           this._mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] AuthorViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var author = _mapper.Map<Author>(model);

            return await _authorService.Save(author);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] AuthorViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var author = _mapper.Map<Author>(model);

            return await _authorService.Update(author);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] string authorCode)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _authorService.Delete(authorCode);
        }

        [HttpGet]
        public async Task<ActionResult<Author>> FindByName([FromRoute] string name)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _authorService.FindByName(name);
        }
    }
}
