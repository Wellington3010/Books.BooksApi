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
    [Route("categories")]
    [ApiController]
    [Produces("application/json")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService<Category> _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService<Category> categoryService, IMapper mapper)
        {
           this._categoryService = categoryService;
            this._mapper = mapper;

        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] CategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var category = _mapper.Map<Category>(model);

            return await _categoryService.Save(category);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] CategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var category = _mapper.Map<Category>(model);

            return await _categoryService.Update(category);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] string categoryCode)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _categoryService.Delete(categoryCode);
        }

        [HttpGet]
        public async Task<ActionResult<Category>> FindByName([FromRoute] string name)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _categoryService.FindByName(name);
        }
    }
}
